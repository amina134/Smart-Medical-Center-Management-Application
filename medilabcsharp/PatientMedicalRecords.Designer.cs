using System.Resources;

namespace medilabcsharp
{
    partial class PatientMedicalRecords
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
            dataGridViewDocuments = new DataGridView();
            btnViewDocument = new Button();
            label1 = new Label();
            label2 = new Label();
            lblPatientName = new Label();
            lblPatientEmail = new Label();
            label3 = new Label();
            dataGridViewRecords = new DataGridView();
            addDocument = new Button();
            btnDeleteRecord = new Button();
      
            btnAddRecord = new Button();
            btnDeleteDocument = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDocuments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecords).BeginInit();
            SuspendLayout();
            // 

            // gifBackground
            // 
         

            // dataGridViewDocuments
            // 
            dataGridViewDocuments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDocuments.Location = new Point(239, 353);
            dataGridViewDocuments.Name = "dataGridViewDocuments";
            dataGridViewDocuments.Size = new Size(635, 181);
            dataGridViewDocuments.TabIndex = 0;
            // 
            // btnViewDocument
            // 
            btnViewDocument.Location = new Point(17, 353);
            btnViewDocument.Name = "btnViewDocument";
            btnViewDocument.Size = new Size(204, 44);
            btnViewDocument.TabIndex = 1;
            btnViewDocument.Text = "ViewDocument";
            btnViewDocument.UseVisualStyleBackColor = true;
            btnViewDocument.Click += btnViewDocument_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(331, 22);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 2;
            label1.Text = "PATIENT RECORDS ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(320, 59);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 3;
            label2.Text = " Patient:";
            label2.Click += label2_Click;
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Location = new Point(406, 59);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(0, 15);
            lblPatientName.TabIndex = 4;
            // 
            // lblPatientEmail
            // 
            lblPatientEmail.AutoSize = true;
            lblPatientEmail.Location = new Point(396, 85);
            lblPatientEmail.Name = "lblPatientEmail";
            lblPatientEmail.Size = new Size(38, 15);
            lblPatientEmail.TabIndex = 5;
            lblPatientEmail.Text = "label3";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(331, 85);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 6;
            label3.Text = "Email:";
            // 
            // dataGridViewRecords
            // 
            dataGridViewRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRecords.Location = new Point(239, 137);
            dataGridViewRecords.Name = "dataGridViewRecords";
            dataGridViewRecords.Size = new Size(635, 193);
            dataGridViewRecords.TabIndex = 7;
            // 
            // addDocument
            // 
            addDocument.Location = new Point(17, 403);
            addDocument.Name = "addDocument";
            addDocument.Size = new Size(204, 44);
            addDocument.TabIndex = 8;
            addDocument.Text = "addDocument";
            addDocument.UseVisualStyleBackColor = true;
            addDocument.Click += addDocument_Click;
            // 
            // btnDeleteRecord
            // 
            btnDeleteRecord.Location = new Point(17, 174);
            btnDeleteRecord.Name = "btnDeleteRecord";
            btnDeleteRecord.Size = new Size(199, 47);
            btnDeleteRecord.TabIndex = 9;
            btnDeleteRecord.Text = "Delete Record";
            btnDeleteRecord.UseVisualStyleBackColor = true;
            btnDeleteRecord.Click += btnDeleteRecord_Click;
            // 
            // btnAddRecord
            // 
            btnAddRecord.Location = new Point(17, 227);
            btnAddRecord.Name = "btnAddRecord";
            btnAddRecord.Size = new Size(199, 47);
            btnAddRecord.TabIndex = 10;
            btnAddRecord.Text = "Add Record";
            btnAddRecord.UseVisualStyleBackColor = true;
            btnAddRecord.Click += btnAddRecord_Click;
            // 
            // btnDeleteDocument
            // 
            btnDeleteDocument.Location = new Point(17, 453);
            btnDeleteDocument.Name = "btnDeleteDocument";
            btnDeleteDocument.Size = new Size(204, 44);
            btnDeleteDocument.TabIndex = 11;
            btnDeleteDocument.Text = "DeleteDocument";
            btnDeleteDocument.UseVisualStyleBackColor = true;
            btnDeleteDocument.Click += btnDeleteDocument_Click;
            // 
            // PatientMedicalRecords
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 604);
            Controls.Add(btnDeleteDocument);
            Controls.Add(btnAddRecord);
            Controls.Add(btnDeleteRecord);
            Controls.Add(addDocument);
            Controls.Add(dataGridViewRecords);
            Controls.Add(label3);
            Controls.Add(lblPatientEmail);
            Controls.Add(lblPatientName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnViewDocument);
            Controls.Add(dataGridViewDocuments);
         
            Name = "PatientMedicalRecords";
            Text = "PatientMedicalRecords";
            Load += PatientMedicalRecords_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDocuments).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecords).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewDocuments;
        private Button btnViewDocument;
        private Label label1;
        private Label label2;
        private Label lblPatientName;
        private Label lblPatientEmail;
        private Label label3;
        private DataGridView dataGridViewRecords;
        private Button addDocument;
        private Button btnDeleteRecord;
        private Button btnAddRecord;
        private Button btnDeleteDocument;
   
    }
}