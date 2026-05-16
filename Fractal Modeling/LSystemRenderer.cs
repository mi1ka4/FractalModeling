using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FractalModeling;

namespace Fractal_Modeling
{
    public static class LSystemRenderer
    {

        private const int BATCH_SIZE = 2_000;


        public static Task RenderAsync(
            LSystem ls,
            int iterations,
            int bitmapWidth,
            int bitmapHeight,
            Color penColor,
            Action<Bitmap, int> progressCallback,
            Action<Bitmap, int, long, bool> completedCallback,
            CancellationToken ct = default)
        {
            return Task.Run(() =>
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();

                // ── 1. Генерируем строку (это тоже может занять время при n=12) ──
                string sentence;
                try { sentence = ls.Generate(iterations); }
                catch (OperationCanceledException) { completedCallback(null, 0, 0, true); return; }

                if (ct.IsCancellationRequested) { completedCallback(null, 0, 0, true); return; }

                // ── 2. Вычисляем автомасштаб ──────────────────────────────────
                var bbox = ls.ComputeBoundingBox(iterations, 0f);
                float W = bitmapWidth, H = bitmapHeight;
                float margin = 20f;
                float scaleX = bbox.Width > 0 ? (W - 2 * margin) / bbox.Width : 1f;
                float scaleY = bbox.Height > 0 ? (H - 2 * margin) / bbox.Height : 1f;
                float scale = Math.Min(scaleX, scaleY);
                float sx = margin - bbox.X * scale;
                float sy = margin - bbox.Y * scale;

                // ── 3. Создаём Bitmap и лочим пиксели ─────────────────────────
                var bmp = new Bitmap((int)W, (int)H, PixelFormat.Format32bppArgb);

                // Заливка белым
                using (var g = Graphics.FromImage(bmp))
                    g.Clear(Color.White);

                int argb = penColor.ToArgb();
                int totalLines = 0;

                // ── 4. Интерпретируем строку и рисуем батчами ─────────────────
                float savedStep = ls.StepSize;
                ls.StepSize = scale;

                // Состояние черепашки
                float x = sx;
                float y = sy;
                float angle = 0f;
                float step = ls.StepSize;
                float dRad = ls.Delta * MathF.PI / 180f;
                var stack = new Stack<(float x, float y, float angle, float step)>();
                var rnd = new Random();

                // Для батчевой отрисовки — лочим/анлочим по батчам
                BitmapData? bmpData = null;
                int batchCount = 0;

                void LockBmp()
                {
                    bmpData = bmp.LockBits(
                        new Rectangle(0, 0, bmp.Width, bmp.Height),
                        ImageLockMode.ReadWrite,
                        PixelFormat.Format32bppArgb);
                }

                void UnlockBmp()
                {
                    if (bmpData != null) { bmp.UnlockBits(bmpData); bmpData = null; }
                }

                LockBmp();

                foreach (char c in sentence)
                {
                    if (ct.IsCancellationRequested)
                    {
                        UnlockBmp();
                        ls.StepSize = savedStep;
                        completedCallback(bmp, totalLines, sw.ElapsedMilliseconds, true);
                        return;
                    }

                    float s = step;
                    if (ls.StepVariance > 0)
                        s *= 1f + (float)(rnd.NextDouble() * 2 - 1) * ls.StepVariance / 100f;

                    switch (c)
                    {
                        case 'F':
                        case 'G':
                        case 'A':
                        case 'B':
                            {
                                float nx = x + s * MathF.Cos(angle);
                                float ny = y - s * MathF.Sin(angle);

                                // Рисуем линию алгоритмом Брезенхема прямо в пиксели
                                unsafe
                                {
                                    DrawLineBresenham(
                                        (int*)bmpData!.Scan0.ToPointer(),
                                        bmp.Width, bmp.Height,
                                        (int)x, (int)y, (int)nx, (int)ny,
                                        argb);
                                }

                                x = nx; y = ny;
                                step += ls.StepSize * ls.StepGrowth / 100f;
                                totalLines++;
                                batchCount++;

                                // Каждые BATCH_SIZE линий — отправляем промежуточный результат
                                if (batchCount >= BATCH_SIZE)
                                {
                                    batchCount = 0;
                                    UnlockBmp();

                                    // Отправляем КОПИЮ, чтобы UI мог её спокойно показывать
                                    // пока мы продолжаем рисовать в оригинал
                                    var preview = (Bitmap)bmp.Clone();
                                    progressCallback(preview, totalLines);

                                    LockBmp();
                                }
                                break;
                            }
                        case 'f':
                            x += s * MathF.Cos(angle);
                            y -= s * MathF.Sin(angle);
                            break;
                        case '+': angle += dRad; break;
                        case '-': angle -= dRad; break;
                        case '|': angle += MathF.PI; break;
                        case '[': stack.Push((x, y, angle, step)); break;
                        case ']':
                            if (stack.Count > 0) (x, y, angle, step) = stack.Pop();
                            break;
                    }
                }

                UnlockBmp();
                ls.StepSize = savedStep;
                sw.Stop();

                completedCallback(bmp, totalLines, sw.ElapsedMilliseconds, false);

            }, ct);
        }

        // ── Алгоритм Брезенхема ───────────────────────────────────────────────
        // Рисует отрезок напрямую в массив пикселей без вызовов GDI+.
        // unsafe — прямой доступ к памяти Bitmap через указатель.

        private static unsafe void DrawLineBresenham(
            int* pixels, int width, int height,
            int x0, int y0, int x1, int y1,
            int color)
        {
            int dx = Math.Abs(x1 - x0);
            int dy = -Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx + dy;

            while (true)
            {
                // Запись пикселя — только если в пределах холста
                if ((uint)x0 < (uint)width && (uint)y0 < (uint)height)
                    pixels[y0 * width + x0] = color;

                if (x0 == x1 && y0 == y1) break;

                int e2 = err * 2;
                if (e2 >= dy) { err += dy; x0 += sx; }
                if (e2 <= dx) { err += dx; y0 += sy; }
            }
        }
    }
}
