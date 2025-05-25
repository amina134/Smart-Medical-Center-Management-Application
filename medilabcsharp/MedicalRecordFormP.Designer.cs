namespace medilabcsharp
{
    partial class MedicalRecordFormP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Add these control declarations ▼
        private System.Windows.Forms.DataGridView dataGridViewMedicalRecords;
        private System.Windows.Forms.Button btnClose;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            dataGridViewMedicalRecords = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMedicalRecords).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMedicalRecords
            // 
            dataGridViewMedicalRecords.AllowUserToAddRows = false;
            dataGridViewMedicalRecords.AllowUserToDeleteRows = false;
            dataGridViewMedicalRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMedicalRecords.Dock = DockStyle.Fill;
            dataGridViewMedicalRecords.Location = new Point(0, 0);
            dataGridViewMedicalRecords.Margin = new Padding(4, 3, 4, 3);
            dataGridViewMedicalRecords.Name = "dataGridViewMedicalRecords";
            dataGridViewMedicalRecords.ReadOnly = true;
            dataGridViewMedicalRecords.Size = new Size(933, 519);
            dataGridViewMedicalRecords.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(832, 479);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 27);
            btnClose.TabIndex = 1;
            btnClose.Text = "Fermer";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // MedicalRecordFormP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(btnClose);
            Controls.Add(dataGridViewMedicalRecords);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MedicalRecordFormP";
            Text = "Dossier Médical";
            Load += MedicalRecordFormP_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMedicalRecords).EndInit();
            ResumeLayout(false);

        }
        #endregion
    }
}