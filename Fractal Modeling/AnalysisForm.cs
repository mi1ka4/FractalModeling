using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FractalModeling;

namespace Fractal_Modeling
{
    public partial class AnalysisForm : Form
    {

        private List<GenerationResult> _data = new();
        private List<string> _loadedFiles = new();

        // Для Н₂: пары (название, путь .lsys, путь .ifs)
        private List<(string Name, string LsysPath, string IfsPath)> _h2Pairs = new();

        private bool _ignoreSelectionChange = false;

        public AnalysisForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            cmbFractalFilter.Items.Clear();
            cmbFractalFilter.Items.Add("Все фракталы");
            cmbFractalFilter.SelectedIndex = 0;

            cmbMethodFilter.Items.Clear();
            cmbMethodFilter.Items.AddRange(new object[] { "Все методы", "L-system", "IFS" });
            cmbMethodFilter.SelectedIndex = 0;

            dgvResults.Columns.Clear();
            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            foreach (string col in new[] { "Дата","Фрактал","Метод","Итерации",
                "Время (мс)","Элементов","Строка (симв.)","D","Заметки" })
                dgvResults.Columns.Add(col, col);

            // Н₁: переключатель T / S_work
            radH1Time.Text = "T(n) — время генерации";
            radH1Memory.Text = "S_work(n) — рабочая память";
            radH1Time.Checked = true;
            radH1Time.CheckedChanged += (s, e) => pnlH1.Invalidate();
            radH1Memory.CheckedChanged += (s, e) => pnlH1.Invalidate();
            pnlH1.Paint += (s, e) => DrawH1(e.Graphics, pnlH1.Width, pnlH1.Height);

            // Н₂: статический анализ файлов
            pnlH2.Paint += (s, e) => DrawH2(e.Graphics, pnlH2.Width, pnlH2.Height);

            // Н₃: сходимость D
            cmbH3Fractal.Items.Clear();
            cmbH3Fractal.SelectedIndexChanged += (s, e) => pnlH3.Invalidate();
            pnlH3.Paint += (s, e) => DrawH3(e.Graphics, pnlH3.Width, pnlH3.Height);
        }

        // ── Файлы результатов (CSV) ─────────────────────────────────────────

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (_ignoreSelectionChange) return;
            using var dlg = new OpenFileDialog { Filter = "CSV|*.csv|Все|*.*", Multiselect = true };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            foreach (var path in dlg.FileNames)
            {
                if (_loadedFiles.Contains(path)) continue;
                _loadedFiles.Add(path);
                lstFiles.Items.Add(Path.GetFileName(path));
            }
            RefreshAll();
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (_ignoreSelectionChange) return;
            int idx = lstFiles.SelectedIndex;
            if (idx < 0) return;
            _loadedFiles.RemoveAt(idx);
            lstFiles.Items.RemoveAt(idx);
            RefreshAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_ignoreSelectionChange) return;
            RefreshAll();
        }
        private void cmbFractalFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreSelectionChange) return;
            RefreshAll();
        }
        private void cmbMethodFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreSelectionChange) return;
            RefreshAll();
        }

        private void RefreshAll()
        {
            _data.Clear();
            foreach (var f in _loadedFiles)
                _data.AddRange(ResultLogger.Load(f));

            var fractals = _data.Select(r => r.FractalName).Distinct().OrderBy(x => x).ToList();

            string prevFractal = cmbFractalFilter.Text;
            cmbFractalFilter.Items.Clear();
            cmbFractalFilter.Items.Add("Все фракталы");
            foreach (var fr in fractals) cmbFractalFilter.Items.Add(fr);

            _ignoreSelectionChange = true;
            try
            {
                if (!string.IsNullOrEmpty(prevFractal) && cmbFractalFilter.Items.Contains(prevFractal))
                    cmbFractalFilter.SelectedItem = prevFractal;
                else
                    cmbFractalFilter.SelectedIndex = 0;
            }
            finally
            {
                _ignoreSelectionChange = false;
            }

            string prevH3 = cmbH3Fractal.Text;
            cmbH3Fractal.Items.Clear();
            foreach (var fr in fractals) cmbH3Fractal.Items.Add(fr);
            if (fractals.Contains(prevH3)) cmbH3Fractal.Text = prevH3;
            else if (cmbH3Fractal.Items.Count > 0) cmbH3Fractal.SelectedIndex = 0;

            var filtered = GetFiltered();
            FillTable(filtered);
            BuildSummary(filtered);
            pnlH1.Invalidate();
            pnlH3.Invalidate();

            
        }

        private List<GenerationResult> GetFiltered()
        {
            var data = new List<GenerationResult>(_data);
            string method = cmbMethodFilter.SelectedItem?.ToString() ?? "Все методы";
            string fractal = cmbFractalFilter.SelectedItem?.ToString() ?? "Все фракталы";
            if (method != "Все методы") data = data.Where(r => r.Method == method).ToList();
            if (fractal != "Все фракталы") data = data.Where(r => r.FractalName == fractal).ToList();
            return data;
        }

        private void FillTable(List<GenerationResult> data)
        {
            dgvResults.Rows.Clear();
            var sorted = data.OrderBy(r => r.FractalName)
                             .ThenBy(r => r.Method)
                             .ThenBy(r => r.Iterations)
                             .ToList();
            foreach (var r in sorted)
            {
                int ri = dgvResults.Rows.Add(
                    r.Timestamp.ToString("dd.MM.yy HH:mm"),
                    r.FractalName, r.Method, r.Iterations, r.ElapsedMs, r.ElementCount,
                    r.StringLength > 0 ? r.StringLength.ToString("N0") : "—",
                    r.FractalDim > 0 ? r.FractalDim.ToString("F3") : "—",
                    r.Notes);
                dgvResults.Rows[ri].DefaultCellStyle.BackColor =
                    r.Method == "L-system" ? Color.FromArgb(235, 245, 255) : Color.FromArgb(235, 255, 240);
            }
        }



        private void DrawH1(Graphics g, int W, int H)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            bool showTime = radH1Time.Checked;
            var data = GetFiltered();
            if (data.Count == 0)
            { DrawNoData(g, W, H, "Нет данных. Добавьте CSV."); return; }

            Func<IGrouping<int, GenerationResult>, double> valueFn = showTime
                ? (gr => gr.Average(r => (double)r.ElapsedMs))
                : (gr => gr.First().Method == "L-system"
                    ? gr.Average(r => (double)r.StringLength)
                    : gr.Average(r => (double)r.ElementCount));

            var series = data
                .GroupBy(r => (r.FractalName, r.Method))
                .Select(gr => new SeriesData
                {
                    Label = $"{ShortName(gr.Key.FractalName)} / {gr.Key.Method}",
                    Fractal = gr.Key.FractalName,
                    Method = gr.Key.Method,
                    Points = gr.GroupBy(r => r.Iterations)
                                .Select(g2 => (x: (double)g2.Key, y: valueFn(g2)))
                                .Where(p => showTime || p.y > 0)
                                .OrderBy(p => p.x).ToList()
                })
                .Where(s => s.Points.Count >= 2)
                .ToList();

            if (series.Count == 0)
            {
                DrawNoData(g, W, H,
                    showTime
                    ? "Недостаточно данных для T(n).\nНужно ≥2 значения n/N на серию."
                    : "Недостаточно данных для S_work(n).\n" +
                      "Для L-системы нужен StringLength>0, для IFS — ElementCount>0\n" +
                      "при ≥2 разных n/N.");
                return;
            }

            // ---- Преобразуем x в логарифмический масштаб ----
            var logSeries = series.Select(s => new SeriesData
            {
                Label = s.Label,
                Fractal = s.Fractal,
                Method = s.Method,
                Points = s.Points.Select(p => (x: Math.Log(p.x), y: p.y)).ToList()
            }).ToList();

            int left = 80, top = 40, right = W - 170, bottom = H - 70;
            if (right <= left || bottom <= top) return;

            double maxX = logSeries.SelectMany(s => s.Points).Max(p => p.x);
            double maxY = logSeries.SelectMany(s => s.Points).Max(p => p.y);
            if (maxY < 1) maxY = 1;

            string yLabel = showTime ? "T, мс" : "S_work, элементов";
            DrawAxes(g, left, top, right, bottom, "Итерации n / Точки N", yLabel, maxX, maxY, logX: true);

            Color[] palette = {
        Color.FromArgb(50,100,200), Color.FromArgb(200,80,50),
        Color.FromArgb(50,160,80),  Color.FromArgb(160,80,200),
        Color.FromArgb(200,160,40), Color.FromArgb(80,180,200),
    };
            int ci = 0;
            foreach (var s in logSeries)
            {
                var clr = palette[ci++ % palette.Length];
                DrawSeries(g, s.Points, left, top, right, bottom, maxX, maxY, clr);
                DrawLegendItem(g, right + 10, top + (ci - 1) * 22, clr, s.Label);
            }

            string title = showTime
                ? "Н₁ (часть T): время генерации T(n) — экспонента L-системы vs линейность IFS"
                : "Н₁ (часть S_work): рабочая память S_work(n) — |Sₙ| для L-системы, N для IFS";
            DrawChartTitle(g, left, top, W, title);

            DrawCrossoverNote(g, series, left, bottom, showTime); // используем исходные series (с линейными x) для вычислений
        }

        private class SeriesData
        {
            public string Label = "";
            public string Fractal = "";
            public string Method = "";
            public List<(double x, double y)> Points = new();
        }

        
        private void DrawCrossoverNote(Graphics g, List<SeriesData> series,
            int left, int bottom, bool showTime)
        {
            var fNote = new Font("Segoe UI", 8f, FontStyle.Italic);
            int y = bottom + 26;

            foreach (var grp in series.GroupBy(s => s.Fractal))
            {
                var ls = grp.FirstOrDefault(s => s.Method == "L-system");
                var ifs = grp.FirstOrDefault(s => s.Method == "IFS");
                if (ls == null || ifs == null) continue;

                double ifsMax = ifs.Points.Max(p => p.y);
                var crossPoint = ls.Points.FirstOrDefault(p => p.y > ifsMax);
                string metric = showTime ? "T" : "S_work";
                string msg = crossPoint.x > 0
                    ? $"{ShortName(grp.Key)}: при n = {crossPoint.x:F0} L-система превышает " +
                      $"максимум IFS по {metric} (Н₁/{metric} подтверждается для n ≥ {crossPoint.x:F0})"
                    : $"{ShortName(grp.Key)}: в наблюдаемом диапазоне L-система не превышает IFS по {metric}";
                g.DrawString(msg, fNote, Brushes.DimGray, left, y);
                y += 16;
            }
        }

        

        private void btnH2AddPair_Click(object sender, EventArgs e)
        {
            using var dlgL = new OpenFileDialog
            {
                Filter = "L-система (*.lsys)|*.lsys",
                Title = "Выбери .lsys файл"
            };
            if (dlgL.ShowDialog() != DialogResult.OK) return;

            using var dlgI = new OpenFileDialog
            {
                Filter = "IFS (*.ifs)|*.ifs",
                Title = "Выбери СООТВЕТСТВУЮЩИЙ .ifs файл (того же фрактала)"
            };
            if (dlgI.ShowDialog() != DialogResult.OK) return;

            string name = Path.GetFileNameWithoutExtension(dlgL.FileName);
            _h2Pairs.Add((name, dlgL.FileName, dlgI.FileName));
            lstH2Pairs.Items.Add(name);
            pnlH2.Invalidate();
        }

        private void btnH2RemovePair_Click(object sender, EventArgs e)
        {
            int idx = lstH2Pairs.SelectedIndex;
            if (idx < 0) return;
            _h2Pairs.RemoveAt(idx);
            lstH2Pairs.Items.RemoveAt(idx);
            pnlH2.Invalidate();
        }

        private void DrawH2(Graphics g, int W, int H)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (_h2Pairs.Count == 0)
            {
                DrawNoData(g, W, H,
                    "Нет пар файлов.\n\n" +
                    "Нажми «Добавить пару» и выбери .lsys и .ifs файл\n" +
                    "ОДНОГО И ТОГО ЖЕ фрактала (сохранённые через\n" +
                    "«Сохранить параметры» в Форме 1 и Форме 2).\n\n" +
                    "Это статическое сравнение K (размер файла, байт)\n" +
                    "и U (поддержка ветвления) — НЕ зависит от CSV.");
                return;
            }

            var fTitle = new Font("Segoe UI", 9f, FontStyle.Bold);
            var fText = new Font("Segoe UI", 9f);
            var fSmall = new Font("Segoe UI", 8f, FontStyle.Italic);

            g.DrawString("Н₂: компактность описания (K, байт) и поддержка ветвления (U)",
                fTitle, Brushes.DarkSlateBlue, 10, 8);

            int y = 40;

            g.DrawString("Фрактал", fTitle, Brushes.Black, 10, y);
            g.DrawString("K (.lsys), байт", fTitle, Brushes.Black, 220, y);
            g.DrawString("K (.ifs), байт", fTitle, Brushes.Black, 380, y);
            g.DrawString("Меньше K", fTitle, Brushes.Black, 520, y);
            g.DrawString("U: ветвление [ ]", fTitle, Brushes.Black, 650, y);
            y += 26;
            g.DrawLine(Pens.Gray, 10, y, W - 10, y);
            y += 8;

            int branchYes = 0;

            foreach (var (name, lsysPath, ifsPath) in _h2Pairs)
            {
                long kLsys = File.Exists(lsysPath) ? new FileInfo(lsysPath).Length : 0;
                long kIfs = File.Exists(ifsPath) ? new FileInfo(ifsPath).Length : 0;

                bool hasBranching = false;
                int ruleCount = 0;
                if (File.Exists(lsysPath))
                {
                    foreach (var line in File.ReadLines(lsysPath))
                    {
                        if (line.StartsWith("RULE=") || line.StartsWith("SRULE="))
                        {
                            ruleCount++;
                            if (line.Contains('[') || line.Contains(']')) hasBranching = true;
                        }
                    }
                }
                if (hasBranching) branchYes++;

                int transformCount = 0;
                if (File.Exists(ifsPath))
                    transformCount = File.ReadLines(ifsPath).Count(l => l.StartsWith("T|") || l.StartsWith("T="));

                string smaller = kLsys < kIfs ? "L-система"
                               : kIfs < kLsys ? "IFS" : "=";

                var name2 = name.Length > 16 ? name.Substring(0, 16)+"..." : name;
                g.DrawString(name2, fText, Brushes.Black, 10, y);
                g.DrawString($"{kLsys} б.", fText, Brushes.Black, 220, y);
                g.DrawString($"{kIfs} б.", fText, Brushes.Black, 380, y);

                var smBrush = smaller == "L-система" ? Brushes.SteelBlue
                            : smaller == "IFS" ? Brushes.SeaGreen
                            : Brushes.Gray;
                g.DrawString(smaller, fText, smBrush, 520, y);

                g.DrawString(hasBranching ? "Да" : "Нет",
                    fText, hasBranching ? Brushes.SteelBlue : Brushes.Gray, 650, y);

                y += 22;
                g.DrawString($"   правил: {ruleCount}  |  IFS-преобразований: {transformCount}",
                    fSmall, Brushes.DimGray, 10, y);
                y += 42;
                g.DrawLine(Pens.LightGray, 10, y - 6, W - 10, y - 6);
            }

            y += 10;
            var fConcl = new Font("Segoe UI", 9f, FontStyle.Bold);
            g.DrawString(
                $"Вывод: ветвление [ ] присутствует в {branchYes} из {_h2Pairs.Count} L-систем (U=Да). " +
                "Для IFS U=Нет всегда — ветвление требует доп. преобразований.",
                fConcl, Brushes.DarkGreen, 10, y);
        }

        

        private static readonly Dictionary<string, double> _theorD = new()
        {
            { "Треугольник Серпинского", 1.585 },
            { "Кривая Коха",             1.261 },
            { "Дракон Хартера-Хейтуэя", 2.000 },
        };

        private void DrawH3(Graphics g, int W, int H)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            string? fractal = cmbH3Fractal.SelectedItem?.ToString();
            if (fractal == null)
            { DrawNoData(g, W, H, "Выбери фрактал в списке сверху."); return; }

            if (!_theorD.TryGetValue(fractal, out double dTheor))
            {
                DrawNoData(g, W, H,
                    $"Для «{fractal}» теоретическое D неизвестно.\n" +
                    "Критерий C применим только к фракталам\n" +
                    "с известным D_теор: Серпинский, Коха, Дракон.");
                return;
            }

            var data = _data.Where(r => r.FractalName == fractal && r.FractalDim > 0).ToList();
            var series = data
                .GroupBy(r => r.Method)
                .Select(gr => new SeriesData
                {
                    Method = gr.Key,
                    Points = gr.GroupBy(r => r.Iterations)
                                .Select(g2 => (x: (double)g2.Key, y: g2.Average(r => r.FractalDim)))
                                .OrderBy(p => p.x).ToList()
                })
                .Where(s => s.Points.Count >= 1)
                .ToList();

            if (series.Count == 0)
            { DrawNoData(g, W, H, $"Нет данных D для «{fractal}»."); return; }

            // ---- Преобразуем x в логарифмический масштаб ----
            var logSeries = series.Select(s => new SeriesData
            {
                Method = s.Method,
                Points = s.Points.Select(p => (x: Math.Log(p.x), y: p.y)).ToList()
            }).ToList();

            int left = 80, top = 50, right = W - 180, bottom = H - 70;
            if (right <= left || bottom <= top) return;

            double maxX = logSeries.SelectMany(s => s.Points).Max(p => p.x);
            double maxY = Math.Max(dTheor + 0.3, logSeries.SelectMany(s => s.Points).Max(p => p.y) + 0.1);

            DrawAxes(g, left, top, right, bottom, "Итерации n / Точки N", "D", maxX, maxY, logX: true);

            int chartW = right - left, chartH = bottom - top;

            // Полоса допуска ±0.05
            int yLo = bottom - (int)(chartH * (dTheor - 0.05) / maxY);
            int yHi = bottom - (int)(chartH * (dTheor + 0.05) / maxY);
            using var bandBrush = new SolidBrush(Color.FromArgb(40, 0, 200, 0));
            g.FillRectangle(bandBrush, left, yHi, chartW, yLo - yHi);

            int yTheor = bottom - (int)(chartH * dTheor / maxY);
            using var theorPen = new Pen(Color.DarkGreen, 1.5f) { DashStyle = DashStyle.Dash };
            g.DrawLine(theorPen, left, yTheor, right, yTheor);
            g.DrawString($"D_теор = {dTheor:F3}  (полоса ±0.05)",
                new Font("Segoe UI", 8f), Brushes.DarkGreen, right - 200, yTheor - 16);

            Color[] palette = { Color.FromArgb(50, 100, 200), Color.FromArgb(80, 180, 100) };
            int ci = 0;
            double? n0_ls = null, n0_ifs = null;

            // Для поиска N₀ используем исходные (линейные) точки, чтобы выводить реальные значения
            foreach (var s in logSeries)
            {
                var origPoints = series.First(s2 => s2.Method == s.Method).Points; // оригинальные точки

                var clr = palette[ci % palette.Length];
                DrawSeries(g, s.Points, left, top, right, bottom, maxX, maxY, clr);
                DrawLegendItem(g, right + 10, top + ci * 40, clr, s.Method);

                var firstInBand = origPoints.FirstOrDefault(p => Math.Abs(p.y - dTheor) < 0.05);
                string n0Text = firstInBand.x > 0
                    ? $"N₀ = {firstInBand.x:F0}"
                    : "N₀: не достигнуто";
                g.DrawString(n0Text, new Font("Segoe UI", 8f, FontStyle.Bold), new SolidBrush(clr),
                    right + 10, top + ci * 40 + 16);

                if (s.Method == "L-system") n0_ls = firstInBand.x > 0 ? firstInBand.x : (double?)null;
                else n0_ifs = firstInBand.x > 0 ? firstInBand.x : (double?)null;

                ci++;
            }

            DrawChartTitle(g, left, top, W,
                $"Н₃ (критерий C): сходимость D(n) для «{ShortName(fractal)}» — поиск N₀");

            var fConcl = new Font("Segoe UI", 8.5f, FontStyle.Italic);
            string concl;
            if (n0_ls.HasValue && n0_ifs.HasValue)
                concl = Math.Abs(n0_ls.Value - n0_ifs.Value) < 1
                    ? "Оба метода достигают точности │D-D_теор│<0.05 при сопоставимых n/N — Н₃ подтверждается."
                    : $"L-система: N₀={n0_ls}, IFS: N₀={n0_ifs}. " +
                      (n0_ls < n0_ifs
                        ? "L-система сходится быстрее по числу итераций."
                        : "IFS сходится быстрее по числу точек.");
            else
                concl = "Недостаточно точек в допустимой полосе для одного из методов — нужно больше n/N.";
            g.DrawString(concl, fConcl, Brushes.DimGray, left, bottom + 30);
        }

        // ── Текстовый отчёт ──────────────────────────────────────────────────

        private void BuildSummary(List<GenerationResult> data)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("═══════════════════════════════════════════════════════");
            sb.AppendLine("  ОТЧЁТ ДЛЯ ГЛАВЫ 3  —  Q(Fᵢ,M) = (T, S_desc, S_work, K, C, U)");
            sb.AppendLine($"  Записей: {data.Count}  |  {DateTime.Now:dd.MM.yyyy HH:mm}");
            sb.AppendLine("═══════════════════════════════════════════════════════\n");

            if (data.Count == 0)
            { rtbSummary.Text = sb.ToString() + "Нет данных."; return; }

            sb.AppendLine("── Н₁: T(n) и S_work(n) ──────────────────────────────");
            var h1 = data.GroupBy(r => (r.FractalName, r.Method, r.Iterations))
                .Select(gr => new {
                    gr.Key.FractalName,
                    gr.Key.Method,
                    gr.Key.Iterations,
                    MeanT = gr.Average(r => r.ElapsedMs),
                    StdT = StdDev(gr.Select(r => (double)r.ElapsedMs).ToList()),
                    Swork = gr.First().Method == "L-system"
                        ? gr.Average(r => (double)r.StringLength)
                        : gr.Average(r => (double)r.ElementCount),
                    Count = gr.Count()
                })
                .OrderBy(x => x.FractalName).ThenBy(x => x.Method).ThenBy(x => x.Iterations);
            foreach (var x in h1)
                sb.AppendLine($"   {x.FractalName,-26} {x.Method,-8} n/N={x.Iterations,7}  " +
                    $"T={x.MeanT,7:F1}±{x.StdT,4:F1} мс  S_work={x.Swork,10:N0}  (n_rep={x.Count})");

            sb.AppendLine("\n── Н₂: K (размер файла) и U (ветвление) ─────────────");
            sb.AppendLine("   См. вкладку «Н₂: K и U» — статическое сравнение .lsys/.ifs файлов.");
            sb.AppendLine($"   Загружено пар файлов: {_h2Pairs.Count}");
            foreach (var (name, lp, ip) in _h2Pairs)
            {
                long kl = File.Exists(lp) ? new FileInfo(lp).Length : 0;
                long ki = File.Exists(ip) ? new FileInfo(ip).Length : 0;
                sb.AppendLine($"   {name,-26} K(.lsys)={kl,5} б.  K(.ifs)={ki,5} б.");
            }

            sb.AppendLine("\n── Н₃ (критерий C): сходимость D ────────────────────");
            foreach (var fr in _theorD.Keys)
            {
                if (!data.Any(r => r.FractalName == fr)) continue;
                double dT = _theorD[fr];
                foreach (var method in new[] { "L-system", "IFS" })
                {
                    var pts = data.Where(r => r.FractalName == fr && r.Method == method && r.FractalDim > 0)
                        .GroupBy(r => r.Iterations)
                        .Select(g2 => (x: g2.Key, y: g2.Average(r => r.FractalDim)))
                        .OrderBy(p => p.x).ToList();
                    if (pts.Count == 0) continue;
                    var inBand = pts.FirstOrDefault(p => Math.Abs(p.y - dT) < 0.05);
                    string n0 = inBand.x > 0 ? $"N₀={inBand.x}" : "не достигнуто";
                    sb.AppendLine($"   {fr,-26} {method,-8} D_теор={dT:F3}  {n0}");
                }
            }

            sb.AppendLine("\n════════════════════════════════════════════════════════");
            rtbSummary.Text = sb.ToString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog { Filter = "TXT|*.txt", FileName = "chapter3_data" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            File.WriteAllText(dlg.FileName, rtbSummary.Text, System.Text.Encoding.UTF8);
            MessageBox.Show("Экспортировано.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGoLSystem_Click(object sender, EventArgs e)
        { var f = new LSystemForm(); f.Show(); this.Hide(); f.FormClosed += (s, a) => this.Show(); }
        private void btnGoIFS_Click(object sender, EventArgs e)
        { var f = new IFSForm(); f.Show(); this.Hide(); f.FormClosed += (s, a) => this.Show(); }

        // ── Вспомогательные методы рисования ─────────────────────────────────

        private static void DrawAxes(Graphics g, int left, int top, int right, int bottom,
    string labelX, string labelY, double maxX, double maxY, bool logX = false)
        {
            using var axisPen = new Pen(Color.Gray, 1.5f);
            g.DrawLine(axisPen, left, top, left, bottom);
            g.DrawLine(axisPen, left, bottom, right, bottom);
            var fSmall = new Font("Segoe UI", 7.5f);
            var ci = System.Globalization.CultureInfo.InvariantCulture;
            int chartW = right - left, chartH = bottom - top;

            // ---- Ось Y (линейная) ----
            for (int step = 0; step <= 5; step++)
            {
                double val = maxY * step / 5.0;
                int yPos = bottom - (int)(chartH * step / 5.0);
                g.DrawLine(Pens.LightGray, left + 1, yPos, right, yPos);
                string lbl = val >= 1_000_000 ? $"{val / 1_000_000:F1}M"
                           : val >= 1_000 ? $"{val / 1_000:F0}K"
                           : val.ToString("F2", ci);
                g.DrawString(lbl, fSmall, Brushes.Gray, left - 4 - g.MeasureString(lbl, fSmall).Width, yPos - 6);
            }

            // ---- Ось X (логарифмическая или линейная) ----
            if (logX)
            {
                double logMin = 0; // соответствует x = 1
                double logMax = maxX;
                if (logMax <= 0) logMax = 1;

                double startExp = Math.Floor(logMin);
                double endExp = Math.Ceiling(logMax);
                for (double exp = startExp; exp <= endExp; exp += 1.0)
                {
                    double val = Math.Exp(exp);
                    if (val < Math.Exp(logMin) || val > Math.Exp(logMax)) continue;
                    int xPos = left + (int)(chartW * (exp - logMin) / (logMax - logMin));
                    if (xPos < left || xPos > right) continue;
                    // Вертикальная линия сетки
                    g.DrawLine(Pens.LightGray, xPos, top, xPos, bottom);
                    // Подпись
                    string lbl = val >= 1000 ? $"{val / 1000:F0}K" : val.ToString("F0", ci);
                    g.DrawString(lbl, fSmall, Brushes.Gray,
                        xPos - g.MeasureString(lbl, fSmall).Width / 2, bottom + 3);
                }

            }
            else
            {
                for (int step = 0; step <= 5; step++)
                {
                    double val = maxX * step / 5.0;
                    int xPos = left + (int)(chartW * step / 5.0);
                    string lbl = val >= 1_000_000 ? $"{val / 1_000_000:F1}M"
                               : val >= 1_000 ? $"{val / 1_000:F0}K"
                               : val.ToString("F0", ci);
                    g.DrawString(lbl, fSmall, Brushes.Gray,
                        xPos - g.MeasureString(lbl, fSmall).Width / 2, bottom + 3);
                    g.DrawLine(Pens.LightGray, xPos, top, xPos, bottom);
                }
            }

            var fAxis = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            var sf = new StringFormat { Alignment = StringAlignment.Center };
            g.TranslateTransform(12, top + chartH / 2f);
            g.RotateTransform(-90);
            g.DrawString(labelY, fAxis, Brushes.DarkSlateGray, 0, 0, sf);
            g.ResetTransform();

            string xLabel = logX ? labelX + " (log scale)" : labelX;
            g.DrawString(xLabel, fAxis, Brushes.DarkSlateGray,
                left + chartW / 2f - g.MeasureString(xLabel, fAxis).Width / 2, bottom + 18);
        }

        private static void DrawSeries(Graphics g, List<(double x, double y)> pts,
            int left, int top, int right, int bottom, double maxX, double maxY, Color clr)
        {
            if (pts.Count == 0) return;
            int chartW = right - left, chartH = bottom - top;
            using var br = new SolidBrush(clr);
            if (pts.Count == 1)
            {
                var sp = new PointF(left + (float)(pts[0].x / maxX * chartW), bottom - (float)(pts[0].y / maxY * chartH));
                g.FillEllipse(br, sp.X - 4, sp.Y - 4, 8, 8);
                return;
            }
            using var pen = new Pen(clr, 2f);
            var screenPts = pts.Select(p => new PointF(
                left + (float)(p.x / maxX * chartW), bottom - (float)(p.y / maxY * chartH))).ToArray();
            g.DrawLines(pen, screenPts);
            foreach (var sp in screenPts) g.FillEllipse(br, sp.X - 4, sp.Y - 4, 8, 8);
        }

        private static void DrawLegendItem(Graphics g, int x, int y, Color clr, string label)
        {
            using var pen = new Pen(clr, 2f);
            g.DrawLine(pen, x, y + 8, x + 20, y + 8);
            using var br = new SolidBrush(clr);
            g.FillEllipse(br, x + 7, y + 4, 8, 8);
            g.DrawString(label, new Font("Segoe UI", 8f), Brushes.DarkSlateGray, x + 24, y);
        }

        private static void DrawChartTitle(Graphics g, int left, int top, int W, string title)
            => g.DrawString(title, new Font("Segoe UI", 9f, FontStyle.Bold), Brushes.DarkSlateBlue, left, 4);

        private static void DrawNoData(Graphics g, int W, int H, string msg)
        {
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(msg, new Font("Segoe UI", 10f), Brushes.Gray, new RectangleF(20, 20, W - 40, H - 40), sf);
        }

        private static string ShortName(string name)
        {
            if (name.Length <= 12) return name;
            var words = name.Split(' ');
            return words.Length > 1 ? words[0] : name[..10] + "…";
        }

        private static double StdDev(List<double> vals)
        {
            if (vals.Count < 2) return 0;
            double mean = vals.Average();
            return Math.Sqrt(vals.Sum(v => (v - mean) * (v - mean)) / (vals.Count - 1));
        }
    }
}
