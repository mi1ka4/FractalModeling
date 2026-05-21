namespace Fractal_Modeling
{
    partial class IFSForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelLeft = new Panel();
            lblInfo = new Label();
            lblTime = new Label();
            btnBuild = new Button();
            lblColorInfo = new Label();
            btnColor = new Button();
            grpParams = new GroupBox();
            nudIterations = new NumericUpDown();
            label2 = new Label();
            grpTransforms = new GroupBox();
            btnRemoveRow = new Button();
            btnAddRow = new Button();
            dgvTransforms = new DataGridView();
            cmbFractal = new ComboBox();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            btnSaveImage = new ToolStripMenuItem();
            btnSaveParams = new ToolStripMenuItem();
            btnLoadParams = new ToolStripMenuItem();
            навигацияToolStripMenuItem = new ToolStripMenuItem();
            btnGoLSystem = new ToolStripMenuItem();
            btnGoAnalysis = new ToolStripMenuItem();
            picBox = new PictureBox();
            panelLeft.SuspendLayout();
            grpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudIterations).BeginInit();
            grpTransforms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransforms).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(lblInfo);
            panelLeft.Controls.Add(lblTime);
            panelLeft.Controls.Add(btnBuild);
            panelLeft.Controls.Add(lblColorInfo);
            panelLeft.Controls.Add(btnColor);
            panelLeft.Controls.Add(grpParams);
            panelLeft.Controls.Add(grpTransforms);
            panelLeft.Controls.Add(cmbFractal);
            panelLeft.Controls.Add(label1);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 33);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(441, 829);
            panelLeft.TabIndex = 0;
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(38, 744);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(269, 57);
            lblInfo.TabIndex = 13;
            lblInfo.Text = "Инфо";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(38, 708);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(64, 25);
            lblTime.TabIndex = 12;
            lblTime.Text = "Время";
            // 
            // btnBuild
            // 
            btnBuild.Location = new Point(38, 659);
            btnBuild.Margin = new Padding(3, 4, 3, 4);
            btnBuild.Name = "btnBuild";
            btnBuild.Size = new Size(136, 40);
            btnBuild.TabIndex = 11;
            btnBuild.Text = "▶ Построить";
            btnBuild.UseVisualStyleBackColor = true;
            btnBuild.Click += btnBuild_Click;
            // 
            // lblColorInfo
            // 
            lblColorInfo.AutoSize = true;
            lblColorInfo.Location = new Point(38, 610);
            lblColorInfo.Name = "lblColorInfo";
            lblColorInfo.Size = new Size(106, 25);
            lblColorInfo.TabIndex = 9;
            lblColorInfo.Text = "Цвет точек:";
            // 
            // btnColor
            // 
            btnColor.BackColor = Color.Blue;
            btnColor.ForeColor = Color.White;
            btnColor.Location = new Point(174, 602);
            btnColor.Margin = new Padding(3, 4, 3, 4);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(133, 40);
            btnColor.TabIndex = 8;
            btnColor.Text = "Цвет";
            btnColor.UseVisualStyleBackColor = false;
            btnColor.Click += btnColor_Click;
            // 
            // grpParams
            // 
            grpParams.Controls.Add(nudIterations);
            grpParams.Controls.Add(label2);
            grpParams.Location = new Point(15, 480);
            grpParams.Name = "grpParams";
            grpParams.Size = new Size(423, 115);
            grpParams.TabIndex = 3;
            grpParams.TabStop = false;
            grpParams.Text = "Параметры генерации";
            // 
            // nudIterations
            // 
            nudIterations.Location = new Point(162, 49);
            nudIterations.Name = "nudIterations";
            nudIterations.Size = new Size(153, 31);
            nudIterations.TabIndex = 1;
            // 
            // label2
            // 
            label2.Location = new Point(18, 39);
            label2.Name = "label2";
            label2.Size = new Size(138, 59);
            label2.TabIndex = 0;
            label2.Text = "Итераций (Chaos Game):";
            // 
            // grpTransforms
            // 
            grpTransforms.Controls.Add(btnRemoveRow);
            grpTransforms.Controls.Add(btnAddRow);
            grpTransforms.Controls.Add(dgvTransforms);
            grpTransforms.Location = new Point(12, 79);
            grpTransforms.Name = "grpTransforms";
            grpTransforms.Size = new Size(423, 395);
            grpTransforms.TabIndex = 2;
            grpTransforms.TabStop = false;
            grpTransforms.Text = "Аффинные преобразования";
            // 
            // btnRemoveRow
            // 
            btnRemoveRow.Location = new Point(295, 343);
            btnRemoveRow.Name = "btnRemoveRow";
            btnRemoveRow.Size = new Size(112, 34);
            btnRemoveRow.TabIndex = 2;
            btnRemoveRow.Text = "- Удалить";
            btnRemoveRow.UseVisualStyleBackColor = true;
            btnRemoveRow.Click += btnRemoveRow_Click;
            // 
            // btnAddRow
            // 
            btnAddRow.Location = new Point(18, 343);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(112, 34);
            btnAddRow.TabIndex = 1;
            btnAddRow.Text = "+ Строка";
            btnAddRow.UseVisualStyleBackColor = true;
            btnAddRow.Click += btnAddRow_Click;
            // 
            // dgvTransforms
            // 
            dgvTransforms.AllowUserToAddRows = false;
            dgvTransforms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransforms.Location = new Point(18, 41);
            dgvTransforms.Name = "dgvTransforms";
            dgvTransforms.RowHeadersWidth = 62;
            dgvTransforms.Size = new Size(389, 284);
            dgvTransforms.TabIndex = 0;
            // 
            // cmbFractal
            // 
            cmbFractal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFractal.FormattingEnabled = true;
            cmbFractal.Location = new Point(192, 23);
            cmbFractal.Name = "cmbFractal";
            cmbFractal.Size = new Size(154, 33);
            cmbFractal.TabIndex = 1;
            cmbFractal.SelectedIndexChanged += cmbFractal_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(156, 25);
            label1.TabIndex = 0;
            label1.Text = "Выбор фрактала: ";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, навигацияToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1581, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnSaveImage, btnSaveParams, btnLoadParams });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(69, 29);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // btnSaveImage
            // 
            btnSaveImage.Name = "btnSaveImage";
            btnSaveImage.Size = new Size(315, 34);
            btnSaveImage.Text = "Сохранить изображение";
            btnSaveImage.Click += btnSaveImage_Click;
            // 
            // btnSaveParams
            // 
            btnSaveParams.Name = "btnSaveParams";
            btnSaveParams.Size = new Size(315, 34);
            btnSaveParams.Text = "Сохранить параметры";
            btnSaveParams.Click += btnSaveParams_Click;
            // 
            // btnLoadParams
            // 
            btnLoadParams.Name = "btnLoadParams";
            btnLoadParams.Size = new Size(315, 34);
            btnLoadParams.Text = "Загрузить параметры";
            btnLoadParams.Click += btnLoadParams_Click;
            // 
            // навигацияToolStripMenuItem
            // 
            навигацияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnGoLSystem, btnGoAnalysis });
            навигацияToolStripMenuItem.Name = "навигацияToolStripMenuItem";
            навигацияToolStripMenuItem.Size = new Size(116, 29);
            навигацияToolStripMenuItem.Text = "Навигация";
            // 
            // btnGoLSystem
            // 
            btnGoLSystem.Name = "btnGoLSystem";
            btnGoLSystem.Size = new Size(195, 34);
            btnGoLSystem.Text = " L- ситема";
            btnGoLSystem.Click += btnGoLSystem_Click;
            // 
            // btnGoAnalysis
            // 
            btnGoAnalysis.Name = "btnGoAnalysis";
            btnGoAnalysis.Size = new Size(195, 34);
            btnGoAnalysis.Text = "Анализ";
            btnGoAnalysis.Click += btnGoAnalysis_Click;
            // 
            // picBox
            // 
            picBox.BackColor = Color.White;
            picBox.BorderStyle = BorderStyle.FixedSingle;
            picBox.Dock = DockStyle.Fill;
            picBox.Location = new Point(441, 33);
            picBox.Name = "picBox";
            picBox.Size = new Size(1140, 829);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.TabIndex = 2;
            picBox.TabStop = false;
            // 
            // IFSForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1581, 862);
            Controls.Add(picBox);
            Controls.Add(panelLeft);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "IFSForm";
            Text = "Моделирование фракталов — IFS (Chaos Game)";
            FormClosed += IFSForm_FormClosed;
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            grpParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudIterations).EndInit();
            grpTransforms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransforms).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelLeft;
        private ComboBox cmbFractal;
        private Label label1;
        private GroupBox grpTransforms;
        private GroupBox grpParams;
        private NumericUpDown nudIterations;
        private Label label2;
        private Button btnRemoveRow;
        private Button btnAddRow;
        private DataGridView dgvTransforms;
        private Label lblColorInfo;
        private Button btnColor;
        private Label lblInfo;
        private Label lblTime;
        private Button btnBuild;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem навигацияToolStripMenuItem;
        private ToolStripMenuItem btnSaveImage;
        private ToolStripMenuItem btnSaveParams;
        private ToolStripMenuItem btnLoadParams;
        private ToolStripMenuItem btnGoLSystem;
        private ToolStripMenuItem btnGoAnalysis;
        private PictureBox picBox;
    }
}