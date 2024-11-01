namespace frmServer
{
    partial class frmServer
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
            components = new System.ComponentModel.Container();
            lstLog = new ListBox();
            lstAccount = new ListView();
            btnListen = new Button();
            btnCloseServer = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtMessage = new TextBox();
            btnSendMsgfromServer = new Button();
            txtIPServer = new TextBox();
            lblRCV = new Label();
            lblReceiver = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lstLog
            // 
            tableLayoutPanel1.SetColumnSpan(lstLog, 4);
            lstLog.Dock = DockStyle.Fill;
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 25;
            lstLog.Location = new Point(540, 29);
            lstLog.Margin = new Padding(4, 4, 4, 4);
            lstLog.Name = "lstLog";
            tableLayoutPanel1.SetRowSpan(lstLog, 2);
            lstLog.Size = new Size(427, 416);
            lstLog.TabIndex = 0;
            // 
            // lstAccount
            // 
            tableLayoutPanel1.SetColumnSpan(lstAccount, 3);
            lstAccount.Dock = DockStyle.Fill;
            lstAccount.FullRowSelect = true;
            lstAccount.GridLines = true;
            lstAccount.Location = new Point(29, 67);
            lstAccount.Margin = new Padding(4, 4, 4, 4);
            lstAccount.Name = "lstAccount";
            lstAccount.Size = new Size(428, 378);
            lstAccount.TabIndex = 5;
            lstAccount.UseCompatibleStateImageBehavior = false;
            lstAccount.View = View.Details;
            lstAccount.SelectedIndexChanged += lstAccount_SelectedIndexChanged;
            // 
            // btnListen
            // 
            btnListen.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnListen.Location = new Point(29, 491);
            btnListen.Margin = new Padding(4, 4, 4, 4);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(185, 42);
            btnListen.TabIndex = 6;
            btnListen.Text = "Mở Server";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // btnCloseServer
            // 
            btnCloseServer.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCloseServer.Location = new Point(272, 491);
            btnCloseServer.Margin = new Padding(4, 4, 4, 4);
            btnCloseServer.Name = "btnCloseServer";
            btnCloseServer.Size = new Size(185, 42);
            btnCloseServer.TabIndex = 6;
            btnCloseServer.Text = "Đóng Server";
            btnCloseServer.UseVisualStyleBackColor = true;
            btnCloseServer.Click += btnCloseServer_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 26F));
            tableLayoutPanel1.Controls.Add(btnCloseServer, 3, 4);
            tableLayoutPanel1.Controls.Add(lstLog, 5, 1);
            tableLayoutPanel1.Controls.Add(btnListen, 1, 4);
            tableLayoutPanel1.Controls.Add(lstAccount, 1, 2);
            tableLayoutPanel1.Controls.Add(txtMessage, 5, 4);
            tableLayoutPanel1.Controls.Add(btnSendMsgfromServer, 8, 4);
            tableLayoutPanel1.Controls.Add(txtIPServer, 1, 1);
            tableLayoutPanel1.Controls.Add(lblRCV, 5, 3);
            tableLayoutPanel1.Controls.Add(lblReceiver, 6, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 4, 4, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.Size = new Size(1000, 562);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(txtMessage, 3);
            txtMessage.Location = new Point(540, 496);
            txtMessage.Margin = new Padding(4, 4, 4, 4);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(331, 31);
            txtMessage.TabIndex = 7;
            // 
            // btnSendMsgfromServer
            // 
            btnSendMsgfromServer.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnSendMsgfromServer.Location = new Point(879, 494);
            btnSendMsgfromServer.Margin = new Padding(4, 4, 4, 4);
            btnSendMsgfromServer.Name = "btnSendMsgfromServer";
            btnSendMsgfromServer.Size = new Size(88, 36);
            btnSendMsgfromServer.TabIndex = 8;
            btnSendMsgfromServer.Text = "Send";
            btnSendMsgfromServer.UseVisualStyleBackColor = true;
            btnSendMsgfromServer.Click += btnSendMsgfromServer_Click;
            // 
            // txtIPServer
            // 
            txtIPServer.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtIPServer.BackColor = SystemColors.Window;
            tableLayoutPanel1.SetColumnSpan(txtIPServer, 3);
            txtIPServer.Location = new Point(29, 29);
            txtIPServer.Margin = new Padding(4, 4, 4, 4);
            txtIPServer.Name = "txtIPServer";
            txtIPServer.ReadOnly = true;
            txtIPServer.Size = new Size(428, 31);
            txtIPServer.TabIndex = 9;
            // 
            // lblRCV
            // 
            lblRCV.Anchor = AnchorStyles.Left;
            lblRCV.AutoSize = true;
            lblRCV.Location = new Point(540, 455);
            lblRCV.Margin = new Padding(4, 0, 4, 0);
            lblRCV.Name = "lblRCV";
            lblRCV.Size = new Size(110, 25);
            lblRCV.TabIndex = 10;
            lblRCV.Text = "Người nhận:";
            // 
            // lblReceiver
            // 
            lblReceiver.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblReceiver.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblReceiver, 3);
            lblReceiver.Location = new Point(733, 455);
            lblReceiver.Margin = new Padding(4, 0, 4, 0);
            lblReceiver.Name = "lblReceiver";
            lblReceiver.Size = new Size(234, 25);
            lblReceiver.TabIndex = 10;
            lblReceiver.Text = "Chọn 1 Tài khoản Online";
            // 
            // frmServer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmServer";
            Text = "Server";
            Load += frmServer_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstLog;
        private ListView lstAccount;
        private Button btnListen;
        private Button btnCloseServer;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtMessage;
        private Button btnSendMsgfromServer;
        private TextBox txtIPServer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Label lblRCV;
        private Label lblReceiver;
    }
}
