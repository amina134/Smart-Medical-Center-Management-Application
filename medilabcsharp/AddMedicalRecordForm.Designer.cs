
namespace medilabcsharp
{
    partial class AddMedicalRecordForm
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.TextBox txtTreatment;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.DateTimePicker dtpConsultation;
        private System.Windows.Forms.CheckBox chkFollowUp;
        private System.Windows.Forms.DateTimePicker dtpFollowUp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;


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
            txtDiagnosis = new TextBox();
            txtTreatment = new TextBox();
            txtNotes = new TextBox();
            dtpConsultation = new DateTimePicker();
            chkFollowUp = new CheckBox();
            dtpFollowUp = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            label1.Text = "Consultation Date:";
            // 
            // label2
            // 
            label2.Location = new Point(20, 60);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 1;
            label2.Text = "Diagnosis:";
            // 
            // label3
            // 
            label3.Location = new Point(20, 150);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 2;
            label3.Text = "Treatment:";
            // 
            // label4
            // 
            label4.Location = new Point(20, 240);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 3;
            label4.Text = "Notes:";
            // 
            // label5
            // 
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 4;
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.Location = new Point(150, 60);
            txtDiagnosis.Multiline = true;
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.Size = new Size(300, 80);
            txtDiagnosis.TabIndex = 6;
            // 
            // txtTreatment
            // 
            txtTreatment.Location = new Point(150, 150);
            txtTreatment.Multiline = true;
            txtTreatment.Name = "txtTreatment";
            txtTreatment.Size = new Size(300, 80);
            txtTreatment.TabIndex = 7;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(150, 240);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(300, 80);
            txtNotes.TabIndex = 8;
            // 
            // dtpConsultation
            // 
            dtpConsultation.CustomFormat = "yyyy-MM-dd HH:mm";
            dtpConsultation.Format = DateTimePickerFormat.Custom;
            dtpConsultation.Location = new Point(150, 20);
            dtpConsultation.Name = "dtpConsultation";
            dtpConsultation.Size = new Size(200, 23);
            dtpConsultation.TabIndex = 5;
            // 
            // chkFollowUp
            // 
            chkFollowUp.Location = new Point(20, 330);
            chkFollowUp.Name = "chkFollowUp";
            chkFollowUp.Size = new Size(104, 24);
            chkFollowUp.TabIndex = 9;
            chkFollowUp.Text = "Schedule Follow-up";
            // 
            // dtpFollowUp
             // 
            dtpFollowUp.Enabled = false;
            dtpFollowUp.Format = DateTimePickerFormat.Short;
            dtpFollowUp.Location = new Point(150, 330);
            dtpFollowUp.Name = "dtpFollowUp";
            dtpFollowUp.Size = new Size(200, 23);
            dtpFollowUp.TabIndex = 10;
            dtpFollowUp.ValueChanged += dtpFollowUp_ValueChanged;
         
            this.chkFollowUp.CheckedChanged += (s, e) =>
                dtpFollowUp.Enabled = chkFollowUp.Checked;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(150, 370);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(250, 370);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            // 
            // AddMedicalRecordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 420);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(dtpConsultation);
            Controls.Add(txtDiagnosis);
            Controls.Add(txtTreatment);
            Controls.Add(txtNotes);
            Controls.Add(chkFollowUp);
            Controls.Add(dtpFollowUp);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "AddMedicalRecordForm";
            Text = "AddMedicalRecordForm";
            Load += AddMedicalRecordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}