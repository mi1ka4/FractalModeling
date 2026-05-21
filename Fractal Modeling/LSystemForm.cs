using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fractal_Modeling;

namespace FractalModeling
{
    public partial class LSystemForm : Form
    {
        private LSystem _ls = new();
        private Bitmap? _bitmap = null;
        private Color _penColor = Color.RoyalBlue;

        private CancellationTokenSource? _cts = null;

        private string _resultFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "FractalResults.csv");

        public LSystemForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            cmbFractal.Items.Clear();
            cmbFractal.Items.AddRange(FractalPresets.LSystemNames);
            cmbFractal.SelectedIndex = 0;

        }

        // ── Событие: выбор фрактала из списка ─────────────────────────────────

        private void cmbFractal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFractal.SelectedIndex < FractalPresets.LSystemNames.Length - 1)
                LoadPreset(cmbFractal.SelectedIndex);
        }

        private void LoadPreset(int idx)
        {
            _ls = FractalPresets.GetLSystem(idx);
            txtAxiom.Text = _ls.Axiom;
            txtAngle.Text = _ls.Delta.ToString();
            txtStep.Text = _ls.StepSize.ToString();
            txtGrowth.Text = _ls.StepGrowth.ToString();
            txtVariance.Text = _ls.StepVariance.ToString();
            RefreshRulesList();
        }

        // ── Правила ───────────────────────────────────────────────────────────

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            string sym = txtRuleSymbol.Text.Trim();
            string prod = txtRuleProduction.Text.Trim();
            if (sym.Length == 0 || prod.Length == 0) return;

            _ls.AddRule(sym[0], prod);
            RefreshRulesList();
        }

        private void RefreshRulesList()
        {
            lstRules.Items.Clear();
            foreach (var (sym, prod) in _ls.GetRules())
                lstRules.Items.Add($"{sym}  →  {prod}");
        }

        private void btnClearRules_Click(object sender, EventArgs e)
        {
            _ls.ClearRules();
            lstRules.Items.Clear();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            using var cd = new ColorDialog { Color = _penColor };
            if (cd.ShowDialog() == DialogResult.OK)
            {
                _penColor = cd.Color;
                btnColor.BackColor = _penColor;
            }
        }

        private void btnLoadParams_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog { Filter = "L-система (*.lsys)|*.lsys" };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            _ls = LSystem.LoadFromFile(dlg.FileName);
            // Переключаем на "Пользовательский"
            cmbFractal.SelectedIndex = FractalPresets.LSystemNames.Length - 1;
            txtAxiom.Text = _ls.Axiom;
            txtAngle.Text = _ls.Delta.ToString();
            txtStep.Text = _ls.StepSize.ToString();
            txtGrowth.Text = _ls.StepGrowth.ToString();
            txtVariance.Text = _ls.StepVariance.ToString();
            RefreshRulesList();
        }

        private void btnSaveParams_Click(object sender, EventArgs e)
        {
            ApplyFieldsToModel();
            using var dlg = new SaveFileDialog
            {
                Filter = "L-система (*.lsys)|*.lsys",
                FileName = _ls.Name.Replace(" ", "_")
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _ls.SaveToFile(dlg.FileName);
            MessageBox.Show("Параметры сохранены.", "Готово",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (_bitmap == null) { MessageBox.Show("Сначала постройте фрактал."); return; }
            using var dlg = new SaveFileDialog
            {
                Filter = "PNG|*.png|BMP|*.bmp",
                FileName = _ls.Name.Replace(" ", "_") + "_lsys"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _bitmap.Save(dlg.FileName,
                dlg.FilterIndex == 1 ? ImageFormat.Png : ImageFormat.Bmp);
            MessageBox.Show("Сохранено.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGoIFS_Click(object sender, EventArgs e)
        {
            var f = new IFSForm();
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
        private void ApplyFieldsToModel()
        {
            _ls.Axiom = txtAxiom.Text.Trim();
            _ls.Delta = ParseFloat(txtAngle.Text, 90f);
            _ls.StepSize = ParseFloat(txtStep.Text, 1f);
            _ls.StepGrowth = ParseFloat(txtGrowth.Text, 0f);
            _ls.StepVariance = ParseFloat(txtVariance.Text, 0f);
        }

        private static float ParseFloat(string s, float def)
            => float.TryParse(s.Replace(',', '.'),
                System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture, out float v) ? v : def;

        private async void btnBuild_Click(object sender, EventArgs e)
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts = null;
            }

            ApplyFieldsToModel();
            int n = (int)nudIterations.Value;
            int W = picBox.Width > 10 ? picBox.Width : 800;
            int H = picBox.Height > 10 ? picBox.Height : 600;

            SetBusy(true);

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            var lsCopy = CloneLSystem(_ls);

            await LSystemRenderer.RenderAsync(
                ls: lsCopy,
                iterations: n,
                bitmapWidth: W,
                bitmapHeight: H,
                penColor: _penColor,

                progressCallback: (previewBmp, drawnSoFar) =>
                {
                    this.Invoke(() =>
                    {
                        var old = picBox.Image;
                        picBox.Image = previewBmp;
                        old?.Dispose();
                        lblInfo.Text = $"Рисую... отрезков: {drawnSoFar:N0}";
                    });
                },

                completedCallback: (finalBmp, totalLines, elapsedMs, cancelled) =>
                {
                    this.Invoke(() =>
                    {
                        SetBusy(false);

                        if (cancelled)
                        {
                            lblTime.Text = "Остановлено.";
                            lblInfo.Text = $"Нарисовано отрезков: {totalLines:N0}";
                            if (finalBmp != null)
                            {
                                _bitmap?.Dispose();
                                _bitmap = finalBmp;
                                picBox.Image = _bitmap;
                            }
                            return;
                        }

                        _bitmap?.Dispose();
                        _bitmap = finalBmp;
                        picBox.Image = _bitmap;

                        double dim = ResultLogger.EstimateBoxCountDim(null);

                        


                        lblTime.Text = $"Время: {elapsedMs} мс";
                        lblInfo.Text = $"Отрезков: {totalLines:N0}  |  n={n}";

                        ResultLogger.Append(_resultFile, new GenerationResult
                        {
                            FractalName = lsCopy.Name,
                            Method = "L-system",
                            Iterations = n,
                            ElapsedMs = elapsedMs,
                            ElementCount = totalLines,
                            StringLength = 0,
                            FractalDim = 0,
                            Notes = $"Delta={lsCopy.Delta}",
                        });
                    });
                },

                ct: token
            );
        }

        private void SetBusy(bool busy)
        {
            btnBuild.Enabled = !busy;
            btnCancel.Enabled = busy;
            progressBar.Visible = busy;
            cmbFractal.Enabled = !busy;
            nudIterations.Enabled = !busy;

            if (!busy) progressBar.Visible = false;
        }

        private void LSystemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _bitmap?.Dispose();
            base.OnFormClosed(e);
        }

        private static LSystem CloneLSystem(LSystem src)
        {
            var dst = new LSystem
            {
                Name = src.Name,
                Axiom = src.Axiom,
                Delta = src.Delta,
                StepSize = src.StepSize,
                StepGrowth = src.StepGrowth,
                StepVariance = src.StepVariance,
            };
            foreach (var (sym, prod) in src.GetRules())
                dst.AddRule(sym, prod);
            return dst;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            btnCancel.Enabled = false;
        }
    }
}
