namespace medilabcsharp
{
    partial class UpdateAppointmentForm
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
            SuspendLayout();
            // 
            // UpdateAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "UpdateAppointmentForm";
            Text = "UpdateAppointmentForm";
            Load += UpdateAppointmentForm_Load;
            ResumeLayout(false);

            this.lblPatient = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblCurrentDoctor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.lstTimeSlots = new System.Windows.Forms.ListBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();

            // lblPatient
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(20, 20);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(46, 13);
            this.lblPatient.TabIndex = 0;
            this.lblPatient.Text = "Patient:";

            // lblPatientName
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Location = new System.Drawing.Point(100, 20);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(35, 13);
            this.lblPatientName.TabIndex = 1;
            this.lblPatientName.Text = "label1";

            // lblCurrentDoctor
            this.lblCurrentDoctor.AutoSize = true;
            this.lblCurrentDoctor.Location = new System.Drawing.Point(100, 50);
            this.lblCurrentDoctor.Name = "lblCurrentDoctor";
            this.lblCurrentDoctor.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentDoctor.TabIndex = 3;
            this.lblCurrentDoctor.Text = "label2";

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Doctor:";

            // cmbDoctor
            this.cmbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(100, 80);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(200, 21);
            this.cmbDoctor.TabIndex = 4;
            //this.cmbDoctor.SelectedIndexChanged += new System.EventHandler(this.cmbDoctor_SelectedIndexChanged);

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 110);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Date:";

            // dtpDate
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(100, 107);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDate.TabIndex = 6;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);

            // lblTime
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(20, 140);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(70, 13);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "Available Slots:";

            // lstTimeSlots
            this.lstTimeSlots.FormattingEnabled = true;
            this.lstTimeSlots.Location = new System.Drawing.Point(100, 140);
            this.lstTimeSlots.Name = "lstTimeSlots";
            this.lstTimeSlots.Size = new System.Drawing.Size(100, 95);
            this.lstTimeSlots.TabIndex = 8;

            // lblDuration
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(20, 250);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDuration.TabIndex = 9;
            this.lblDuration.Text = "Duration:";

            // numDuration
            this.numDuration.Location = new System.Drawing.Point(100, 248);
            this.numDuration.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(60, 20);
            this.numDuration.TabIndex = 10;
            this.numDuration.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});

            // lblReason
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(20, 280);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(44, 13);
            this.lblReason.TabIndex = 11;
            this.lblReason.Text = "Reason:";

            // txtReason
            this.txtReason.Location = new System.Drawing.Point(100, 277);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(200, 60);
            this.txtReason.TabIndex = 12;

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(150, 370);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(230, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 350);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status:";

            // cmbStatus
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Scheduled",
            "Completed",
            "Cancelled",
            "No-Show"});
            this.cmbStatus.Location = new System.Drawing.Point(100, 347);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(100, 21);
            this.cmbStatus.TabIndex = 17;

            // UpdateAppointmentForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 420);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lstTimeSlots);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.lblCurrentDoctor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblPatient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateAppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Appointment";
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblCurrentDoctor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ListBox lstTimeSlots;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
    }
}