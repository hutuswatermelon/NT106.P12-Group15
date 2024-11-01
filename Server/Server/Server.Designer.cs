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
            btnSendMsgfromServer = new Button();
            txtIPServer = new TextBox();
            lblRCV = new Label();
            lblReceiver = new Label();
            txtMessage = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lstLog
            // 
            tableLayoutPanel1.SetColumnSpan(lstLog, 4);
            lstLog.Dock = DockStyle.Fill;
            lstLog.FormattingEnabled = true;
            lstLog.Location = new Point(433, 23);
            lstLog.Name = "lstLog";
            tableLayoutPanel1.SetRowSpan(lstLog, 2);
            lstLog.Size = new Size(343, 334);
            lstLog.TabIndex = 0;
            // 
            // lstAccount
            // 
            tableLayoutPanel1.SetColumnSpan(lstAccount, 3);
            lstAccount.Dock = DockStyle.Fill;
            lstAccount.FullRowSelect = true;
            lstAccount.GridLines = true;
            lstAccount.Location = new Point(23, 53);
            lstAccount.Name = "lstAccount";
            lstAccount.Size = new Size(344, 304);
            lstAccount.TabIndex = 5;
            lstAccount.UseCompatibleStateImageBehavior = false;
            lstAccount.View = View.Details;
            lstAccount.SelectedIndexChanged += lstAccount_SelectedIndexChanged;
            // 
            // btnListen
            // 
            btnListen.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnListen.BackColor = Color.White;
            btnListen.FlatStyle = FlatStyle.Flat;
            btnListen.Location = new Point(23, 393);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(149, 34);
            btnListen.TabIndex = 6;
            btnListen.Text = "Mở Server";
            btnListen.UseVisualStyleBackColor = false;
            btnListen.Click += btnListen_Click;
            // 
            // btnCloseServer
            // 
            btnCloseServer.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCloseServer.BackColor = Color.White;
            btnCloseServer.FlatStyle = FlatStyle.Flat;
            btnCloseServer.Location = new Point(218, 393);
            btnCloseServer.Name = "btnCloseServer";
            btnCloseServer.Size = new Size(149, 34);
            btnCloseServer.TabIndex = 6;
            btnCloseServer.Text = "Đóng Server";
            btnCloseServer.UseVisualStyleBackColor = false;
            btnCloseServer.Click += btnCloseServer_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.GradientInactiveCaption;
            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(btnCloseServer, 3, 4);
            tableLayoutPanel1.Controls.Add(lstLog, 5, 1);
            tableLayoutPanel1.Controls.Add(btnListen, 1, 4);
            tableLayoutPanel1.Controls.Add(lstAccount, 1, 2);
            tableLayoutPanel1.Controls.Add(btnSendMsgfromServer, 8, 4);
            tableLayoutPanel1.Controls.Add(txtIPServer, 1, 1);
            tableLayoutPanel1.Controls.Add(lblRCV, 5, 3);
            tableLayoutPanel1.Controls.Add(lblReceiver, 6, 3);
            tableLayoutPanel1.Controls.Add(txtMessage, 5, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // btnSendMsgfromServer
            // 
            btnSendMsgfromServer.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnSendMsgfromServer.BackColor = Color.White;
            btnSendMsgfromServer.FlatStyle = FlatStyle.Flat;
            btnSendMsgfromServer.Location = new Point(705, 395);
            btnSendMsgfromServer.Name = "btnSendMsgfromServer";
            btnSendMsgfromServer.Size = new Size(71, 29);
            btnSendMsgfromServer.TabIndex = 8;
            btnSendMsgfromServer.Text = "Send";
            btnSendMsgfromServer.UseVisualStyleBackColor = false;
            btnSendMsgfromServer.Click += btnSendMsgfromServer_Click;
            // 
            // txtIPServer
            // 
            txtIPServer.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtIPServer.BackColor = SystemColors.Window;
            tableLayoutPanel1.SetColumnSpan(txtIPServer, 3);
            txtIPServer.Location = new Point(23, 23);
            txtIPServer.Name = "txtIPServer";
            txtIPServer.ReadOnly = true;
            txtIPServer.Size = new Size(344, 27);
            txtIPServer.TabIndex = 9;
            // 
            // lblRCV
            // 
            lblRCV.Anchor = AnchorStyles.Left;
            lblRCV.AutoSize = true;
            lblRCV.Location = new Point(433, 365);
            lblRCV.Name = "lblRCV";
            lblRCV.Size = new Size(90, 20);
            lblRCV.TabIndex = 10;
            lblRCV.Text = "Người nhận:";
            // 
            // lblReceiver
            // 
            lblReceiver.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblReceiver.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblReceiver, 3);
            lblReceiver.Location = new Point(588, 365);
            lblReceiver.Name = "lblReceiver";
            lblReceiver.Size = new Size(188, 20);
            lblReceiver.TabIndex = 10;
            lblReceiver.Text = "Chọn 1 Tài khoản Online";
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(txtMessage, 3);
            txtMessage.Location = new Point(433, 393);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(266, 34);
            txtMessage.TabIndex = 7;
            // 
            // frmServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
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
