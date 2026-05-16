using System.Reflection.Emit;

namespace FractalModeling
{
    public static class FractalPresets
    {
        // ── L-системы ─────────────────────────────────────────────────────────

        public static LSystem GetLSystem(int index)
        {
            return index switch
            {
                0 => Sierpinski_LS(),
                1 => Koch_LS(),
                2 => Dragon_LS(),
                3 => Fern_LS(),
                4 => Tree_LS(),
                _ => new LSystem { Name = "Пользовательский" }
            };
        }

        private static LSystem Sierpinski_LS()
        {
            var ls = new LSystem { Name = "Треугольник Серпинского", Axiom = "F-G-G", Delta = 120f };
            ls.AddRule('F', "F-G+F+G-F");
            ls.AddRule('G', "GG");
            return ls;
        }

        private static LSystem Koch_LS()
        {
            var ls = new LSystem { Name = "Кривая Коха", Axiom = "F++F++F", Delta = 60f };
            ls.AddRule('F', "F-F++F-F");
            return ls;
        }

        private static LSystem Dragon_LS()
        {
            var ls = new LSystem { Name = "Дракон Хартера-Хейтуэя", Axiom = "FX", Delta = 90f };
            ls.AddRule('X', "X+YF+");
            ls.AddRule('Y', "-FX-Y");
            return ls;
        }

        private static LSystem Fern_LS()
        {
            var ls = new LSystem { Name = "Папоротник Барнсли", Axiom = "X", Delta = 25f };
            ls.AddRule('X', "F+[[X]-X]-F[-FX]+X");
            ls.AddRule('F', "FF");
            return ls;
        }

        private static LSystem Tree_LS()
        {
            var ls = new LSystem { Name = "Дерево", Axiom = "X", Delta = 25f };
            ls.AddRule('X', "F[+X][-X]FX");
            ls.AddRule('F', "FF");
            return ls;
        }

        public static string[] LSystemNames => new[]
        {
            "Треугольник Серпинского",
            "Кривая Коха",
            "Дракон Хартера-Хейтуэя",
            "Папоротник Барнсли",
            "Дерево",
            "Пользовательский"
        };

        // ── IFS ───────────────────────────────────────────────────────────────

        //    public static IFSGenerator GetIFS(int index)
        //    {
        //        return index switch
        //        {
        //            0 => Sierpinski_IFS(),
        //            1 => Koch_IFS(),
        //            2 => Dragon_IFS(),
        //            3 => Fern_IFS(),
        //            _ => new IFSGenerator { Name = "Пользовательский IFS" }
        //        };
        //    }

        //    private static IFSGenerator Sierpinski_IFS()
        //        => new IFSGenerator(new[]
        //        {
        //            new IFSTransform(0.5, 0,   0,   0.5, 0,    0,     1.0/3, "Низ-лево"),
        //            new IFSTransform(0.5, 0,   0,   0.5, 0.5,  0,     1.0/3, "Низ-право"),
        //            new IFSTransform(0.5, 0,   0,   0.5, 0.25, 0.433, 1.0/3, "Верх"),
        //        })
        //        { Name = "Треугольник Серпинского" };

        //    private static IFSGenerator Koch_IFS()
        //    {
        //        double s = 1.0 / 3.0;
        //        double c60 = Math.Cos(Math.PI / 3);
        //        double s60 = Math.Sin(Math.PI / 3);
        //        return new IFSGenerator(new[]
        //        {
        //            new IFSTransform( s,      0,      0,      s,      0,      0,     0.25, "Начало"),
        //            new IFSTransform( s*c60, -s*s60,  s*s60,  s*c60,  1.0/3,  0,     0.25, "Левый зуб"),
        //            new IFSTransform( s*c60,  s*s60, -s*s60,  s*c60,  0.5,   s60/3,  0.25, "Правый зуб"),
        //            new IFSTransform( s,      0,      0,      s,      2.0/3,  0,     0.25, "Конец"),
        //        })
        //        { Name = "Кривая Коха" };
        //    }

        //    private static IFSGenerator Dragon_IFS()
        //        => new IFSGenerator(new[]
        //        {
        //            new IFSTransform( 0.5, -0.5,  0.5,  0.5, 0.0, 0.0, 0.5, "Первое"),
        //            new IFSTransform(-0.5,  0.5,  0.5,  0.5, 1.0, 0.0, 0.5, "Второе"),
        //        })
        //        { Name = "Дракон Хартера-Хейтуэя" };

        //    private static IFSGenerator Fern_IFS()
        //        => new IFSGenerator(new[]
        //        {
        //            new IFSTransform( 0,     0,      0,      0.16,  0,  0,    0.01, "Стебель"),
        //            new IFSTransform( 0.85,  0.04,  -0.04,   0.85,  0,  1.60, 0.85, "Листок"),
        //            new IFSTransform( 0.20, -0.26,   0.23,   0.22,  0,  1.60, 0.07, "Лев.побег"),
        //            new IFSTransform(-0.15,  0.28,   0.26,   0.24,  0,  0.44, 0.07, "Прав.побег"),
        //        })
        //        { Name = "Папоротник Барнсли" };

        //    // Названия для ComboBox на IFSForm
        //    public static string[] IFSNames => new[]
        //    {
        //        "Треугольник Серпинского",
        //        "Кривая Коха",
        //        "Дракон Хартера-Хейтуэя",
        //        "Папоротник Барнсли",
        //        "Пользовательский"
        //    };
        //}

        // =========================================================================
        //  РЕЗУЛЬТАТ ГЕНЕРАЦИИ
        // =========================================================================

        public class GenerationResult
        {
            public DateTime Timestamp { get; set; } = DateTime.Now;
            public string FractalName { get; set; } = "";
            public string Method { get; set; } = "";   // "L-system" | "IFS"
            public int Iterations { get; set; }
            public long ElapsedMs { get; set; }
            public int ElementCount { get; set; }
            public long StringLength { get; set; }
            public double FractalDim { get; set; }
            public string Notes { get; set; } = "";
        }

        // =========================================================================
        //  ЛОГГЕР РЕЗУЛЬТАТОВ (CSV)
        // =========================================================================

        public static class ResultLogger
        {
            private const string Header =
                "Timestamp;FractalName;Method;Iterations;ElapsedMs;" +
                "ElementCount;StringLength;FractalDim;Notes";

            public static void Append(string filePath, GenerationResult r)
            {
                bool exists = File.Exists(filePath);
                using var sw = new StreamWriter(filePath, append: true, System.Text.Encoding.UTF8);
                if (!exists) sw.WriteLine(Header);
                var ci = System.Globalization.CultureInfo.InvariantCulture;
                sw.WriteLine(string.Join(";",
                    r.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"),
                    r.FractalName.Replace(";", ","),
                    r.Method,
                    r.Iterations,
                    r.ElapsedMs,
                    r.ElementCount,
                    r.StringLength,
                    r.FractalDim.ToString("F4", ci),
                    r.Notes.Replace(";", ",")));
            }

            public static List<GenerationResult> Load(string filePath)
            {
                var list = new List<GenerationResult>();
                if (!File.Exists(filePath)) return list;

                var ci = System.Globalization.CultureInfo.InvariantCulture;
                bool first = true;
                foreach (var line in File.ReadLines(filePath))
                {
                    if (first) { first = false; continue; }
                    var p = line.Split(';');
                    if (p.Length < 9) continue;
                    list.Add(new GenerationResult
                    {
                        Timestamp = DateTime.TryParse(p[0], out var dt) ? dt : DateTime.MinValue,
                        FractalName = p[1],
                        Method = p[2],
                        Iterations = int.TryParse(p[3], out int it) ? it : 0,
                        ElapsedMs = long.TryParse(p[4], out long ms) ? ms : 0,
                        ElementCount = int.TryParse(p[5], out int ec) ? ec : 0,
                        StringLength = long.TryParse(p[6], out long sl) ? sl : 0,
                        FractalDim = double.TryParse(p[7], ci, out double fd) ? fd : 0,
                        Notes = p[8],
                    });
                }
                return list;
            }

            // ── Box-counting размерность ──────────────────────────────────────────

            /// Оценивает фрактальную размерность методом ящиков по списку отрезков.
            public static double EstimateBoxCountDim(
                List<(System.Drawing.PointF from, System.Drawing.PointF to)> lines)
            {
                if (lines == null || lines.Count == 0) return 0;

                float minX = float.MaxValue, maxX = float.MinValue;
                float minY = float.MaxValue, maxY = float.MinValue;

                var pts = new List<System.Drawing.PointF>(lines.Count * 2);
                foreach (var (f, t) in lines)
                {
                    pts.Add(f); pts.Add(t);
                    minX = Math.Min(minX, Math.Min(f.X, t.X));
                    maxX = Math.Max(maxX, Math.Max(f.X, t.X));
                    minY = Math.Min(minY, Math.Min(f.Y, t.Y));
                    maxY = Math.Max(maxY, Math.Max(f.Y, t.Y));
                }

                double rangeX = maxX - minX; if (rangeX < 1) rangeX = 1;
                double rangeY = maxY - minY; if (rangeY < 1) rangeY = 1;

                int[] sizes = { 4, 8, 16, 32, 64 };
                var logN = new List<double>();
                var logE = new List<double>();

                foreach (int bs in sizes)
                {
                    var occupied = new HashSet<(int, int)>();
                    foreach (var pt in pts)
                    {
                        int bx = (int)((pt.X - minX) / rangeX * bs);
                        int by = (int)((pt.Y - minY) / rangeY * bs);
                        occupied.Add((Math.Min(bx, bs - 1), Math.Min(by, bs - 1)));
                    }
                    if (occupied.Count > 1)
                    {
                        logN.Add(Math.Log(occupied.Count));
                        logE.Add(Math.Log(1.0 / bs));
                    }
                }

                if (logN.Count < 2) return 0;

                // МНК: D = -наклон прямой log(N) vs log(1/ε)
                double n = logN.Count, sx = 0, sy = 0, sxy = 0, sxx = 0;
                for (int i = 0; i < logN.Count; i++)
                { sx += logE[i]; sy += logN[i]; sxy += logE[i] * logN[i]; sxx += logE[i] * logE[i]; }

                double slope = (n * sxy - sx * sy) / (n * sxx - sx * sx);
                return Math.Round(-slope, 3);
            }
        }
    }
}