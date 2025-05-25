namespace medilabcsharp
{
    partial class PaymentDialog
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
            lblTitle = new Label();
            lblAmount = new Label();
            numAmount = new NumericUpDown();
            lblMethod = new Label();
            cmbMethod = new ComboBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            btnConfirm = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(23, 23);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(162, 17);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Record New Payment";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(23, 69);
            lblAmount.Margin = new Padding(4, 0, 4, 0);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(54, 15);
            lblAmount.TabIndex = 1;
            lblAmount.Text = "Amount:";
            // 
            // numAmount
            // 
            numAmount.DecimalPlaces = 2;
            numAmount.Location = new Point(140, 67);
            numAmount.Margin = new Padding(4, 3, 4, 3);
            numAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numAmount.Name = "numAmount";
            numAmount.Size = new Size(175, 23);
            numAmount.TabIndex = 2;
            numAmount.ThousandsSeparator = true;
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Location = new Point(23, 104);
            lblMethod.Margin = new Padding(4, 0, 4, 0);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(52, 15);
            lblMethod.TabIndex = 3;
            lblMethod.Text = "Method:";
            // 
            // cmbMethod
            // 
            cmbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMethod.FormattingEnabled = true;
            cmbMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Insurance", "Bank Transfer" });
            cmbMethod.Location = new Point(140, 100);
            cmbMethod.Margin = new Padding(4, 3, 4, 3);
            cmbMethod.Name = "cmbMethod";
            cmbMethod.Size = new Size(174, 23);
            cmbMethod.TabIndex = 4;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(23, 138);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(34, 15);
            lblDate.TabIndex = 5;
            lblDate.Text = "Date:";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(140, 135);
            dtpDate.Margin = new Padding(4, 3, 4, 3);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(174, 23);
            dtpDate.TabIndex = 6;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(140, 185);
            btnConfirm.Margin = new Padding(4, 3, 4, 3);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(88, 35);
            btnConfirm.TabIndex = 7;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(233, 185);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 35);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // PaymentDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 242);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(dtpDate);
            Controls.Add(lblDate);
            Controls.Add(cmbMethod);
            Controls.Add(lblMethod);
            Controls.Add(numAmount);
            Controls.Add(lblAmount);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Record Payment";
            Load += PaymentDialog_Load;
            ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}