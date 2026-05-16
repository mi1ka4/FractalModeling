using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalModeling
{
    public class LSystem
    {
        public string Name { get; set; } = "Custom";
        public string Axiom { get; set; } = "F";
        public float Delta { get; set; } = 90f;
        public float StepSize { get; set; } = 1f;
        public float StepGrowth { get; set; } = 0f;   // % приращение шага
        public float StepVariance { get; set; } = 0f;   // % дисперсия шага

        private readonly Dictionary<char, string> _rules = new();

        private readonly Random _rnd = new();

        // ── Правила ───────────────────────────────────────────────────────────

        public void AddRule(char symbol, string production)
            => _rules[symbol] = production;

        public void ClearRules()
            => _rules.Clear();

        public IEnumerable<(char symbol, string production)> GetRules()
        {
            foreach (var kv in _rules)
                yield return (kv.Key, kv.Value);
        }

        // ── Генерация строки ──────────────────────────────────────────────────

        public string Generate(int iterations)
        {
            var current = new StringBuilder(Axiom);

            for (int i = 0; i < iterations; i++)
            {
                var next = new StringBuilder(current.Length * 2);
                foreach (char c in current.ToString())
                {
                    if (_rules.TryGetValue(c, out string? prod))
                        next.Append(prod);
                    else
                        next.Append(c);
                }
                current = next;
            }

            return current.ToString();
        }

        // ── Черепашья интерпретация ───────────────────────────────────────────

        /// Интерпретирует строку и возвращает список отрезков.
        /// Поддерживаемые команды:
        ///   F/G/A/B — шаг вперёд с рисованием
        ///   f       — шаг вперёд без рисования
        ///   +       — поворот влево на Delta градусов
        ///   -       — поворот вправо на Delta градусов
        ///   [       — сохранить состояние в стек
        ///   ]       — восстановить состояние из стека
        ///   |       — разворот на 180°
        ///   X,Y,... — нетерминалы, игнорируются
        public List<(PointF from, PointF to)> Interpret(
            string sentence, float startX, float startY, float startAngleDeg)
        {
            var lines = new List<(PointF, PointF)>(sentence.Length);
            var stack = new Stack<(float x, float y, float angle, float step)>();

            float x = startX;
            float y = startY;
            float angle = startAngleDeg * MathF.PI / 180f;
            float step = StepSize;
            float dRad = Delta * MathF.PI / 180f;
            float grow = StepSize * StepGrowth / 100f;

            foreach (char c in sentence)
            {
                float s = step;
                if (StepVariance > 0)
                    s *= 1f + (float)(_rnd.NextDouble() * 2 - 1) * StepVariance / 100f;

                switch (c)
                {
                    case 'F':
                    case 'G':
                    case 'A':
                    case 'B':
                        {
                            float nx = x + s * MathF.Cos(angle);
                            float ny = y - s * MathF.Sin(angle); // Y-ось экрана
                            lines.Add((new PointF(x, y), new PointF(nx, ny)));
                            x = nx; y = ny;
                            step += grow;
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

            return lines;
        }

        public RectangleF ComputeBoundingBox(int iterations, float startAngleDeg = 0f)
        {
            float saved = StepSize;
            StepSize = 1f;
            string s = Generate(iterations);
            var lines = Interpret(s, 0, 0, startAngleDeg);
            StepSize = saved;

            if (lines.Count == 0) return new RectangleF(0, 0, 1, 1);

            float minX = 0, maxX = 0, minY = 0, maxY = 0;
            foreach (var (f, t) in lines)
            {
                minX = MathF.Min(minX, MathF.Min(f.X, t.X));
                maxX = MathF.Max(maxX, MathF.Max(f.X, t.X));
                minY = MathF.Min(minY, MathF.Min(f.Y, t.Y));
                maxY = MathF.Max(maxY, MathF.Max(f.Y, t.Y));
            }
            return new RectangleF(minX, minY, maxX - minX, maxY - minY);
        }

        // ── Сериализация ──────────────────────────────────────────────────────

        public void SaveToFile(string path)
        {
            using var w = new System.IO.StreamWriter(path, false, Encoding.UTF8);
            w.WriteLine($"NAME={Name}");
            w.WriteLine($"AXIOM={Axiom}");
            w.WriteLine($"DELTA={Delta.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            w.WriteLine($"STEP={StepSize.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            w.WriteLine($"GROWTH={StepGrowth.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            w.WriteLine($"VARIANCE={StepVariance.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            foreach (var kv in _rules)
                w.WriteLine($"RULE={kv.Key}|{kv.Value}");
        }

        public static LSystem LoadFromFile(string path)
        {
            var ls = new LSystem();
            var ci = System.Globalization.CultureInfo.InvariantCulture;
            foreach (var line in System.IO.File.ReadLines(path))
            {
                if (line.StartsWith("NAME=")) ls.Name = line[5..];
                else if (line.StartsWith("AXIOM=")) ls.Axiom = line[6..];
                else if (line.StartsWith("DELTA=")) ls.Delta = float.Parse(line[6..], ci);
                else if (line.StartsWith("STEP=")) ls.StepSize = float.Parse(line[5..], ci);
                else if (line.StartsWith("GROWTH=")) ls.StepGrowth = float.Parse(line[7..], ci);
                else if (line.StartsWith("VARIANCE=")) ls.StepVariance = float.Parse(line[9..], ci);
                else if (line.StartsWith("RULE="))
                {
                    var p = line[5..].Split('|', 2);
                    if (p.Length == 2) ls.AddRule(p[0][0], p[1]);
                }
            }
            return ls;
        }
    }
}
