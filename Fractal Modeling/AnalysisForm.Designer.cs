namespace Fractal_Modeling
{
    partial class AnalysisForm
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
            panel1 = new Panel();
            btnExport = new Button();
            btnGoIFS = new Button();
            btnGoLSystem = new Button();
            label4 = new Label();
            cmbMethodFilter = new ComboBox();
            label3 = new Label();
            cmbFractalFilter = new ComboBox();
            label2 = new Label();
            btnRefresh = new Button();
            btnRemoveFile = new Button();
            btnAddFile = new Button();
            lstFiles = new ListBox();
            label1 = new Label();
            tabControl = new TabControl();
            tabTable = new TabPage();
            dgvResults = new DataGridView();
            tabH1 = new TabPage();
            panelH1Top = new Panel();
            radH1Memory = new RadioButton();
            radH1Time = new RadioButton();
            pnlH1 = new Panel();
            tabH2 = new TabPage();
            panelH2Left = new Panel();
            btnH2RemovePair = new Button();
            btnH2AddPair = new Button();
            lstH2Pairs = new ListBox();
            pnlH2 = new Panel();
            tabH3 = new TabPage();
            panelH3Top = new Panel();
            cmbH3Fractal = new ComboBox();
            label5 = new Label();
            pnlH3 = new Panel();
            tabSummary = new TabPage();
            rtbSummary = new RichTextBox();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            tabH1.SuspendLayout();
            panelH1Top.SuspendLayout();
            tabH2.SuspendLayout();
            panelH2Left.SuspendLayout();
            tabH3.SuspendLayout();
            panelH3Top.SuspendLayout();
            tabSummary.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExport);
            panel1.Controls.Add(btnGoIFS);
            panel1.Controls.Add(btnGoLSystem);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cmbMethodFilter);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbFractalFilter);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(btnRemoveFile);
            panel1.Controls.Add(btnAddFile);
            panel1.Controls.Add(lstFiles);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 694);
            panel1.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(22, 508);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(260, 34);
            btnExport.TabIndex = 12;
            btnExport.Text = "Экспорт статистики";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnGoIFS
            // 
            btnGoIFS.Location = new Point(22, 641);
            btnGoIFS.Name = "btnGoIFS";
            btnGoIFS.Size = new Size(260, 34);
            btnGoIFS.TabIndex = 11;
            btnGoIFS.Text = "◀ IFS";
            btnGoIFS.UseVisualStyleBackColor = true;
            btnGoIFS.Click += btnGoIFS_Click;
            // 
            // btnGoLSystem
            // 
            btnGoLSystem.Location = new Point(22, 595);
            btnGoLSystem.Name = "btnGoLSystem";
            btnGoLSystem.Size = new Size(260, 34);
            btnGoLSystem.TabIndex = 10;
            btnGoLSystem.Text = "◀ L-система";
            btnGoLSystem.UseVisualStyleBackColor = true;
            btnGoLSystem.Click += btnGoLSystem_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 560);
            label4.Name = "label4";
            label4.Size = new Size(100, 25);
            label4.TabIndex = 9;
            label4.Text = "Навигация";
            // 
            // cmbMethodFilter
            // 
            cmbMethodFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMethodFilter.FormattingEnabled = true;
            cmbMethodFilter.Location = new Point(22, 431);
            cmbMethodFilter.Name = "cmbMethodFilter";
            cmbMethodFilter.Size = new Size(260, 33);
            cmbMethodFilter.TabIndex = 8;
            cmbMethodFilter.SelectedIndexChanged += cmbMethodFilter_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 390);
            label3.Name = "label3";
            label3.Size = new Size(165, 25);
            label3.TabIndex = 7;
            label3.Text = "Фильтр по методу:\r\n";
            // 
            // cmbFractalFilter
            // 
            cmbFractalFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFractalFilter.FormattingEnabled = true;
            cmbFractalFilter.Location = new Point(22, 334);
            cmbFractalFilter.Name = "cmbFractalFilter";
            cmbFractalFilter.Size = new Size(260, 33);
            cmbFractalFilter.TabIndex = 6;
            cmbFractalFilter.SelectedIndexChanged += cmbFractalFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 293);
            label2.Name = "label2";
            label2.Size = new Size(146, 25);
            label2.TabIndex = 5;
            label2.Text = "Фильтр фрактал:";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(22, 238);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(260, 34);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnRemoveFile
            // 
            btnRemoveFile.Location = new Point(170, 184);
            btnRemoveFile.Name = "btnRemoveFile";
            btnRemoveFile.Size = new Size(112, 34);
            btnRemoveFile.TabIndex = 3;
            btnRemoveFile.Text = "Удалить";
            btnRemoveFile.UseVisualStyleBackColor = true;
            btnRemoveFile.Click += btnRemoveFile_Click;
            // 
            // btnAddFile
            // 
            btnAddFile.Location = new Point(22, 184);
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Size = new Size(112, 34);
            btnAddFile.TabIndex = 2;
            btnAddFile.Text = "Добавить";
            btnAddFile.UseVisualStyleBackColor = true;
            btnAddFile.Click += btnAddFile_Click;
            // 
            // lstFiles
            // 
            lstFiles.FormattingEnabled = true;
            lstFiles.ItemHeight = 25;
            lstFiles.Location = new Point(22, 63);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new Size(260, 104);
            lstFiles.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 26);
            label1.Name = "label1";
            label1.Size = new Size(174, 25);
            label1.TabIndex = 0;
            label1.Text = "Файлы результатов:";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabTable);
            tabControl.Controls.Add(tabH1);
            tabControl.Controls.Add(tabH2);
            tabControl.Controls.Add(tabH3);
            tabControl.Controls.Add(tabSummary);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(300, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(878, 694);
            tabControl.TabIndex = 1;
            // 
            // tabTable
            // 
            tabTable.Controls.Add(dgvResults);
            tabTable.Location = new Point(4, 34);
            tabTable.Name = "tabTable";
            tabTable.Padding = new Padding(3);
            tabTable.Size = new Size(870, 656);
            tabTable.TabIndex = 0;
            tabTable.Text = "Таблица";
            tabTable.UseVisualStyleBackColor = true;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.Location = new Point(3, 3);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersWidth = 62;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(864, 650);
            dgvResults.TabIndex = 0;
            // 
            // tabH1
            // 
            tabH1.Controls.Add(pnlH1);
            tabH1.Controls.Add(panelH1Top);
            tabH1.Location = new Point(4, 34);
            tabH1.Name = "tabH1";
            tabH1.Padding = new Padding(3);
            tabH1.Size = new Size(870, 656);
            tabH1.TabIndex = 1;
            tabH1.Text = "H1: T(n)";
            tabH1.UseVisualStyleBackColor = true;
            // 
            // panelH1Top
            // 
            panelH1Top.Controls.Add(radH1Memory);
            panelH1Top.Controls.Add(radH1Time);
            panelH1Top.Dock = DockStyle.Top;
            panelH1Top.Location = new Point(3, 3);
            panelH1Top.Name = "panelH1Top";
            panelH1Top.Size = new Size(864, 32);
            panelH1Top.TabIndex = 1;
            // 
            // radH1Memory
            // 
            radH1Memory.AutoSize = true;
            radH1Memory.Location = new Point(467, 0);
            radH1Memory.Name = "radH1Memory";
            radH1Memory.Size = new Size(141, 29);
            radH1Memory.TabIndex = 1;
            radH1Memory.TabStop = true;
            radH1Memory.Text = "radioButton2";
            radH1Memory.UseVisualStyleBackColor = true;
            // 
            // radH1Time
            // 
            radH1Time.AutoSize = true;
            radH1Time.Location = new Point(24, 1);
            radH1Time.Name = "radH1Time";
            radH1Time.Size = new Size(141, 29);
            radH1Time.TabIndex = 0;
            radH1Time.TabStop = true;
            radH1Time.Text = "radioButton1";
            radH1Time.UseVisualStyleBackColor = true;
            // 
            // pnlH1
            // 
            pnlH1.BackColor = Color.White;
            pnlH1.Dock = DockStyle.Fill;
            pnlH1.Location = new Point(3, 35);
            pnlH1.Name = "pnlH1";
            pnlH1.Size = new Size(864, 618);
            pnlH1.TabIndex = 0;
            // 
            // tabH2
            // 
            tabH2.Controls.Add(pnlH2);
            tabH2.Controls.Add(panelH2Left);
            tabH2.Location = new Point(4, 34);
            tabH2.Name = "tabH2";
            tabH2.Size = new Size(870, 656);
            tabH2.TabIndex = 3;
            tabH2.Text = "H2: Память";
            tabH2.UseVisualStyleBackColor = true;
            // 
            // panelH2Left
            // 
            panelH2Left.Controls.Add(btnH2RemovePair);
            panelH2Left.Controls.Add(btnH2AddPair);
            panelH2Left.Controls.Add(lstH2Pairs);
            panelH2Left.Dock = DockStyle.Left;
            panelH2Left.Location = new Point(0, 0);
            panelH2Left.Name = "panelH2Left";
            panelH2Left.Size = new Size(200, 656);
            panelH2Left.TabIndex = 1;
            // 
            // btnH2RemovePair
            // 
            btnH2RemovePair.Location = new Point(16, 284);
            btnH2RemovePair.Name = "btnH2RemovePair";
            btnH2RemovePair.Size = new Size(174, 34);
            btnH2RemovePair.TabIndex = 2;
            btnH2RemovePair.Text = "Удалить пару";
            btnH2RemovePair.UseVisualStyleBackColor = true;
            btnH2RemovePair.Click += btnH2RemovePair_Click;
            // 
            // btnH2AddPair
            // 
            btnH2AddPair.Location = new Point(16, 209);
            btnH2AddPair.Name = "btnH2AddPair";
            btnH2AddPair.Size = new Size(174, 59);
            btnH2AddPair.TabIndex = 1;
            btnH2AddPair.Text = "Добавить пару файлов";
            btnH2AddPair.UseVisualStyleBackColor = true;
            btnH2AddPair.Click += btnH2AddPair_Click;
            // 
            // lstH2Pairs
            // 
            lstH2Pairs.FormattingEnabled = true;
            lstH2Pairs.ItemHeight = 25;
            lstH2Pairs.Location = new Point(10, 15);
            lstH2Pairs.Name = "lstH2Pairs";
            lstH2Pairs.Size = new Size(180, 179);
            lstH2Pairs.TabIndex = 0;
            // 
            // pnlH2
            // 
            pnlH2.BackColor = Color.White;
            pnlH2.Dock = DockStyle.Fill;
            pnlH2.Location = new Point(200, 0);
            pnlH2.Name = "pnlH2";
            pnlH2.Size = new Size(670, 656);
            pnlH2.TabIndex = 0;
            // 
            // tabH3
            // 
            tabH3.Controls.Add(pnlH3);
            tabH3.Controls.Add(panelH3Top);
            tabH3.Location = new Point(4, 34);
            tabH3.Name = "tabH3";
            tabH3.Size = new Size(870, 656);
            tabH3.TabIndex = 4;
            tabH3.Text = "H3: D";
            tabH3.UseVisualStyleBackColor = true;
            // 
            // panelH3Top
            // 
            panelH3Top.Controls.Add(cmbH3Fractal);
            panelH3Top.Controls.Add(label5);
            panelH3Top.Dock = DockStyle.Top;
            panelH3Top.Location = new Point(0, 0);
            panelH3Top.Name = "panelH3Top";
            panelH3Top.Size = new Size(870, 36);
            panelH3Top.TabIndex = 1;
            // 
            // cmbH3Fractal
            // 
            cmbH3Fractal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbH3Fractal.FormattingEnabled = true;
            cmbH3Fractal.Location = new Point(127, 2);
            cmbH3Fractal.Name = "cmbH3Fractal";
            cmbH3Fractal.Size = new Size(182, 33);
            cmbH3Fractal.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 3);
            label5.Name = "label5";
            label5.Size = new Size(83, 25);
            label5.TabIndex = 0;
            label5.Text = "Фрактал:";
            // 
            // pnlH3
            // 
            pnlH3.BackColor = Color.White;
            pnlH3.Dock = DockStyle.Fill;
            pnlH3.Location = new Point(0, 36);
            pnlH3.Name = "pnlH3";
            pnlH3.Size = new Size(870, 620);
            pnlH3.TabIndex = 0;
            // 
            // tabSummary
            // 
            tabSummary.Controls.Add(rtbSummary);
            tabSummary.Location = new Point(4, 34);
            tabSummary.Name = "tabSummary";
            tabSummary.Size = new Size(870, 656);
            tabSummary.TabIndex = 2;
            tabSummary.Text = "Статистика";
            tabSummary.UseVisualStyleBackColor = true;
            // 
            // rtbSummary
            // 
            rtbSummary.Dock = DockStyle.Fill;
            rtbSummary.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rtbSummary.Location = new Point(0, 0);
            rtbSummary.Name = "rtbSummary";
            rtbSummary.ReadOnly = true;
            rtbSummary.Size = new Size(870, 656);
            rtbSummary.TabIndex = 0;
            rtbSummary.Text = "";
            // 
            // AnalysisForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 694);
            Controls.Add(tabControl);
            Controls.Add(panel1);
            Name = "AnalysisForm";
            Text = "Анализ результатов";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            tabH1.ResumeLayout(false);
            panelH1Top.ResumeLayout(false);
            panelH1Top.PerformLayout();
            tabH2.ResumeLayout(false);
            panelH2Left.ResumeLayout(false);
            tabH3.ResumeLayout(false);
            panelH3Top.ResumeLayout(false);
            panelH3Top.PerformLayout();
            tabSummary.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ListBox lstFiles;
        private Label label1;
        private Button btnRemoveFile;
        private Button btnAddFile;
        private Button btnRefresh;
        private ComboBox cmbFractalFilter;
        private Label label2;
        private ComboBox cmbMethodFilter;
        private Label label3;
        private Button btnGoIFS;
        private Button btnGoLSystem;
        private Label label4;
        private TabControl tabControl;
        private TabPage tabTable;
        private TabPage tabH1;
        private Button btnExport;
        private DataGridView dgvResults;
        private Panel pnlH1;
        private TabPage tabSummary;
        private RichTextBox rtbSummary;
        private TabPage tabH2;
        private TabPage tabH3;
        private Panel pnlH2;
        private Panel pnlH3;
        private Panel panelH2Left;
        private Button btnH2RemovePair;
        private Button btnH2AddPair;
        private ListBox lstH2Pairs;
        private Panel panelH1Top;
        private RadioButton radH1Memory;
        private RadioButton radH1Time;
        private Panel panelH3Top;
        private ComboBox cmbH3Fractal;
        private Label label5;
    }
}