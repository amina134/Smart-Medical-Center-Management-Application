namespace medilabcsharp
{
    partial class AddMedicalDocumentForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtDescription = new TextBox();
            txtFilePath = new TextBox();
            txtFileName = new TextBox();
            button2 = new Button();
            btnBrowse = new Button();
            cmbDocumentType = new ComboBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(165, 29);
            label1.Name = "label1";
            label1.Size = new Size(161, 15);
            label1.TabIndex = 0;
            label1.Text = " ADD MEDICAL DOCUMENT  ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(89, 131);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 1;
            label2.Text = " Document Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(101, 181);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "File Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(101, 234);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 3;
            label4.Text = "  File Path:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(101, 292);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 4;
            label5.Text = " Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(204, 292);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(230, 23);
            txtDescription.TabIndex = 5;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(204, 239);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(230, 23);
            txtFilePath.TabIndex = 6;
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(202, 178);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(161, 23);
            txtFileName.TabIndex = 7;
            // 
            // button2
            // 
            button2.Location = new Point(307, 379);
            button2.Name = "button2";
            button2.Size = new Size(186, 59);
            button2.TabIndex = 9;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(369, 177);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 10;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click_1;
            // 
            // cmbDocumentType
            // 
            cmbDocumentType.FormattingEnabled = true;
            cmbDocumentType.Location = new Point(204, 131);
            cmbDocumentType.Name = "cmbDocumentType";
            cmbDocumentType.Size = new Size(159, 23);
            cmbDocumentType.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(89, 379);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(186, 59);
            btnSave.TabIndex = 12;
            btnSave.Text = "save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // AddMedicalDocumentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(cmbDocumentType);
            Controls.Add(btnBrowse);
            Controls.Add(button2);
            Controls.Add(txtFileName);
            Controls.Add(txtFilePath);
            Controls.Add(txtDescription);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddMedicalDocumentForm";
            Text = "AddMedicalDocumentForm";
            Load += AddMedicalDocumentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtDescription;
        private TextBox txtFilePath;
        private TextBox txtFileName;
        private Button button2;
        private Button btnBrowse;
        private ComboBox cmbDocumentType;
        private Button btnSave;
    }
}