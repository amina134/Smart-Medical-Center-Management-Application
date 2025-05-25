namespace medilabcsharp
{
    partial class WhoAreYou
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
            admin = new Button();
            patient = new Button();
            secretary = new Button();
            doctor = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT Condensed Extra Bold", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(205, 35);
            label1.Name = "label1";
            label1.Size = new Size(316, 44);
            label1.TabIndex = 1;
            label1.Text = "Welcome To MediLab";
            // 
            // admin
            // 
            admin.Location = new Point(157, 147);
            admin.Name = "admin";
            admin.Size = new Size(194, 78);
            admin.TabIndex = 2;
            admin.Text = "admin";
            admin.UseVisualStyleBackColor = true;
            admin.Click += admin_Click;
            // 
            // patient
            // 
            patient.Location = new Point(392, 147);
            patient.Name = "patient";
            patient.Size = new Size(182, 78);
            patient.TabIndex = 3;
            patient.Text = "patient";
            patient.UseVisualStyleBackColor = true;
            // 
            // secretary
            // 
            secretary.Location = new Point(392, 243);
            secretary.Name = "secretary";
            secretary.Size = new Size(182, 74);
            secretary.TabIndex = 4;
            secretary.Text = "secretary";
            secretary.UseVisualStyleBackColor = true;
            // 
            // doctor
            // 
            doctor.Location = new Point(157, 243);
            doctor.Name = "doctor";
            doctor.Size = new Size(194, 74);
            doctor.TabIndex = 5;
            doctor.Text = "docter";
            doctor.UseVisualStyleBackColor = true;
            // 
            // WhoAreYou
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(doctor);
            Controls.Add(secretary);
            Controls.Add(patient);
            Controls.Add(admin);
            Controls.Add(label1);
            Name = "WhoAreYou";
            Text = "WhoAreYou";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button admin;
        private Button patient;
        private Button secretary;
        private Button doctor;
    }
}