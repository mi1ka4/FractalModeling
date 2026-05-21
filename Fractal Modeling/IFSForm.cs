using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FractalModeling;
using static FractalModeling.FractalPresets;

namespace Fractal_Modeling
{
    public partial class IFSForm : Form
    {

        private IFSGenerator _ifs = new();
        private Bitmap? _bitmap = null;
        private Color _dotColor = Color.ForestGreen;

        private string _resultFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "FractalResults.csv");
        public IFSForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            // Настройка DataGridView колонок (a b c d e f p Метка)
            SetupGrid();

            cmbFractal.Items.Clear();
            cmbFractal.Items.AddRange(FractalPresets.IFSNames);
            cmbFractal.SelectedIndex = 0;

            nudIterations.Minimum = 1000;
            nudIterations.Maximum = 1000000;
            nudIterations.Increment = 10000;
            nudIterations.Value = 100000;
            
            
        }

        private void SetupGrid()
        {
            dgvTransforms.Columns.Clear();
            dgvTransforms.AllowUserToAddRows = false;
            dgvTransforms.RowHeadersWidth = 28;
            dgvTransforms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (string col in new[] { "a", "b", "c", "d", "e", "f", "p", "Метка" })
            {
                var dc = new DataGridViewTextBoxColumn
                {
                    HeaderText = col,
                    Name = "col_" + col,
                };
                // Метка — шире остальных
                if (col == "Метка") dc.FillWeight = 200;
                dgvTransforms.Columns.Add(dc);
            }
        }

        private void cmbFractal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFractal.SelectedIndex < FractalPresets.IFSNames.Length - 1)
                LoadPreset(cmbFractal.SelectedIndex);
        }

        private void LoadPreset(int idx)
        {
            _ifs = FractalPresets.GetIFS(idx);
            FillGridFromIFS(_ifs);
        }

        private void FillGridFromIFS(IFSGenerator ifs)
        {
            var ci = System.Globalization.CultureInfo.InvariantCulture;
            dgvTransforms.Rows.Clear();
            for (int i = 0; i < ifs.Count; i++)
            {
                var t = ifs.Get(i);
                dgvTransforms.Rows.Add(
                    t.A.ToString("F4", ci), t.B.ToString("F4", ci),
                    t.C.ToString("F4", ci), t.D.ToString("F4", ci),
                    t.E.ToString("F4", ci), t.F.ToString("F4", ci),
                    t.Probability.ToString("F4", ci),
                    t.Label);
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            var ci = System.Globalization.CultureInfo.InvariantCulture;
            dgvTransforms.Rows.Add("0", "0", "0", "0", "0", "0", "0", "");
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (dgvTransforms.SelectedRows.Count > 0)
                dgvTransforms.Rows.RemoveAt(dgvTransforms.SelectedRows[0].Index);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            using var cd = new ColorDialog { Color = _dotColor };
            if (cd.ShowDialog() == DialogResult.OK)
            {
                _dotColor = cd.Color;
                btnColor.BackColor = _dotColor;
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            try
            {
                _ifs = BuildIFSFromGrid();
                int iterations = (int)nudIterations.Value;

                int W = picBox.Width > 10 ? picBox.Width : 600;
                int H = picBox.Height > 10 ? picBox.Height : 500;

                _bitmap?.Dispose();
                _bitmap = new Bitmap(W, H);

                // Белый фон
                using (var g = Graphics.FromImage(_bitmap))
                    g.Clear(Color.White);

                var sw = Stopwatch.StartNew();
                _ifs.DrawChaosGame(_bitmap, iterations, _dotColor);
                sw.Stop();

                picBox.Image = _bitmap;
                lblTime.Text = $"Время: {sw.ElapsedMilliseconds} мс";
                lblInfo.Text = $"Итераций: {iterations}  |  Преобразований: {_ifs.Count}";

                ResultLogger.Append(_resultFile, new GenerationResult
                {
                    FractalName = _ifs.Name,
                    Method = "IFS",
                    Iterations = iterations,
                    ElapsedMs = sw.ElapsedMilliseconds,
                    ElementCount = iterations,
                    StringLength = 0,
                    FractalDim = 0,
                    Notes = $"Transforms={_ifs.Count}",
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IFSGenerator BuildIFSFromGrid()
        {
            var ifs = new IFSGenerator { Name = cmbFractal.Text };
            var ci = System.Globalization.CultureInfo.InvariantCulture;

            foreach (DataGridViewRow row in dgvTransforms.Rows)
            {
                double Parse(int col) =>
                    double.TryParse(
                        row.Cells[col].Value?.ToString()?.Replace(',', '.'),
                        System.Globalization.NumberStyles.Float, ci, out double v) ? v : 0;

                ifs.AddTransform(new IFSTransform(
                    Parse(0), Parse(1), Parse(2), Parse(3),
                    Parse(4), Parse(5), Parse(6),
                    row.Cells[7].Value?.ToString() ?? ""));
            }
            return ifs;
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (_bitmap == null) { MessageBox.Show("Сначала постройте фрактал."); return; }
            using var dlg = new SaveFileDialog
            {
                Filter = "PNG|*.png|BMP|*.bmp",
                FileName = _ifs.Name.Replace(" ", "_") + "_ifs"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _bitmap.Save(dlg.FileName,
                dlg.FilterIndex == 1 ? ImageFormat.Png : ImageFormat.Bmp);
            MessageBox.Show("Сохранено.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveParams_Click(object sender, EventArgs e)
        {
            _ifs = BuildIFSFromGrid();
            using var dlg = new SaveFileDialog
            {
                Filter = "IFS-параметры (*.ifs)|*.ifs",
                FileName = _ifs.Name.Replace(" ", "_")
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _ifs.SaveToFile(dlg.FileName);
            MessageBox.Show("Параметры сохранены.", "Готово",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLoadParams_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog { Filter = "IFS-параметры (*.ifs)|*.ifs" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _ifs = IFSGenerator.LoadFromFile(dlg.FileName);
            cmbFractal.SelectedIndex = FractalPresets.IFSNames.Length - 1;
            FillGridFromIFS(_ifs);
        }

        private void btnGoLSystem_Click(object sender, EventArgs e)
        {
            var f = new LSystemForm();
            f.Show();
            this.Hide();
            f.FormClosed += (s, args) => this.Show();
        }

        private void btnGoAnalysis_Click(object sender, EventArgs e)
        {
            var f = new AnalysisForm();
            f.Show();
            this.Hide();
            f.FormClosed += (s, args) => this.Show();
        }

        private void IFSForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _bitmap?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
