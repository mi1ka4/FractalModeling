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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnBuild = new System.Windows.Forms.Button();
            this.lblColorInfo = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.grpRules = new System.Windows.Forms.GroupBox();
            this.btnClearRules = new System.Windows.Forms.Button();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.lstRules = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRuleProduction = new System.Windows.Forms.TextBox();
            this.txtRuleSymbol = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAxiom = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpStop = new System.Windows.Forms.GroupBox();
            this.nudIterations = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.grpInit = new System.Windows.Forms.GroupBox();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVariance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGrowth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStep = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFractal = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveParams = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadParams = new System.Windows.Forms.ToolStripMenuItem();
            this.навигацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGoIFS = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGoAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            this.grpRules.SuspendLayout();
            this.grpStop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).BeginInit();
            this.grpInit.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lblInfo);
            this.panelLeft.Controls.Add(this.lblTime);
            this.panelLeft.Controls.Add(this.btnBuild);
            this.panelLeft.Controls.Add(this.lblColorInfo);
            this.panelLeft.Controls.Add(this.btnColor);
            this.panelLeft.Controls.Add(this.grpRules);
            this.panelLeft.Controls.Add(this.grpStop);
            this.panelLeft.Controls.Add(this.grpInit);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Controls.Add(this.cmbFractal);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 33);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(309, 850);
            this.panelLeft.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(34, 804);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(53, 20);
            this.lblInfo.TabIndex = 10;
            this.lblInfo.Text = "Инфо";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(34, 775);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(58, 20);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "Время";
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(34, 736);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(242, 32);
            this.btnBuild.TabIndex = 8;
            this.btnBuild.Text = "▶ Построить";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // lblColorInfo
            // 
            this.lblColorInfo.AutoSize = true;
            this.lblColorInfo.Location = new System.Drawing.Point(33, 704);
            this.lblColorInfo.Name = "lblColorInfo";
            this.lblColorInfo.Size = new System.Drawing.Size(102, 20);
            this.lblColorInfo.TabIndex = 7;
            this.lblColorInfo.Text = "Цвет линий:";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Blue;
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Location = new System.Drawing.Point(156, 698);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(120, 32);
            this.btnColor.TabIndex = 6;
            this.btnColor.Text = "Цвет";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // grpRules
            // 
            this.grpRules.Controls.Add(this.btnClearRules);
            this.grpRules.Controls.Add(this.btnAddRule);
            this.grpRules.Controls.Add(this.lstRules);
            this.grpRules.Controls.Add(this.label9);
            this.grpRules.Controls.Add(this.txtRuleProduction);
            this.grpRules.Controls.Add(this.txtRuleSymbol);
            this.grpRules.Controls.Add(this.label8);
            this.grpRules.Controls.Add(this.txtAxiom);
            this.grpRules.Controls.Add(this.label7);
            this.grpRules.Location = new System.Drawing.Point(16, 368);
            this.grpRules.Name = "grpRules";
            this.grpRules.Size = new System.Drawing.Size(281, 321);
            this.grpRules.TabIndex = 5;
            this.grpRules.TabStop = false;
            this.grpRules.Text = "Правила";
            // 
            // btnClearRules
            // 
            this.btnClearRules.Location = new System.Drawing.Point(163, 140);
            this.btnClearRules.Name = "btnClearRules";
            this.btnClearRules.Size = new System.Drawing.Size(97, 36);
            this.btnClearRules.TabIndex = 10;
            this.btnClearRules.Text = "Очистить";
            this.btnClearRules.UseVisualStyleBackColor = true;
            this.btnClearRules.Click += new System.EventHandler(this.btnClearRules_Click);
            // 
            // btnAddRule
            // 
            this.btnAddRule.Location = new System.Drawing.Point(21, 140);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(97, 36);
            this.btnAddRule.TabIndex = 9;
            this.btnAddRule.Text = "Добавить";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // lstRules
            // 
            this.lstRules.FormattingEnabled = true;
            this.lstRules.HorizontalScrollbar = true;
            this.lstRules.ItemHeight = 20;
            this.lstRules.Location = new System.Drawing.Point(21, 219);
            this.lstRules.Name = "lstRules";
            this.lstRules.Size = new System.Drawing.Size(239, 84);
            this.lstRules.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(64, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "Множество правил";
            // 
            // txtRuleProduction
            // 
            this.txtRuleProduction.Location = new System.Drawing.Point(21, 99);
            this.txtRuleProduction.Name = "txtRuleProduction";
            this.txtRuleProduction.Size = new System.Drawing.Size(239, 26);
            this.txtRuleProduction.TabIndex = 6;
            this.txtRuleProduction.Text = "F+F--F+F";
            // 
            // txtRuleSymbol
            // 
            this.txtRuleSymbol.Location = new System.Drawing.Point(160, 61);
            this.txtRuleSymbol.MaxLength = 1;
            this.txtRuleSymbol.Name = "txtRuleSymbol";
            this.txtRuleSymbol.Size = new System.Drawing.Size(100, 26);
            this.txtRuleSymbol.TabIndex = 5;
            this.txtRuleSymbol.Text = "F";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(15, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Ввод правила";
            // 
            // txtAxiom
            // 
            this.txtAxiom.Location = new System.Drawing.Point(160, 29);
            this.txtAxiom.Name = "txtAxiom";
            this.txtAxiom.Size = new System.Drawing.Size(100, 26);
            this.txtAxiom.TabIndex = 3;
            this.txtAxiom.Text = "F";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(15, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Начальная строка";
            // 
            // grpStop
            // 
            this.grpStop.Controls.Add(this.nudIterations);
            this.grpStop.Controls.Add(this.label6);
            this.grpStop.Location = new System.Drawing.Point(16, 264);
            this.grpStop.Name = "grpStop";
            this.grpStop.Size = new System.Drawing.Size(281, 87);
            this.grpStop.TabIndex = 4;
            this.grpStop.TabStop = false;
            this.grpStop.Text = "Условия завершения";
            // 
            // nudIterations
            // 
            this.nudIterations.Location = new System.Drawing.Point(140, 35);
            this.nudIterations.Name = "nudIterations";
            this.nudIterations.Size = new System.Drawing.Size(120, 26);
            this.nudIterations.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(15, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 51);
            this.label6.TabIndex = 0;
            this.label6.Text = "Количество итераций";
            // 
            // grpInit
            // 
            this.grpInit.Controls.Add(this.txtAngle);
            this.grpInit.Controls.Add(this.label5);
            this.grpInit.Controls.Add(this.txtVariance);
            this.grpInit.Controls.Add(this.label4);
            this.grpInit.Controls.Add(this.txtGrowth);
            this.grpInit.Controls.Add(this.label3);
            this.grpInit.Controls.Add(this.txtStep);
            this.grpInit.Controls.Add(this.label2);
            this.grpInit.Location = new System.Drawing.Point(16, 58);
            this.grpInit.Name = "grpInit";
            this.grpInit.Size = new System.Drawing.Size(281, 200);
            this.grpInit.TabIndex = 3;
            this.grpInit.TabStop = false;
            this.grpInit.Text = "Начальные условия";
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(160, 164);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(100, 26);
            this.txtAngle.TabIndex = 7;
            this.txtAngle.Text = "90";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Угол";
            // 
            // txtVariance
            // 
            this.txtVariance.Location = new System.Drawing.Point(160, 110);
            this.txtVariance.Name = "txtVariance";
            this.txtVariance.Size = new System.Drawing.Size(100, 26);
            this.txtVariance.TabIndex = 5;
            this.txtVariance.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 45);
            this.label4.TabIndex = 4;
            this.label4.Text = "Дисперсия длины (%)";
            // 
            // txtGrowth
            // 
            this.txtGrowth.Location = new System.Drawing.Point(160, 67);
            this.txtGrowth.Name = "txtGrowth";
            this.txtGrowth.Size = new System.Drawing.Size(100, 26);
            this.txtGrowth.TabIndex = 3;
            this.txtGrowth.Text = "0";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 53);
            this.label3.TabIndex = 2;
            this.label3.Text = "Приращение длины (%)";
            // 
            // txtStep
            // 
            this.txtStep.Location = new System.Drawing.Point(160, 35);
            this.txtStep.Name = "txtStep";
            this.txtStep.Size = new System.Drawing.Size(100, 26);
            this.txtStep.TabIndex = 1;
            this.txtStep.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Длина отрезка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбор фрактала:";
            // 
            // cmbFractal
            // 
            this.cmbFractal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFractal.FormattingEnabled = true;
            this.cmbFractal.Location = new System.Drawing.Point(176, 15);
            this.cmbFractal.Name = "cmbFractal";
            this.cmbFractal.Size = new System.Drawing.Size(121, 28);
            this.cmbFractal.TabIndex = 1;
            this.cmbFractal.SelectedIndexChanged += new System.EventHandler(this.cmbFractal_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.навигацияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1430, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveImage,
            this.btnSaveParams,
            this.btnLoadParams});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(315, 34);
            this.btnSaveImage.Text = "Сохранить изображение";
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnSaveParams
            // 
            this.btnSaveParams.Name = "btnSaveParams";
            this.btnSaveParams.Size = new System.Drawing.Size(315, 34);
            this.btnSaveParams.Text = "Сохранить параметры";
            this.btnSaveParams.Click += new System.EventHandler(this.btnSaveParams_Click);
            // 
            // btnLoadParams
            // 
            this.btnLoadParams.Name = "btnLoadParams";
            this.btnLoadParams.Size = new System.Drawing.Size(315, 34);
            this.btnLoadParams.Text = "Загрузить параметры";
            this.btnLoadParams.Click += new System.EventHandler(this.btnLoadParams_Click);
            // 
            // навигацияToolStripMenuItem
            // 
            this.навигацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGoIFS,
            this.btnGoAnalysis});
            this.навигацияToolStripMenuItem.Name = "навигацияToolStripMenuItem";
            this.навигацияToolStripMenuItem.Size = new System.Drawing.Size(116, 29);
            this.навигацияToolStripMenuItem.Text = "Навигация";
            // 
            // btnGoIFS
            // 
            this.btnGoIFS.Name = "btnGoIFS";
            this.btnGoIFS.Size = new System.Drawing.Size(276, 34);
            this.btnGoIFS.Text = "▶ Перейти к IFS";
            this.btnGoIFS.Click += new System.EventHandler(this.btnGoIFS_Click);
            // 
            // btnGoAnalysis
            // 
            this.btnGoAnalysis.Name = "btnGoAnalysis";
            this.btnGoAnalysis.Size = new System.Drawing.Size(276, 34);
            this.btnGoAnalysis.Text = "Анализ результатов";
            this.btnGoAnalysis.Click += new System.EventHandler(this.btnGoAnalysis_Click);
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.Color.White;
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox.Location = new System.Drawing.Point(309, 33);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(1121, 850);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 2;
            this.picBox.TabStop = false;
            // 
            // LSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1430, 883);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "LSystemForm";
            this.Text = "Моделирование фракталов — L-система";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LSystemForm_FormClosed);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.grpRules.ResumeLayout(false);
            this.grpRules.PerformLayout();
            this.grpStop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).EndInit();
            this.grpInit.ResumeLayout(false);
            this.grpInit.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

