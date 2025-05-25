namespace MedicalCenter
{
    partial class StatisticsForm
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
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            btnGenerate = new Button();
            dgvDoctorStats = new DataGridView();
            cmbSpecialty = new ComboBox();
            btnFilter = new Button();
            btnExportPDF = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDoctorStats).BeginInit();
            SuspendLayout();
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(23, 23);
            dtpStartDate.Margin = new Padding(4, 3, 4, 3);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(233, 23);
            dtpStartDate.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(280, 23);
            dtpEndDate.Margin = new Padding(4, 3, 4, 3);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(233, 23);
            dtpEndDate.TabIndex = 1;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(537, 21);
            btnGenerate.Margin = new Padding(4, 3, 4, 3);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(117, 27);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Generate Stats";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // dgvDoctorStats
            // 
            dgvDoctorStats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvDoctorStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoctorStats.Location = new Point(23, 69);
            dgvDoctorStats.Margin = new Padding(4, 3, 4, 3);
            dgvDoctorStats.Name = "dgvDoctorStats";
            dgvDoctorStats.Size = new Size(524, 180);
            dgvDoctorStats.TabIndex = 3;
            // 
            // cmbSpecialty
            // 
            cmbSpecialty.FormattingEnabled = true;
            cmbSpecialty.Location = new Point(23, 272);
            cmbSpecialty.Margin = new Padding(4, 3, 4, 3);
            cmbSpecialty.Name = "cmbSpecialty";
            cmbSpecialty.Size = new Size(233, 23);
            cmbSpecialty.TabIndex = 4;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(280, 269);
            btnFilter.Margin = new Padding(4, 3, 4, 3);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(88, 27);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnExportPDF
            // 
            btnExportPDF.Location = new Point(397, 269);
            btnExportPDF.Margin = new Padding(4, 3, 4, 3);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(117, 27);
            btnExportPDF.TabIndex = 6;
            btnExportPDF.Text = "Export to PDF";
            btnExportPDF.UseVisualStyleBackColor = true;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGoldenrodYellow;
            button1.Location = new Point(904, 85);
            button1.Name = "button1";
            button1.Size = new Size(117, 38);
            button1.TabIndex = 7;
            button1.Text = "Home";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1033, 715);
            Controls.Add(button1);
            Controls.Add(btnExportPDF);
            Controls.Add(btnFilter);
            Controls.Add(cmbSpecialty);
            Controls.Add(dgvDoctorStats);
            Controls.Add(btnGenerate);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Margin = new Padding(4, 3, 4, 3);
            Name = "StatisticsForm";
            Text = "Medical Center Statistics";
            Load += StatisticsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDoctorStats).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dgvDoctorStats;
        private System.Windows.Forms.ComboBox cmbSpecialty;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartConsultations;
        private Button button1;
    }
}