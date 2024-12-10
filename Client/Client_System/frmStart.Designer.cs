namespace Client_System
{
    partial class frmStart
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            btnSignin = new Button();
            btnSignup = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            txtServerIP = new TextBox();
            button1 = new Button();
            btnExit = new PictureBox();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)btnExit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Bahnschrift Condensed", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 40);
            label1.Name = "label1";
            label1.Size = new Size(249, 57);
            label1.TabIndex = 0;
            label1.Text = "STORY TELLING";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSignin
            // 
            btnSignin.BackColor = Color.Indigo;
            btnSignin.Cursor = Cursors.Hand;
            btnSignin.FlatAppearance.BorderSize = 0;
            btnSignin.FlatStyle = FlatStyle.Flat;
            btnSignin.Font = new Font("Bahnschrift Condensed", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignin.ForeColor = Color.White;
            btnSignin.Location = new Point(43, 279);
            btnSignin.Name = "btnSignin";
            btnSignin.Size = new Size(354, 57);
            btnSignin.TabIndex = 20;
            btnSignin.Text = "ĐĂNG NHẬP";
            btnSignin.UseVisualStyleBackColor = false;
            btnSignin.Click += btnSignin_Click;
            // 
            // btnSignup
            // 
            btnSignup.BackColor = Color.Indigo;
            btnSignup.Cursor = Cursors.Hand;
            btnSignup.FlatAppearance.BorderSize = 0;
            btnSignup.FlatStyle = FlatStyle.Flat;
            btnSignup.Font = new Font("Bahnschrift Condensed", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignup.ForeColor = Color.White;
            btnSignup.Location = new Point(43, 351);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(354, 57);
            btnSignup.TabIndex = 21;
            btnSignup.Text = "ĐĂNG KÝ";
            btnSignup.UseVisualStyleBackColor = false;
            btnSignup.Click += btnSignup_Click;
            // 
            // txtServerIP
            // 
            txtServerIP.BackColor = Color.White;
            txtServerIP.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtServerIP.Location = new Point(20, 160);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(400, 32);
            txtServerIP.TabIndex = 22;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(166, 207);
            button1.Name = "button1";
            button1.Size = new Size(107, 41);
            button1.TabIndex = 23;
            button1.Text = "Kết nối";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnConnect_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.Image = Properties.Resources.close;
            btnExit.Location = new Point(394, 9);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(35, 33);
            btnExit.SizeMode = PictureBoxSizeMode.StretchImage;
            btnExit.TabIndex = 29;
            btnExit.TabStop = false;
            btnExit.Click += btnExit_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources.start2;
            pictureBox3.Location = new Point(310, 40);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(110, 59);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 32;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(20, 132);
            label2.Name = "label2";
            label2.Size = new Size(105, 25);
            label2.TabIndex = 33;
            label2.Text = "IP server :";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmStart
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(440, 447);
            Controls.Add(label2);
            Controls.Add(btnExit);
            Controls.Add(button1);
            Controls.Add(btnSignup);
            Controls.Add(btnSignin);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(txtServerIP);
            Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.RoyalBlue;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmStart";
            RightToLeftLayout = true;
            Text = "Start";
            FormClosed += frmStart_FormClosed;
            Load += frmStart_Load;
            ((System.ComponentModel.ISupportInitialize)btnExit).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSignin;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox btnExit;
        private PictureBox pictureBox3;
        private Label label2;
    }
}