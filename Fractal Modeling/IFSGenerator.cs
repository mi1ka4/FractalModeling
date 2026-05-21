using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractal_Modeling
{

    public class IFSTransform
    {
        public double A, B, C, D, E, F;
        public double Probability;
        public string Label;

        public IFSTransform(double a, double b, double c, double d,
                             double e, double f, double probability, string label = "")
        {
            A = a; B = b; C = c; D = d;
            E = e; F = f;
            Probability = probability;
            Label = label;
        }

        public (double x, double y) Apply(double x, double y)
            => (A * x + B * y + E, C * x + D * y + F);
    }

    public class IFSGenerator
    {
        public string Name { get; set; } = "Custom IFS";

        private readonly List<IFSTransform> _transforms = new();

        // кэш bounding box
        private double _minX, _maxX, _minY, _maxY;
        private bool _boundsValid = false;

        public IFSGenerator() { }

        public IFSGenerator(IEnumerable<IFSTransform> transforms)
            => _transforms.AddRange(transforms);

        public void AddTransform(IFSTransform t) { _transforms.Add(t); _boundsValid = false; }
        public void RemoveAt(int index) { _transforms.RemoveAt(index); _boundsValid = false; }
        public void Clear() { _transforms.Clear(); _boundsValid = false; }
        public int Count => _transforms.Count;
        public IFSTransform Get(int i) => _transforms[i];

        // ── Chaos Game ────────────────────────────────────────────────────────

        /// <summary>
        /// Рисует аттрактор IFS на Bitmap методом случайных итераций.
        /// Использует LockBits для быстрой записи пикселей.
        /// </summary>
        public void DrawChaosGame(Bitmap bmp, int iterations, Color color, int warmup = 25)
        {
            if (_transforms.Count == 0)
                throw new InvalidOperationException("Нет аффинных преобразований.");

            if (!_boundsValid) ComputeBounds(60_000);

            double[] cumP = BuildCumulative();
            var rnd = new Random(42);
            double x = 0, y = 0;

            int W = bmp.Width, H = bmp.Height;
            double margin = 0.06;
            double rx = _maxX - _minX; if (rx < 1e-9) rx = 1;
            double ry = _maxY - _minY; if (ry < 1e-9) ry = 1;
            double scale = Math.Min(W / (rx * (1 + 2 * margin)),
                                    H / (ry * (1 + 2 * margin)));
            double offX = -(_minX - rx * margin) * scale;
            double offY = H + (_minY - ry * margin) * scale;

            int argb = color.ToArgb();
            var data = bmp.LockBits(new Rectangle(0, 0, W, H),
                                     ImageLockMode.ReadWrite,
                                     PixelFormat.Format32bppArgb);
            unsafe
            {
                int* ptr = (int*)data.Scan0.ToPointer();
                for (int k = 0; k < iterations + warmup; k++)
                {
                    int idx = Choose(rnd.NextDouble(), cumP);
                    var t = _transforms[idx];
                    double nx = t.A * x + t.B * y + t.E;
                    double ny = t.C * x + t.D * y + t.F;
                    x = nx; y = ny;
                    if (k >= warmup)
                    {
                        int px = (int)(x * scale + offX);
                        int py = (int)(-y * scale + offY);
                        if (px >= 0 && px < W && py >= 0 && py < H)
                            ptr[py * W + px] = argb;
                    }
                }
            }
            bmp.UnlockBits(data);
        }

        // ── Вспомогательные ───────────────────────────────────────────────────

        private double[] BuildCumulative()
        {
            var cp = new double[_transforms.Count];
            cp[0] = _transforms[0].Probability;
            for (int i = 1; i < _transforms.Count; i++)
                cp[i] = cp[i - 1] + _transforms[i].Probability;
            cp[^1] = 1.0;
            return cp;
        }

        private static int Choose(double r, double[] cumP)
        {
            int i = 0;
            while (i < cumP.Length - 1 && r > cumP[i]) i++;
            return i;
        }

        private void ComputeBounds(int probe)
        {
            var cp = BuildCumulative();
            var rnd = new Random(0);
            double x = 0, y = 0;
            _minX = _maxX = _minY = _maxY = 0;
            for (int k = 0; k < probe; k++)
            {
                var t = _transforms[Choose(rnd.NextDouble(), cp)];
                double nx = t.A * x + t.B * y + t.E;
                double ny = t.C * x + t.D * y + t.F;
                x = nx; y = ny;
                if (k > 25)
                {
                    _minX = Math.Min(_minX, x); _maxX = Math.Max(_maxX, x);
                    _minY = Math.Min(_minY, y); _maxY = Math.Max(_maxY, y);
                }
            }
            _boundsValid = true;
        }

        // ── Сериализация ──────────────────────────────────────────────────────

        public void SaveToFile(string path)
        {
            var ci = System.Globalization.CultureInfo.InvariantCulture;
            using var w = new StreamWriter(path, false, Encoding.UTF8);
            w.WriteLine($"NAME={Name}");
            foreach (var t in _transforms)
                w.WriteLine(string.Join("|",
                    "T",
                    t.A.ToString("F6", ci), t.B.ToString("F6", ci),
                    t.C.ToString("F6", ci), t.D.ToString("F6", ci),
                    t.E.ToString("F6", ci), t.F.ToString("F6", ci),
                    t.Probability.ToString("F6", ci),
                    t.Label));
        }

        public static IFSGenerator LoadFromFile(string path)
        {
            var ifs = new IFSGenerator();
            var ci = System.Globalization.CultureInfo.InvariantCulture;
            foreach (var line in File.ReadLines(path))
            {
                if (line.StartsWith("NAME=")) { ifs.Name = line[5..]; continue; }
                if (!line.StartsWith("T|")) continue;
                var p = line[2..].Split('|');
                if (p.Length < 7) continue;
                ifs.AddTransform(new IFSTransform(
                    double.Parse(p[0], ci), double.Parse(p[1], ci),
                    double.Parse(p[2], ci), double.Parse(p[3], ci),
                    double.Parse(p[4], ci), double.Parse(p[5], ci),
                    double.Parse(p[6], ci),
                    p.Length > 7 ? p[7] : ""));
            }
            return ifs;
        }
    }
}
