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
            cmbMetric = new ComboBox();
            label3 = new Label();
            cmbFilter = new ComboBox();
            label2 = new Label();
            btnRefresh = new Button();
            btnRemoveFile = new Button();
            btnAddFile = new Button();
            lstFiles = new ListBox();
            label1 = new Label();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            dgvResults = new DataGridView();
            tabPage2 = new TabPage();
            pnlChart = new Panel();
            tabPage3 = new TabPage();
            rtbSummary = new RichTextBox();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExport);
            panel1.Controls.Add(btnGoIFS);
            panel1.Controls.Add(btnGoLSystem);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cmbMetric);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbFilter);
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
            // cmbMetric
            // 
            cmbMetric.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetric.FormattingEnabled = true;
            cmbMetric.Location = new Point(22, 431);
            cmbMetric.Name = "cmbMetric";
            cmbMetric.Size = new Size(260, 33);
            cmbMetric.TabIndex = 8;
            cmbMetric.SelectedIndexChanged += cmbMetric_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 390);
            label3.Name = "label3";
            label3.Size = new Size(192, 25);
            label3.TabIndex = 7;
            label3.Text = "Метрика для графика:";
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(22, 334);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(260, 33);
            cmbFilter.TabIndex = 6;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 293);
            label2.Name = "label2";
            label2.Size = new Size(165, 25);
            label2.TabIndex = 5;
            label2.Text = "Фильтр по методу:";
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
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Controls.Add(tabPage3);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(300, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(878, 694);
            tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvResults);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(870, 656);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Таблица";
            tabPage1.UseVisualStyleBackColor = true;
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
            // tabPage2
            // 
            tabPage2.Controls.Add(pnlChart);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(870, 656);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "График";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlChart
            // 
            pnlChart.BackColor = Color.White;
            pnlChart.Dock = DockStyle.Fill;
            pnlChart.Location = new Point(3, 3);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new Size(864, 650);
            pnlChart.TabIndex = 0;
            pnlChart.Paint += pnlChart_Paint;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(rtbSummary);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(870, 656);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Статистика";
            tabPage3.UseVisualStyleBackColor = true;
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
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ListBox lstFiles;
        private Label label1;
        private Button btnRemoveFile;
        private Button btnAddFile;
        private Button btnRefresh;
        private ComboBox cmbFilter;
        private Label label2;
        private ComboBox cmbMetric;
        private Label label3;
        private Button btnGoIFS;
        private Button btnGoLSystem;
        private Label label4;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnExport;
        private DataGridView dgvResults;
        private Panel pnlChart;
        private TabPage tabPage3;
        private RichTextBox rtbSummary;
    }
}