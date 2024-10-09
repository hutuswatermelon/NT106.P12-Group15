using System.Windows.Forms;

namespace ClientChat
{
    partial class ClientForm
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
            txtChatLog = new RichTextBox();
            sendMsgTextBox = new RichTextBox();
            btnSendMsg = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            txtIPAddr = new TextBox();
            label2 = new Label();
            button2 = new Button();
            label3 = new Label();
            txtUsername = new TextBox();
            txtFriend = new TextBox();
            label4 = new Label();
            progressBar1 = new ProgressBar();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtChatLog
            // 
            txtChatLog.Location = new Point(12, 81);
            txtChatLog.Margin = new Padding(3, 4, 3, 4);
            txtChatLog.Name = "txtChatLog";
            txtChatLog.Size = new Size(776, 335);
            txtChatLog.TabIndex = 0;
            txtChatLog.Text = "";
            // 
            // sendMsgTextBox
            // 
            sendMsgTextBox.Location = new Point(12, 428);
            sendMsgTextBox.Margin = new Padding(3, 4, 3, 4);
            sendMsgTextBox.Name = "sendMsgTextBox";
            sendMsgTextBox.Size = new Size(644, 119);
            sendMsgTextBox.TabIndex = 1;
            sendMsgTextBox.Text = "";
            // 
            // btnSendMsg
            // 
            btnSendMsg.Location = new Point(662, 428);
            btnSendMsg.Margin = new Padding(3, 4, 3, 4);
            btnSendMsg.Name = "btnSendMsg";
            btnSendMsg.Size = new Size(117, 120);
            btnSendMsg.TabIndex = 2;
            btnSendMsg.Text = "Send Message";
            btnSendMsg.UseVisualStyleBackColor = true;
            btnSendMsg.Click += btnSendMsg_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(150, 26);
            openToolStripMenuItem.Text = "Send file";
            openToolStripMenuItem.Click += btnSendFile;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(120, 45);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 7;
            // 
            // txtIPAddr
            // 
            txtIPAddr.Location = new Point(120, 46);
            txtIPAddr.Margin = new Padding(3, 4, 3, 4);
            txtIPAddr.Name = "txtIPAddr";
            txtIPAddr.Size = new Size(100, 27);
            txtIPAddr.TabIndex = 10;
            txtIPAddr.Text = "127.0.0.1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 48);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 9;
            label2.Text = "Server address";
            // 
            // button2
            // 
            button2.Location = new Point(588, 46);
            button2.Margin = new Padding(3, 5, 3, 5);
            button2.Name = "button2";
            button2.Size = new Size(123, 30);
            button2.TabIndex = 11;
            button2.Text = "Connect";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(243, 50);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 12;
            label3.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(322, 46);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 27);
            txtUsername.TabIndex = 13;
            txtUsername.Text = "Alice";
            // 
            // txtFriend
            // 
            txtFriend.Location = new Point(482, 47);
            txtFriend.Margin = new Padding(3, 4, 3, 4);
            txtFriend.Name = "txtFriend";
            txtFriend.Size = new Size(100, 27);
            txtFriend.TabIndex = 15;
            txtFriend.Text = "Bob";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(428, 50);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 14;
            label4.Text = "Friend";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(717, 46);
            progressBar1.Margin = new Padding(3, 5, 3, 5);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(71, 30);
            progressBar1.TabIndex = 16;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 562);
            Controls.Add(progressBar1);
            Controls.Add(txtFriend);
            Controls.Add(label4);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(txtIPAddr);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSendMsg);
            Controls.Add(sendMsgTextBox);
            Controls.Add(txtChatLog);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ClientForm";
            Text = "ClientChatForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RichTextBox txtChatLog;
        private System.Windows.Forms.RichTextBox sendMsgTextBox;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPAddr;
        private System.Windows.Forms.Label label2;
        private Button button2;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtFriend;
        private Label label4;
        private ProgressBar progressBar1;
    }
}

