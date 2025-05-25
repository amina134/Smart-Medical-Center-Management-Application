namespace MedicalCenter
{
    partial class GenerateInvoiceForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            lblInvoiceTitle = new Label();
            groupBox1 = new GroupBox();
            lblDuration = new Label();
            label8 = new Label();
            lblDate = new Label();
            label6 = new Label();
            lblDoctor = new Label();
            label4 = new Label();
            lblPatient = new Label();
            label2 = new Label();
            dgvInvoiceItems = new DataGridView();
            Description = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            btnRemoveItem = new Button();
            groupBox2 = new GroupBox();
            lblTotal = new Label();
            label11 = new Label();
            lblTax = new Label();
            label9 = new Label();
            lblSubtotal = new Label();
            label7 = new Label();
            groupBox3 = new GroupBox();
            txtNotes = new TextBox();
            btnGenerate = new Button();
            btnCancel = new Button();
            btnRecordPayment = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceItems).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // lblInvoiceTitle
            // 
            lblInvoiceTitle.AutoSize = true;
            lblInvoiceTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInvoiceTitle.Location = new Point(14, 10);
            lblInvoiceTitle.Margin = new Padding(4, 0, 4, 0);
            lblInvoiceTitle.Name = "lblInvoiceTitle";
            lblInvoiceTitle.Size = new Size(220, 20);
            lblInvoiceTitle.TabIndex = 0;
            lblInvoiceTitle.Text = "INVOICE FOR VISIT #123";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblDuration);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(lblDate);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lblDoctor);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lblPatient);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(19, 48);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(467, 138);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Appointment Details";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(117, 92);
            lblDuration.Margin = new Padding(4, 0, 4, 0);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(48, 15);
            lblDuration.TabIndex = 7;
            lblDuration.Text = "30 mins";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 92);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(56, 15);
            label8.TabIndex = 6;
            label8.Text = "Duration:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(117, 69);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(95, 15);
            lblDate.TabIndex = 5;
            lblDate.Text = "15/06/2023 09:00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 69);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 4;
            label6.Text = "Date:";
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(117, 46);
            lblDoctor.Margin = new Padding(4, 0, 4, 0);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(60, 15);
            lblDoctor.TabIndex = 3;
            lblDoctor.Text = "Dr. Martin";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 46);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 2;
            label4.Text = "Doctor:";
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Location = new Point(117, 23);
            lblPatient.Margin = new Padding(4, 0, 4, 0);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new Size(84, 15);
            lblPatient.TabIndex = 1;
            lblPatient.Text = "Marie Lambert";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 23);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 0;
            label2.Text = "Patient: ";
            // 
            // dgvInvoiceItems
            // 
            dgvInvoiceItems.AllowUserToAddRows = false;
            dgvInvoiceItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoiceItems.Columns.AddRange(new DataGridViewColumn[] { Description, Quantity, UnitPrice, Total });
            dgvInvoiceItems.Location = new Point(19, 194);
            dgvInvoiceItems.Margin = new Padding(4, 3, 4, 3);
            dgvInvoiceItems.Name = "dgvInvoiceItems";
            dgvInvoiceItems.RowHeadersVisible = false;
            dgvInvoiceItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoiceItems.Size = new Size(583, 173);
            dgvInvoiceItems.TabIndex = 2;
            // 
            // Description
            // 
            Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Description.HeaderText = "Description";
            Description.Name = "Description";
            // 
            // Quantity
            // 
            Quantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "1";
            Quantity.DefaultCellStyle = dataGridViewCellStyle4;
            Quantity.HeaderText = "Qty";
            Quantity.Name = "Quantity";
            Quantity.Width = 51;
            // 
            // UnitPrice
            // 
            UnitPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            UnitPrice.DefaultCellStyle = dataGridViewCellStyle5;
            UnitPrice.HeaderText = "Unit Price";
            UnitPrice.Name = "UnitPrice";
            UnitPrice.Width = 83;
            // 
            // Total
            // 
            Total.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Format = "C2";
            Total.DefaultCellStyle = dataGridViewCellStyle6;
            Total.HeaderText = "Total";
            Total.Name = "Total";
            Total.ReadOnly = true;
            Total.Width = 57;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.Location = new Point(19, 374);
            btnRemoveItem.Margin = new Padding(4, 3, 4, 3);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(117, 35);
            btnRemoveItem.TabIndex = 4;
            btnRemoveItem.Text = "Remove Item";
            btnRemoveItem.UseVisualStyleBackColor = true;
            btnRemoveItem.Click += btnRemoveItem_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblTotal);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(lblTax);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(lblSubtotal);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(609, 48);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(292, 138);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Invoice Summary";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(117, 92);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(39, 13);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "$0.00";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(12, 92);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(40, 13);
            label11.TabIndex = 4;
            label11.Text = "Total:";
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Location = new Point(117, 58);
            lblTax.Margin = new Padding(4, 0, 4, 0);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(34, 15);
            lblTax.TabIndex = 3;
            lblTax.Text = "$0.00";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 58);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(27, 15);
            label9.TabIndex = 2;
            label9.Text = "Tax:";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(117, 23);
            lblSubtotal.Margin = new Padding(4, 0, 4, 0);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(34, 15);
            lblSubtotal.TabIndex = 1;
            lblSubtotal.Text = "$0.00";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 23);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 0;
            label7.Text = "Subtotal:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtNotes);
            groupBox3.Location = new Point(19, 415);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(583, 115);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Notes";
            // 
            // txtNotes
            // 
            txtNotes.Dock = DockStyle.Fill;
            txtNotes.Location = new Point(4, 19);
            txtNotes.Margin = new Padding(4, 3, 4, 3);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(575, 93);
            txtNotes.TabIndex = 0;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(609, 485);
            btnGenerate.Margin = new Padding(4, 3, 4, 3);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(140, 46);
            btnGenerate.TabIndex = 7;
            btnGenerate.Text = "Generate Invoice";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(761, 485);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 46);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRecordPayment
            // 
            btnRecordPayment.Location = new Point(638, 231);
            btnRecordPayment.Name = "btnRecordPayment";
            btnRecordPayment.Size = new Size(137, 23);
            btnRecordPayment.TabIndex = 9;
            btnRecordPayment.Text = "Save Payment";
            btnRecordPayment.UseVisualStyleBackColor = true;
            btnRecordPayment.Click += btnRecordPayment_Click;
            // 
            // GenerateInvoiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 543);
            Controls.Add(btnRecordPayment);
            Controls.Add(btnCancel);
            Controls.Add(btnGenerate);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(btnRemoveItem);
            Controls.Add(dgvInvoiceItems);
            Controls.Add(groupBox1);
            Controls.Add(lblInvoiceTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GenerateInvoiceForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Generate Invoice";
            Load += GenerateInvoiceForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceItems).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblInvoiceTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInvoiceItems;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private Button btnRecordPayment;
    }
}