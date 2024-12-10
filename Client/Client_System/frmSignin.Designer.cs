namespace Client_System
{
    partial class frmSignin
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnRegister = new Button();
            btnClear = new Button();
            BackLogin = new Label();
            ShowPassIcon = new PictureBox();
            btnExit = new PictureBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)ShowPassIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnExit).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Bahnschrift Condensed", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 26);
            label1.Name = "label1";
            label1.Size = new Size(125, 48);
            label1.TabIndex = 0;
            label1.Text = "BẮT ĐẦU";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.WhiteSmoke;
            label2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(20, 115);
            label2.Name = "label2";
            label2.Size = new Size(105, 24);
            label2.TabIndex = 1;
            label2.Text = "Tên người chơi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.WhiteSmoke;
            label3.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(20, 223);
            label3.Name = "label3";
            label3.Size = new Size(70, 24);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(20, 148);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(400, 32);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(20, 256);
            txtPassword.Margin = new Padding(3, 3, 3, 6);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(400, 32);
            txtPassword.TabIndex = 4;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Indigo;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Bahnschrift Condensed", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(43, 378);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(354, 57);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "ĐĂNG NHẬP";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnSignin_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Bahnschrift Condensed", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.RoyalBlue;
            btnClear.Location = new Point(43, 453);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(354, 57);
            btnClear.TabIndex = 9;
            btnClear.Text = "XÓA";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // BackLogin
            // 
            BackLogin.AutoSize = true;
            BackLogin.Cursor = Cursors.Hand;
            BackLogin.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            BackLogin.ForeColor = Color.RoyalBlue;
            BackLogin.Location = new Point(331, 570);
            BackLogin.Name = "BackLogin";
            BackLogin.Size = new Size(66, 24);
            BackLogin.TabIndex = 10;
            BackLogin.Text = "ĐĂNG KÝ";
            BackLogin.Click += lbRegister_Click;
            // 
            // ShowPassIcon
            // 
            ShowPassIcon.BackColor = Color.White;
            ShowPassIcon.Cursor = Cursors.Hand;
            ShowPassIcon.Image = Properties.Resources.UnShowPasIcon;
            ShowPassIcon.Location = new Point(366, 255);
            ShowPassIcon.Name = "ShowPassIcon";
            ShowPassIcon.Size = new Size(54, 33);
            ShowPassIcon.SizeMode = PictureBoxSizeMode.Zoom;
            ShowPassIcon.TabIndex = 25;
            ShowPassIcon.TabStop = false;
            ShowPassIcon.Click += ShowPassIcon_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.Image = Properties.Resources.close;
            btnExit.Location = new Point(393, 12);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(35, 35);
            btnExit.SizeMode = PictureBoxSizeMode.StretchImage;
            btnExit.TabIndex = 30;
            btnExit.TabStop = false;
            btnExit.Click += btnExit_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(43, 570);
            label5.Name = "label5";
            label5.Size = new Size(168, 23);
            label5.TabIndex = 11;
            label5.Text = "Chưa có tài khoản?";
            // 
            // frmSignin
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.bgsu;
            ClientSize = new Size(440, 670);
            Controls.Add(btnExit);
            Controls.Add(ShowPassIcon);
            Controls.Add(label5);
            Controls.Add(BackLogin);
            Controls.Add(btnClear);
            Controls.Add(btnRegister);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmSignin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign Up";
            FormClosed += frmSignin_FormClosed;
            ((System.ComponentModel.ISupportInitialize)ShowPassIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnExit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label BackLogin;
        private System.Windows.Forms.PictureBox ShowPassIcon;
        private PictureBox btnExit;
        private Label label5;
    }
}