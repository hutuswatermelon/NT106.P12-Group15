namespace Client_System
{
    partial class frmChangePassword
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
            SocketClientSingleton.Instance.CommandReceived -= HandleServerCommand;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtConfirmPass = new TextBox();
            txtPass = new TextBox();
            btnChangePass = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtConfirmPass.Location = new Point(176, 82);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(251, 38);
            txtConfirmPass.TabIndex = 0;
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPass.Location = new Point(176, 15);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(251, 38);
            txtPass.TabIndex = 0;
            // 
            // btnChangePass
            // 
            btnChangePass.BackColor = Color.Indigo;
            btnChangePass.Font = new Font("Bahnschrift SemiBold Condensed", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChangePass.ForeColor = Color.White;
            btnChangePass.Location = new Point(218, 142);
            btnChangePass.Name = "btnChangePass";
            btnChangePass.Size = new Size(166, 53);
            btnChangePass.TabIndex = 1;
            btnChangePass.Text = "ĐỔI MẬT KHẨU";
            btnChangePass.UseVisualStyleBackColor = false;
            btnChangePass.Click += btnChangePass_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(135, 25);
            label1.TabIndex = 2;
            label1.Text = "Mật khẩu mới";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(55, 90);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 2;
            label2.Text = "Xác nhận";
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumPurple;
            ClientSize = new Size(449, 218);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnChangePass);
            Controls.Add(txtPass);
            Controls.Add(txtConfirmPass);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmChangePassword";
            Text = "Đổi Mật Khẩu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtConfirmPass;
        private TextBox txtPass;
        private Button btnChangePass;
        private Label label1;
        private Label label2;
    }
}