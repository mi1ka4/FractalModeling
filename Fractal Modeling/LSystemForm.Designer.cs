namespace FractalModeling
{
    partial class LSystemForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            panelLeft = new Panel();
            btnCancel = new Button();
            lblInfo = new Label();
            lblTime = new Label();
            btnBuild = new Button();
            lblColorInfo = new Label();
            btnColor = new Button();
            grpRules = new GroupBox();
            btnClearRules = new Button();
            btnAddRule = new Button();
            lstRules = new ListBox();
            label9 = new Label();
            txtRuleProduction = new TextBox();
            txtRuleSymbol = new TextBox();
            label8 = new Label();
            txtAxiom = new TextBox();
            label7 = new Label();
            grpStop = new GroupBox();
            nudIterations = new NumericUpDown();
            label6 = new Label();
            grpInit = new GroupBox();
            txtAngle = new TextBox();
            label5 = new Label();
            txtVariance = new TextBox();
            label4 = new Label();
            txtGrowth = new TextBox();
            label3 = new Label();
            txtStep = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cmbFractal = new ComboBox();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            btnSaveImage = new ToolStripMenuItem();
            btnSaveParams = new ToolStripMenuItem();
            btnLoadParams = new ToolStripMenuItem();
            навигацияToolStripMenuItem = new ToolStripMenuItem();
            btnGoIFS = new ToolStripMenuItem();
            btnGoAnalysis = new ToolStripMenuItem();
            picBox = new PictureBox();
            progressBar = new ProgressBar();
            panelLeft.SuspendLayout();
            grpRules.SuspendLayout();
            grpStop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudIterations).BeginInit();
            grpInit.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(btnCancel);
            panelLeft.Controls.Add(lblInfo);
            panelLeft.Controls.Add(lblTime);
            panelLeft.Controls.Add(btnBuild);
            panelLeft.Controls.Add(lblColorInfo);
            panelLeft.Controls.Add(btnColor);
            panelLeft.Controls.Add(grpRules);
            panelLeft.Controls.Add(grpStop);
            panelLeft.Controls.Add(grpInit);
            panelLeft.Controls.Add(label1);
            panelLeft.Controls.Add(cmbFractal);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 33);
            panelLeft.Margin = new Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(343, 1071);
            panelLeft.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(180, 920);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(126, 40);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(38, 1005);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(269, 57);
            lblInfo.TabIndex = 10;
            lblInfo.Text = "Инфо";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(38, 969);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(64, 25);
            lblTime.TabIndex = 9;
            lblTime.Text = "Время";
            // 
            // btnBuild
            // 
            btnBuild.Location = new Point(38, 920);
            btnBuild.Margin = new Padding(3, 4, 3, 4);
            btnBuild.Name = "btnBuild";
            btnBuild.Size = new Size(136, 40);
            btnBuild.TabIndex = 8;
            btnBuild.Text = "▶ Построить";
            btnBuild.UseVisualStyleBackColor = true;
            btnBuild.Click += btnBuild_Click;
            // 
            // lblColorInfo
            // 
            lblColorInfo.AutoSize = true;
            lblColorInfo.Location = new Point(37, 880);
            lblColorInfo.Name = "lblColorInfo";
            lblColorInfo.Size = new Size(109, 25);
            lblColorInfo.TabIndex = 7;
            lblColorInfo.Text = "Цвет линий:";
            // 
            // btnColor
            // 
            btnColor.BackColor = Color.Blue;
            btnColor.ForeColor = Color.White;
            btnColor.Location = new Point(173, 872);
            btnColor.Margin = new Padding(3, 4, 3, 4);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(133, 40);
            btnColor.TabIndex = 6;
            btnColor.Text = "Цвет";
            btnColor.UseVisualStyleBackColor = false;
            btnColor.Click += btnColor_Click;
            // 
            // grpRules
            // 
            grpRules.Controls.Add(btnClearRules);
            grpRules.Controls.Add(btnAddRule);
            grpRules.Controls.Add(lstRules);
            grpRules.Controls.Add(label9);
            grpRules.Controls.Add(txtRuleProduction);
            grpRules.Controls.Add(txtRuleSymbol);
            grpRules.Controls.Add(label8);
            grpRules.Controls.Add(txtAxiom);
            grpRules.Controls.Add(label7);
            grpRules.Location = new Point(18, 460);
            grpRules.Margin = new Padding(3, 4, 3, 4);
            grpRules.Name = "grpRules";
            grpRules.Padding = new Padding(3, 4, 3, 4);
            grpRules.Size = new Size(312, 401);
            grpRules.TabIndex = 5;
            grpRules.TabStop = false;
            grpRules.Text = "Правила";
            // 
            // btnClearRules
            // 
            btnClearRules.Location = new Point(181, 175);
            btnClearRules.Margin = new Padding(3, 4, 3, 4);
            btnClearRules.Name = "btnClearRules";
            btnClearRules.Size = new Size(108, 45);
            btnClearRules.TabIndex = 10;
            btnClearRules.Text = "Очистить";
            btnClearRules.UseVisualStyleBackColor = true;
            btnClearRules.Click += btnClearRules_Click;
            // 
            // btnAddRule
            // 
            btnAddRule.Location = new Point(23, 175);
            btnAddRule.Margin = new Padding(3, 4, 3, 4);
            btnAddRule.Name = "btnAddRule";
            btnAddRule.Size = new Size(108, 45);
            btnAddRule.TabIndex = 9;
            btnAddRule.Text = "Добавить";
            btnAddRule.UseVisualStyleBackColor = true;
            btnAddRule.Click += btnAddRule_Click;
            // 
            // lstRules
            // 
            lstRules.FormattingEnabled = true;
            lstRules.HorizontalScrollbar = true;
            lstRules.ItemHeight = 25;
            lstRules.Location = new Point(23, 274);
            lstRules.Margin = new Padding(3, 4, 3, 4);
            lstRules.Name = "lstRules";
            lstRules.Size = new Size(265, 104);
            lstRules.TabIndex = 8;
            // 
            // label9
            // 
            label9.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new Point(71, 239);
            label9.Name = "label9";
            label9.Size = new Size(172, 31);
            label9.TabIndex = 7;
            label9.Text = "Множество правил";
            // 
            // txtRuleProduction
            // 
            txtRuleProduction.Location = new Point(23, 124);
            txtRuleProduction.Margin = new Padding(3, 4, 3, 4);
            txtRuleProduction.Name = "txtRuleProduction";
            txtRuleProduction.Size = new Size(265, 31);
            txtRuleProduction.TabIndex = 6;
            txtRuleProduction.Text = "F+F--F+F";
            // 
            // txtRuleSymbol
            // 
            txtRuleSymbol.Location = new Point(178, 76);
            txtRuleSymbol.Margin = new Padding(3, 4, 3, 4);
            txtRuleSymbol.MaxLength = 1;
            txtRuleSymbol.Name = "txtRuleSymbol";
            txtRuleSymbol.Size = new Size(111, 31);
            txtRuleSymbol.TabIndex = 5;
            txtRuleSymbol.Text = "F";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(17, 80);
            label8.Name = "label8";
            label8.Size = new Size(117, 20);
            label8.TabIndex = 4;
            label8.Text = "Ввод правила";
            // 
            // txtAxiom
            // 
            txtAxiom.Location = new Point(178, 36);
            txtAxiom.Margin = new Padding(3, 4, 3, 4);
            txtAxiom.Name = "txtAxiom";
            txtAxiom.Size = new Size(111, 31);
            txtAxiom.TabIndex = 3;
            txtAxiom.Text = "F";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(17, 40);
            label7.Name = "label7";
            label7.Size = new Size(130, 17);
            label7.TabIndex = 2;
            label7.Text = "Начальная строка";
            // 
            // grpStop
            // 
            grpStop.Controls.Add(nudIterations);
            grpStop.Controls.Add(label6);
            grpStop.Location = new Point(18, 330);
            grpStop.Margin = new Padding(3, 4, 3, 4);
            grpStop.Name = "grpStop";
            grpStop.Padding = new Padding(3, 4, 3, 4);
            grpStop.Size = new Size(312, 109);
            grpStop.TabIndex = 4;
            grpStop.TabStop = false;
            grpStop.Text = "Условия завершения";
            // 
            // nudIterations
            // 
            nudIterations.Location = new Point(156, 44);
            nudIterations.Margin = new Padding(3, 4, 3, 4);
            nudIterations.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudIterations.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudIterations.Name = "nudIterations";
            nudIterations.Size = new Size(133, 31);
            nudIterations.TabIndex = 1;
            nudIterations.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label6
            // 
            label6.Location = new Point(17, 32);
            label6.Name = "label6";
            label6.Size = new Size(114, 64);
            label6.TabIndex = 0;
            label6.Text = "Количество итераций";
            // 
            // grpInit
            // 
            grpInit.Controls.Add(txtAngle);
            grpInit.Controls.Add(label5);
            grpInit.Controls.Add(txtVariance);
            grpInit.Controls.Add(label4);
            grpInit.Controls.Add(txtGrowth);
            grpInit.Controls.Add(label3);
            grpInit.Controls.Add(txtStep);
            grpInit.Controls.Add(label2);
            grpInit.Location = new Point(18, 72);
            grpInit.Margin = new Padding(3, 4, 3, 4);
            grpInit.Name = "grpInit";
            grpInit.Padding = new Padding(3, 4, 3, 4);
            grpInit.Size = new Size(312, 250);
            grpInit.TabIndex = 3;
            grpInit.TabStop = false;
            grpInit.Text = "Начальные условия";
            // 
            // txtAngle
            // 
            txtAngle.Location = new Point(178, 205);
            txtAngle.Margin = new Padding(3, 4, 3, 4);
            txtAngle.Name = "txtAngle";
            txtAngle.Size = new Size(111, 31);
            txtAngle.TabIndex = 7;
            txtAngle.Text = "90";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 205);
            label5.Name = "label5";
            label5.Size = new Size(49, 25);
            label5.TabIndex = 6;
            label5.Text = "Угол";
            // 
            // txtVariance
            // 
            txtVariance.Location = new Point(178, 138);
            txtVariance.Margin = new Padding(3, 4, 3, 4);
            txtVariance.Name = "txtVariance";
            txtVariance.Size = new Size(111, 31);
            txtVariance.TabIndex = 5;
            txtVariance.Text = "0";
            // 
            // label4
            // 
            label4.Location = new Point(19, 138);
            label4.Name = "label4";
            label4.Size = new Size(137, 56);
            label4.TabIndex = 4;
            label4.Text = "Дисперсия длины (%)";
            // 
            // txtGrowth
            // 
            txtGrowth.Location = new Point(178, 84);
            txtGrowth.Margin = new Padding(3, 4, 3, 4);
            txtGrowth.Name = "txtGrowth";
            txtGrowth.Size = new Size(111, 31);
            txtGrowth.TabIndex = 3;
            txtGrowth.Text = "0";
            // 
            // label3
            // 
            label3.Location = new Point(19, 84);
            label3.Name = "label3";
            label3.Size = new Size(143, 66);
            label3.TabIndex = 2;
            label3.Text = "Приращение длины (%)";
            // 
            // txtStep
            // 
            txtStep.Location = new Point(178, 44);
            txtStep.Margin = new Padding(3, 4, 3, 4);
            txtStep.Name = "txtStep";
            txtStep.Size = new Size(111, 31);
            txtStep.TabIndex = 1;
            txtStep.Text = "1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 44);
            label2.Name = "label2";
            label2.Size = new Size(131, 25);
            label2.TabIndex = 0;
            label2.Text = "Длина отрезка";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 22);
            label1.Name = "label1";
            label1.Size = new Size(151, 25);
            label1.TabIndex = 2;
            label1.Text = "Выбор фрактала:";
            // 
            // cmbFractal
            // 
            cmbFractal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFractal.FormattingEnabled = true;
            cmbFractal.Location = new Point(196, 19);
            cmbFractal.Margin = new Padding(3, 4, 3, 4);
            cmbFractal.Name = "cmbFractal";
            cmbFractal.Size = new Size(134, 33);
            cmbFractal.TabIndex = 1;
            cmbFractal.SelectedIndexChanged += cmbFractal_SelectedIndexChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, навигацияToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1589, 33);
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
            навигацияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnGoIFS, btnGoAnalysis });
            навигацияToolStripMenuItem.Name = "навигацияToolStripMenuItem";
            навигацияToolStripMenuItem.Size = new Size(116, 29);
            навигацияToolStripMenuItem.Text = "Навигация";
            // 
            // btnGoIFS
            // 
            btnGoIFS.Name = "btnGoIFS";
            btnGoIFS.Size = new Size(276, 34);
            btnGoIFS.Text = "▶ Перейти к IFS";
            btnGoIFS.Click += btnGoIFS_Click;
            // 
            // btnGoAnalysis
            // 
            btnGoAnalysis.Name = "btnGoAnalysis";
            btnGoAnalysis.Size = new Size(276, 34);
            btnGoAnalysis.Text = "Анализ результатов";
            btnGoAnalysis.Click += btnGoAnalysis_Click;
            // 
            // picBox
            // 
            picBox.BackColor = Color.White;
            picBox.BorderStyle = BorderStyle.FixedSingle;
            picBox.Dock = DockStyle.Fill;
            picBox.Location = new Point(343, 33);
            picBox.Margin = new Padding(3, 4, 3, 4);
            picBox.Name = "picBox";
            picBox.Size = new Size(1246, 1071);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.TabIndex = 2;
            picBox.TabStop = false;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(361, 1058);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(211, 34);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 12;
            progressBar.Visible = false;
            // 
            // LSystemForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1589, 1104);
            Controls.Add(progressBar);
            Controls.Add(picBox);
            Controls.Add(panelLeft);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(998, 736);
            Name = "LSystemForm";
            Text = "Моделирование фракталов — L-система";
            FormClosed += LSystemForm_FormClosed;
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            grpRules.ResumeLayout(false);
            grpRules.PerformLayout();
            grpStop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudIterations).EndInit();
            grpInit.ResumeLayout(false);
            grpInit.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFractal;
        private System.Windows.Forms.GroupBox grpInit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVariance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGrowth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStep;
        private System.Windows.Forms.GroupBox grpStop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudIterations;
        private System.Windows.Forms.GroupBox grpRules;
        private System.Windows.Forms.TextBox txtRuleSymbol;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAxiom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstRules;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRuleProduction;
        private System.Windows.Forms.Button btnClearRules;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.Label lblColorInfo;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSaveImage;
        private System.Windows.Forms.ToolStripMenuItem btnSaveParams;
        private System.Windows.Forms.ToolStripMenuItem btnLoadParams;
        private System.Windows.Forms.ToolStripMenuItem навигацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnGoIFS;
        private System.Windows.Forms.ToolStripMenuItem btnGoAnalysis;
        private System.Windows.Forms.PictureBox picBox;
        private Button btnCancel;
        private ProgressBar progressBar;
    }
}

