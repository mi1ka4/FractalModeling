using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;

namespace FractalModeling
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
            Action<Bitmap, int, long, List<(PointF from, PointF to)>?, long, bool> completedCallback,
            CancellationToken ct = default)
        {
            return Task.Run(() =>
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();

                string sentence;
                try
                {
                    sentence = ls.Generate(iterations);
                }
                catch
                {
                    completedCallback(null!, 0, 0, null, 0, true);
                    return;
                }

                if (ct.IsCancellationRequested)
                {
                    completedCallback(null!, 0, 0, null, 0, true);
                    return;
                }

                long sentenceLength = sentence.Length;

                var bbox = ls.ComputeBoundingBox(iterations, 0f);
                int W = bitmapWidth, H = bitmapHeight;
                float margin = 20f;
                float scaleX = bbox.Width > 0 ? (W - 2 * margin) / bbox.Width : 1f;
                float scaleY = bbox.Height > 0 ? (H - 2 * margin) / bbox.Height : 1f;
                float scale = Math.Min(scaleX, scaleY);
                float sx = margin - bbox.X * scale;
                float sy = margin - bbox.Y * scale;


                float savedStep = ls.StepSize;
                ls.StepSize = scale;
                var lines = ls.Interpret(sentence, sx, sy, 0f);
                ls.StepSize = savedStep;

                if (ct.IsCancellationRequested)
                {
                    completedCallback(null!, 0, sentenceLength, null, 0, true);
                    return;
                }

                var bmp = new Bitmap(W, H, PixelFormat.Format32bppArgb);
                int argb = penColor.ToArgb();
                int total = 0;
                int batch = 0;

                using (var gClear = Graphics.FromImage(bmp))
                    gClear.Clear(Color.White);

                BitmapData? bmpData = null;

                void Lock() => bmpData = bmp.LockBits(
                    new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite,
                    PixelFormat.Format32bppArgb);
                void Unlock() { if (bmpData != null) { bmp.UnlockBits(bmpData); bmpData = null; } }

                Lock();

                foreach (var (from, to) in lines)
                {
                    if (ct.IsCancellationRequested)
                    {
                        Unlock();
                        ls.StepSize = savedStep;

                        completedCallback(bmp, total, sentenceLength, null,
                            sw.ElapsedMilliseconds, true);
                        return;
                    }

                    unsafe
                    {
                        DrawLineBresenham(
                            (int*)bmpData!.Scan0.ToPointer(),
                            W, H,
                            (int)from.X, (int)from.Y,
                            (int)to.X, (int)to.Y,
                            argb);
                    }

                    total++;
                    batch++;

                    if (batch >= BATCH_SIZE)
                    {
                        batch = 0;
                        Unlock();
                        var preview = (Bitmap)bmp.Clone();
                        progressCallback(preview, total);
                        Lock();
                    }
                }

                Unlock();
                sw.Stop();

                completedCallback(bmp, total, sentenceLength, lines,
                    sw.ElapsedMilliseconds, false);

            }, ct);
        }

        // ── Алгоритм Брезенхема ───────────────────────────────────────────────
        private static unsafe void DrawLineBresenham(
            int* pixels, int width, int height,
            int x0, int y0, int x1, int y1, int color)
        {
            int dx = Math.Abs(x1 - x0);
            int dy = -Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx + dy;

            while (true)
            {
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