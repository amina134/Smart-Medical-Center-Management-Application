using System.Resources;

namespace medilabcsharp
{
    partial class loginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            userName = new TextBox();
            Password = new TextBox();
            loginBut = new Button();
            gifBackground = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)gifBackground).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Beige;
            label1.Font = new Font("Tw Cen MT Condensed Extra Bold", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 21);
            label1.Name = "label1";
            label1.Size = new Size(325, 62);
            label1.TabIndex = 0;
            label1.Text = "Welcome To MediLab";
            // 
            // label2
            // 
            label2.BackColor = Color.Beige;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label2.Location = new Point(31, 118);
            label2.Name = "label2";
            label2.Size = new Size(87, 21);
            label2.TabIndex = 1;
            label2.Text = "Username";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            label4.BackColor = Color.Beige;
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label4.Location = new Point(31, 207);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 3;
            label4.Text = "Password";
            label4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // userName
            // 
            userName.BackColor = Color.White;
            userName.BorderStyle = BorderStyle.FixedSingle;
            userName.Font = new Font("Segoe UI", 12F);
            userName.ForeColor = Color.FromArgb(64, 64, 64);
            userName.Location = new Point(31, 148);
            userName.Margin = new Padding(0, 0, 0, 20);
            userName.Name = "userName";
            userName.Size = new Size(300, 29);
            userName.TabIndex = 4;
            // 
            // Password
            // 
            Password.BackColor = Color.White;
            Password.BorderStyle = BorderStyle.FixedSingle;
            Password.Font = new Font("Segoe UI", 12F);
            Password.ForeColor = Color.FromArgb(64, 64, 64);
            Password.Location = new Point(31, 241);
            Password.Name = "Password";
            Password.PasswordChar = '•';
            Password.Size = new Size(300, 29);
            Password.TabIndex = 6;
            // 
            // loginBut
            // 
            loginBut.BackColor = Color.Beige;
            loginBut.Font = new Font("Segoe UI Black", 12F);
            loginBut.Location = new Point(31, 344);
            loginBut.Name = "loginBut";
            loginBut.Size = new Size(273, 94);
            loginBut.TabIndex = 7;
            loginBut.Text = "login";
            loginBut.UseVisualStyleBackColor = true;
            loginBut.Click += loginBut_Click;
            // 
            // gifBackground
            // 
            gifBackground.BackColor = Color.Transparent;
            gifBackground.Dock = DockStyle.Fill;
            gifBackground.Image = (Image)resources.GetObject("gifBackground.Image");
            gifBackground.Location = new Point(0, 0);
            gifBackground.Name = "gifBackground";
            gifBackground.Size = new Size(800, 450);
            gifBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            gifBackground.TabIndex = 0;
            gifBackground.TabStop = false;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginBut);
            Controls.Add(Password);
            Controls.Add(userName);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(gifBackground);
            Name = "loginForm";
            Text = "loginForm";
            WindowState = FormWindowState.Maximized;
            Load += loginForm_Load;
            ((System.ComponentModel.ISupportInitialize)gifBackground).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox userName;
        private TextBox Password;
        private Button loginBut;

        private PictureBox gifBackground;
    }
}
