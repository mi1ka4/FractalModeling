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

        public AnalysisForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            // Фильтр
            cmbFilter.Items.Clear();
            cmbFilter.Items.AddRange(new object[] { "Все", "L-system", "IFS" });
            cmbFilter.SelectedIndex = 0;

            // Метрика для графика
            cmbMetric.Items.Clear();
            cmbMetric.Items.AddRange(new object[]
            {
                "Время генерации (мс)",
                "Количество элементов",
                "Длина строки (L-system)",
                "Фракт. размерность D",
            });
            cmbMetric.SelectedIndex = 0;

            // DataGridView — таблица результатов
            SetupResultsGrid();
        }

        private void SetupResultsGrid()
        {
            dgvResults.Columns.Clear();
            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            foreach (string col in new[]
            {
                "Дата", "Фрактал", "Метод", "Итерации",
                "Время (мс)", "Элементов", "Строка", "D", "Заметки"
            })
                dgvResults.Columns.Add(col, col);
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            int idx = lstFiles.SelectedIndex;
            if (idx < 0) return;
            _loadedFiles.RemoveAt(idx);
            lstFiles.Items.RemoveAt(idx);
            RefreshData();
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Filter = "CSV|*.csv|Все файлы|*.*",
                Multiselect = true
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            foreach (var path in dlg.FileNames)
            {
                if (_loadedFiles.Contains(path)) continue;
                _loadedFiles.Add(path);
                lstFiles.Items.Add(Path.GetFileName(path));
            }
            RefreshData();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => RefreshData();

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) => RefreshData();


        private void cmbMetric_SelectedIndexChanged(object sender, EventArgs e) => pnlChart.Invalidate();

        private void RefreshData()
        {
            _data.Clear();
            foreach (var f in _loadedFiles)
                _data.AddRange(ResultLogger.Load(f));

            var filtered = GetFiltered();
            FillTable(filtered);
            BuildSummary(filtered);
            pnlChart.Invalidate();
        }

        private List<GenerationResult> GetFiltered()
        {
            string filter = cmbFilter.SelectedItem?.ToString() ?? "Все";
            return filter == "Все"
                ? new List<GenerationResult>(_data)
                : _data.Where(r => r.Method == filter).ToList();
        }

        private void FillTable(List<GenerationResult> data)
        {
            dgvResults.Rows.Clear();
            foreach (var r in data)
            {
                int ri = dgvResults.Rows.Add(
                    r.Timestamp.ToString("dd.MM.yy HH:mm"),
                    r.FractalName,
                    r.Method,
                    r.Iterations,
                    r.ElapsedMs,
                    r.ElementCount,
                    r.StringLength > 0 ? r.StringLength.ToString() : "—",
                    r.FractalDim > 0 ? r.FractalDim.ToString("F3") : "—",
                    r.Notes);

                // Цветовая дифференциация
                dgvResults.Rows[ri].DefaultCellStyle.BackColor =
                    r.Method == "L-system"
                        ? Color.FromArgb(235, 245, 255)
                        : Color.FromArgb(235, 255, 240);
            }
        }

        private void BuildSummary(List<GenerationResult> data)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("══════════════════════════════════════════════════════");
            sb.AppendLine("  СВОДНАЯ СТАТИСТИКА");
            sb.AppendLine($"  Записей: {data.Count}  |  {DateTime.Now:dd.MM.yyyy HH:mm}");
            sb.AppendLine("══════════════════════════════════════════════════════\n");

            foreach (var method in new[] { "L-system", "IFS" })
            {
                var g = data.Where(r => r.Method == method).ToList();
                if (g.Count == 0) continue;

                sb.AppendLine($"┌─── {method} ({g.Count} записей)");
                sb.AppendLine($"│  Ср. время     : {g.Average(r => r.ElapsedMs):F1} мс");
                sb.AppendLine($"│  Мин/Макс время: {g.Min(r => r.ElapsedMs)} / {g.Max(r => r.ElapsedMs)} мс");
                sb.AppendLine($"│  Ср. элементов : {g.Average(r => r.ElementCount):F0}");

                if (method == "L-system")
                {
                    var ls = g.Where(r => r.StringLength > 0).ToList();
                    if (ls.Count > 0)
                        sb.AppendLine($"│  Ср. длина стр.: {ls.Average(r => r.StringLength):F0}");
                }

                var wd = g.Where(r => r.FractalDim > 0).ToList();
                if (wd.Count > 0)
                    sb.AppendLine($"│  Ср. D         : {wd.Average(r => r.FractalDim):F3}");

                sb.AppendLine("│");
                foreach (var fg in g.GroupBy(r => r.FractalName).OrderBy(x => x.Key))
                {
                    sb.AppendLine($"│  [{fg.Key}]");
                    sb.AppendLine($"│    Записей  : {fg.Count()}");
                    sb.AppendLine($"│    Ср. время: {fg.Average(r => r.ElapsedMs):F1} мс");
                }
                sb.AppendLine("└──────────────────────────────────────────────────\n");
            }

            // L-system vs IFS по фракталам
            var fractals = data.Select(r => r.FractalName).Distinct().OrderBy(x => x);
            bool hasCompare = false;
            foreach (var fr in fractals)
            {
                var ls = data.Where(r => r.FractalName == fr && r.Method == "L-system").ToList();
                var ifs = data.Where(r => r.FractalName == fr && r.Method == "IFS").ToList();
                if (ls.Count == 0 || ifs.Count == 0) continue;
                if (!hasCompare)
                {
                    sb.AppendLine("┌─── L-система vs IFS ─────────────────────────────");
                    hasCompare = true;
                }
                double lsT = ls.Average(r => r.ElapsedMs);
                double ifsT = ifs.Average(r => r.ElapsedMs);
                string faster = lsT < ifsT ? "L-система быстрее" : "IFS быстрее";
                double ratio = Math.Max(lsT, ifsT) / Math.Max(Math.Min(lsT, ifsT), 0.01);
                sb.AppendLine($"│  {fr}");
                sb.AppendLine($"│    L-система: {lsT:F1} мс  |  IFS: {ifsT:F1} мс  → {faster} (×{ratio:F1})");
            }
            if (hasCompare) sb.AppendLine("└──────────────────────────────────────────────────");

            rtbSummary.Text = sb.ToString();
        }

        private void pnlChart_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            var data = GetFiltered();
            if (data.Count == 0)
            {
                g.DrawString("Нет данных. Добавьте файл результатов.",
                    new Font("Segoe UI", 11), Brushes.Gray, 30, 30);
                return;
            }

            // Функция значения по выбранной метрике
            Func<GenerationResult, double> getValue = cmbMetric.SelectedIndex switch
            {
                0 => r => r.ElapsedMs,
                1 => r => r.ElementCount,
                2 => r => r.StringLength,
                3 => r => r.FractalDim,
                _ => r => r.ElapsedMs,
            };

            // Группировка: (Фрактал, Метод) → среднее
            var groups = data
                .GroupBy(r => (r.FractalName, r.Method))
                .OrderBy(gr => gr.Key.FractalName)
                .ThenBy(gr => gr.Key.Method)
                .Select(gr => (
                    Label: $"{gr.Key.FractalName.Split(' ')[0]}\n({gr.Key.Method})",
                    Value: gr.Average(getValue)
                ))
                .ToList();

            if (groups.Count == 0) return;

            double maxVal = groups.Max(gr => gr.Value);
            if (maxVal < 0.001) maxVal = 1;

            int left = 80, top = 30, right = pnlChart.Width - 20, bottom = pnlChart.Height - 60;
            int chartW = right - left, chartH = bottom - top;
            int n = groups.Count;
            int barW = Math.Max(8, chartW / (n + 1));
            int gap = Math.Max(3, barW / 5);

            Color[] palette =
            {
                Color.FromArgb(70,120,200),  Color.FromArgb(80,180,100),
                Color.FromArgb(220,100,60),  Color.FromArgb(160,80,200),
                Color.FromArgb(200,180,60),  Color.FromArgb(80,180,180),
            };

            // Оси
            using var axisPen = new Pen(Color.Gray, 1.5f);
            g.DrawLine(axisPen, left, top, left, bottom);
            g.DrawLine(axisPen, left, bottom, right, bottom);

            var fntSmall = new Font("Segoe UI", 7.5f);
            var fntVal = new Font("Segoe UI", 7f);
            var fntTitle = new Font("Segoe UI", 9f, FontStyle.Bold);
            var sf = new StringFormat { Alignment = StringAlignment.Center };

            // Горизонтальные линии сетки + метки Y
            for (int step = 0; step <= 5; step++)
            {
                double val = maxVal * step / 5.0;
                int yPos = bottom - (int)(chartH * step / 5.0);
                g.DrawLine(Pens.LightGray, left + 1, yPos, right, yPos);
                string lbl = val >= 1_000_000 ? $"{val / 1_000_000:F1}M"
                           : val >= 1_000 ? $"{val / 1_000:F1}K"
                           : $"{val:F2}";
                g.DrawString(lbl, fntVal, Brushes.Gray,
                    left - 4 - g.MeasureString(lbl, fntVal).Width, yPos - 6);
            }

            // Название оси Y (вертикально)
            g.TranslateTransform(12, top + chartH / 2f);
            g.RotateTransform(-90);
            g.DrawString(cmbMetric.Text, fntSmall, Brushes.DarkSlateGray, 0, 0, sf);
            g.ResetTransform();

            // Заголовок
            g.DrawString($"Сравнение: {cmbMetric.Text}", fntTitle, Brushes.DarkSlateBlue, left, 4);

            // Столбцы
            for (int i = 0; i < n; i++)
            {
                int barH = (int)(chartH * groups[i].Value / maxVal);
                int x = left + gap + i * (barW + gap);
                int y0 = bottom - barH;

                var clr = palette[i % palette.Length];
                using var brush = new SolidBrush(clr);
                g.FillRectangle(brush, x, y0, barW, barH);
                g.DrawRectangle(new Pen(Color.FromArgb(80, 0, 0, 0), 1f), x, y0, barW, barH);

                // Значение над столбцом
                string vs = groups[i].Value >= 1_000_000 ? $"{groups[i].Value / 1_000_000:F1}M"
                          : groups[i].Value >= 1_000 ? $"{groups[i].Value / 1_000:F1}K"
                          : $"{groups[i].Value:F1}";
                var vsz = g.MeasureString(vs, fntVal);
                g.DrawString(vs, fntVal, Brushes.Black,
                    x + (barW - vsz.Width) / 2f, y0 - vsz.Height - 1);

                // Метка под осью
                var lsz = g.MeasureString(groups[i].Label, fntSmall);
                g.DrawString(groups[i].Label, fntSmall, Brushes.DarkSlateGray,
                    x + (barW - lsz.Width) / 2f, bottom + 3);
            }
        }

        

        private void btnExport_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog
            {
                Filter = "TXT|*.txt",
                FileName = "fractal_analysis"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            File.WriteAllText(dlg.FileName, rtbSummary.Text, System.Text.Encoding.UTF8);
            MessageBox.Show("Экспортировано.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGoLSystem_Click(object sender, EventArgs e)
        {
            var f = new LSystemForm();
            f.Show();
            this.Hide();
            f.FormClosed += (s, args) => this.Show();
        }

        private void btnGoIFS_Click(object sender, EventArgs e)
        {
            var f = new IFSForm();
            f.Show();
            this.Hide();
            f.FormClosed += (s, args) => this.Show();
        }
    }
}
