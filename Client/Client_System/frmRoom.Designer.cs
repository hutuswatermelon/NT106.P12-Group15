namespace Client_System
{
    partial class frmRoom
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
            components = new System.ComponentModel.Container();
            flpanelPlayerList = new FlowLayoutPanel();
            gbPlayer1 = new GroupBox();
            lblUserName1 = new Label();
            picAvatar1 = new PictureBox();
            gbPlayer2 = new GroupBox();
            lblUserName2 = new Label();
            picAvatar2 = new PictureBox();
            gbPlayer3 = new GroupBox();
            lblUserName3 = new Label();
            picAvatar3 = new PictureBox();
            gbPlayer4 = new GroupBox();
            lblUserName4 = new Label();
            picAvatar4 = new PictureBox();
            gbPlayer5 = new GroupBox();
            lblUserName5 = new Label();
            picAvatar5 = new PictureBox();
            gbPlayer6 = new GroupBox();
            lblUserName6 = new Label();
            picAvatar6 = new PictureBox();
            gbPlayer7 = new GroupBox();
            lblUserName7 = new Label();
            picAvatar7 = new PictureBox();
            gbPlayer8 = new GroupBox();
            lblUserName8 = new Label();
            picAvatar8 = new PictureBox();
            btnInvite = new Button();
            btnStartRoom = new Button();
            btnBack = new Button();
            lstChat = new ListBox();
            lblNumberofPlayer = new Label();
            panelTimer = new Panel();
            pictureBox4 = new PictureBox();
            cbbTimer = new ComboBox();
            lblTimerDescription = new Label();
            lblTimer = new Label();
            cbbNumofPlayer = new ComboBox();
            txtInRoomMessage = new TextBox();
            btnSendMsg = new Button();
            panelTurns = new Panel();
            pictureBox7 = new PictureBox();
            cbbTurns = new ComboBox();
            lblTurnDescription = new Label();
            lblTurn = new Label();
            panelTransferRole = new Panel();
            txtHost = new TextBox();
            pictureBox9 = new PictureBox();
            labelHostDescription = new Label();
            lblHosting = new Label();
            panelSettings = new Panel();
            picLogo = new PictureBox();
            btnExit = new PictureBox();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panelHost = new Panel();
            panel1 = new Panel();
            lblWaiting = new Label();
            picWaiting = new PictureBox();
            panelWaitingRoom = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            txtTurns = new TextBox();
            pictureBox6 = new PictureBox();
            label4 = new Label();
            label5 = new Label();
            panel7 = new Panel();
            txtHost_ReadOnly = new TextBox();
            pictureBox8 = new PictureBox();
            label6 = new Label();
            label7 = new Label();
            panel8 = new Panel();
            txtTimer = new TextBox();
            pictureBox10 = new PictureBox();
            label8 = new Label();
            label9 = new Label();
            panel9 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            label11 = new Label();
            pictureBox11 = new PictureBox();
            groupBox2 = new GroupBox();
            label12 = new Label();
            pictureBox12 = new PictureBox();
            groupBox3 = new GroupBox();
            label13 = new Label();
            pictureBox13 = new PictureBox();
            groupBox4 = new GroupBox();
            label14 = new Label();
            pictureBox14 = new PictureBox();
            panel11 = new Panel();
            lblRoomNumber = new Label();
            panelPlaying = new Panel();
            rtfSentence = new RichTextBox();
            picWrite = new PictureBox();
            barTimer = new ProgressBar();
            btnSubmit = new Button();
            txtSentence = new TextBox();
            countdownTimer = new System.Windows.Forms.Timer(components);
            panelEnd = new Panel();
            btnSave = new Button();
            rtfStory = new RichTextBox();
            flpanelPlayerList.SuspendLayout();
            gbPlayer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar1).BeginInit();
            gbPlayer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar2).BeginInit();
            gbPlayer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar3).BeginInit();
            gbPlayer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar4).BeginInit();
            gbPlayer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar5).BeginInit();
            gbPlayer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar6).BeginInit();
            gbPlayer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar7).BeginInit();
            gbPlayer8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar8).BeginInit();
            panelTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panelTurns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            panelTransferRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnExit).BeginInit();
            panelHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picWaiting).BeginInit();
            panelWaitingRoom.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox14).BeginInit();
            panelPlaying.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picWrite).BeginInit();
            panelEnd.SuspendLayout();
            SuspendLayout();
            // 
            // flpanelPlayerList
            // 
            flpanelPlayerList.AutoScroll = true;
            flpanelPlayerList.BackColor = Color.Indigo;
            flpanelPlayerList.BorderStyle = BorderStyle.FixedSingle;
            flpanelPlayerList.Controls.Add(gbPlayer1);
            flpanelPlayerList.Controls.Add(gbPlayer2);
            flpanelPlayerList.Controls.Add(gbPlayer3);
            flpanelPlayerList.Controls.Add(gbPlayer4);
            flpanelPlayerList.Controls.Add(gbPlayer5);
            flpanelPlayerList.Controls.Add(gbPlayer6);
            flpanelPlayerList.Controls.Add(gbPlayer7);
            flpanelPlayerList.Controls.Add(gbPlayer8);
            flpanelPlayerList.FlowDirection = FlowDirection.TopDown;
            flpanelPlayerList.Location = new Point(13, 195);
            flpanelPlayerList.Margin = new Padding(3, 4, 3, 4);
            flpanelPlayerList.Name = "flpanelPlayerList";
            flpanelPlayerList.Size = new Size(240, 380);
            flpanelPlayerList.TabIndex = 0;
            // 
            // gbPlayer1
            // 
            gbPlayer1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            gbPlayer1.Controls.Add(lblUserName1);
            gbPlayer1.Controls.Add(picAvatar1);
            gbPlayer1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbPlayer1.Location = new Point(3, 4);
            gbPlayer1.Margin = new Padding(3, 4, 3, 4);
            gbPlayer1.Name = "gbPlayer1";
            gbPlayer1.Padding = new Padding(3, 4, 3, 4);
            gbPlayer1.Size = new Size(230, 81);
            gbPlayer1.TabIndex = 0;
            gbPlayer1.TabStop = false;
            // 
            // lblUserName1
            // 
            lblUserName1.AutoSize = true;
            lblUserName1.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName1.ForeColor = Color.White;
            lblUserName1.Location = new Point(62, 37);
            lblUserName1.Name = "lblUserName1";
            lblUserName1.Size = new Size(72, 23);
            lblUserName1.TabIndex = 1;
            lblUserName1.Text = "TRỐNG";
            lblUserName1.TextChanged += lblUserName1_TextChanged;
            // 
            // picAvatar1
            // 
            picAvatar1.Image = Properties.Resources._001_scientist;
            picAvatar1.Location = new Point(6, 21);
            picAvatar1.Margin = new Padding(3, 4, 3, 4);
            picAvatar1.Name = "picAvatar1";
            picAvatar1.Size = new Size(50, 50);
            picAvatar1.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar1.TabIndex = 0;
            picAvatar1.TabStop = false;
            // 
            // gbPlayer2
            // 
            gbPlayer2.Controls.Add(lblUserName2);
            gbPlayer2.Controls.Add(picAvatar2);
            gbPlayer2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbPlayer2.Location = new Point(3, 93);
            gbPlayer2.Margin = new Padding(3, 4, 3, 4);
            gbPlayer2.Name = "gbPlayer2";
            gbPlayer2.Padding = new Padding(3, 4, 3, 4);
            gbPlayer2.Size = new Size(230, 81);
            gbPlayer2.TabIndex = 0;
            gbPlayer2.TabStop = false;
            // 
            // lblUserName2
            // 
            lblUserName2.AutoSize = true;
            lblUserName2.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName2.ForeColor = Color.White;
            lblUserName2.Location = new Point(62, 37);
            lblUserName2.Name = "lblUserName2";
            lblUserName2.Size = new Size(72, 23);
            lblUserName2.TabIndex = 1;
            lblUserName2.Text = "TRỐNG";
            // 
            // picAvatar2
            // 
            picAvatar2.Image = Properties.Resources._002_werewolf;
            picAvatar2.Location = new Point(6, 21);
            picAvatar2.Margin = new Padding(3, 4, 3, 4);
            picAvatar2.Name = "picAvatar2";
            picAvatar2.Size = new Size(50, 50);
            picAvatar2.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar2.TabIndex = 0;
            picAvatar2.TabStop = false;
            // 
            // gbPlayer3
            // 
            gbPlayer3.Controls.Add(lblUserName3);
            gbPlayer3.Controls.Add(picAvatar3);
            gbPlayer3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbPlayer3.Location = new Point(3, 182);
            gbPlayer3.Margin = new Padding(3, 4, 3, 4);
            gbPlayer3.Name = "gbPlayer3";
            gbPlayer3.Padding = new Padding(3, 4, 3, 4);
            gbPlayer3.Size = new Size(230, 81);
            gbPlayer3.TabIndex = 0;
            gbPlayer3.TabStop = false;
            // 
            // lblUserName3
            // 
            lblUserName3.AutoSize = true;
            lblUserName3.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName3.ForeColor = Color.White;
            lblUserName3.Location = new Point(62, 37);
            lblUserName3.Name = "lblUserName3";
            lblUserName3.Size = new Size(72, 23);
            lblUserName3.TabIndex = 1;
            lblUserName3.Text = "TRỐNG";
            // 
            // picAvatar3
            // 
            picAvatar3.Image = Properties.Resources._003_pumpkin;
            picAvatar3.Location = new Point(6, 21);
            picAvatar3.Margin = new Padding(3, 4, 3, 4);
            picAvatar3.Name = "picAvatar3";
            picAvatar3.Size = new Size(50, 50);
            picAvatar3.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar3.TabIndex = 0;
            picAvatar3.TabStop = false;
            // 
            // gbPlayer4
            // 
            gbPlayer4.Controls.Add(lblUserName4);
            gbPlayer4.Controls.Add(picAvatar4);
            gbPlayer4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbPlayer4.Location = new Point(3, 271);
            gbPlayer4.Margin = new Padding(3, 4, 3, 4);
            gbPlayer4.Name = "gbPlayer4";
            gbPlayer4.Padding = new Padding(3, 4, 3, 4);
            gbPlayer4.Size = new Size(230, 81);
            gbPlayer4.TabIndex = 0;
            gbPlayer4.TabStop = false;
            // 
            // lblUserName4
            // 
            lblUserName4.AutoSize = true;
            lblUserName4.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName4.ForeColor = Color.White;
            lblUserName4.Location = new Point(62, 37);
            lblUserName4.Name = "lblUserName4";
            lblUserName4.Size = new Size(72, 23);
            lblUserName4.TabIndex = 1;
            lblUserName4.Text = "TRỐNG";
            // 
            // picAvatar4
            // 
            picAvatar4.Image = Properties.Resources._004_nurse;
            picAvatar4.Location = new Point(6, 21);
            picAvatar4.Margin = new Padding(3, 4, 3, 4);
            picAvatar4.Name = "picAvatar4";
            picAvatar4.Size = new Size(50, 50);
            picAvatar4.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar4.TabIndex = 0;
            picAvatar4.TabStop = false;
            // 
            // gbPlayer5
            // 
            gbPlayer5.Controls.Add(lblUserName5);
            gbPlayer5.Controls.Add(picAvatar5);
            gbPlayer5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbPlayer5.Location = new Point(239, 4);
            gbPlayer5.Margin = new Padding(3, 4, 3, 4);
            gbPlayer5.Name = "gbPlayer5";
            gbPlayer5.Padding = new Padding(3, 4, 3, 4);
            gbPlayer5.Size = new Size(230, 81);
            gbPlayer5.TabIndex = 0;
            gbPlayer5.TabStop = false;
            // 
            // lblUserName5
            // 
            lblUserName5.AutoSize = true;
            lblUserName5.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName5.ForeColor = Color.White;
            lblUserName5.Location = new Point(62, 37);
            lblUserName5.Name = "lblUserName5";
            lblUserName5.Size = new Size(72, 23);
            lblUserName5.TabIndex = 1;
            lblUserName5.Text = "TRỐNG";
            // 
            // picAvatar5
            // 
            picAvatar5.Image = Properties.Resources._005_magician;
            picAvatar5.Location = new Point(6, 21);
            picAvatar5.Margin = new Padding(3, 4, 3, 4);
            picAvatar5.Name = "picAvatar5";
            picAvatar5.Size = new Size(50, 50);
            picAvatar5.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar5.TabIndex = 0;
            picAvatar5.TabStop = false;
            // 
            // gbPlayer6
            // 
            gbPlayer6.Controls.Add(lblUserName6);
            gbPlayer6.Controls.Add(picAvatar6);
            gbPlayer6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbPlayer6.Location = new Point(239, 93);
            gbPlayer6.Margin = new Padding(3, 4, 3, 4);
            gbPlayer6.Name = "gbPlayer6";
            gbPlayer6.Padding = new Padding(3, 4, 3, 4);
            gbPlayer6.Size = new Size(230, 81);
            gbPlayer6.TabIndex = 0;
            gbPlayer6.TabStop = false;
            // 
            // lblUserName6
            // 
            lblUserName6.AutoSize = true;
            lblUserName6.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName6.ForeColor = Color.White;
            lblUserName6.Location = new Point(62, 37);
            lblUserName6.Name = "lblUserName6";
            lblUserName6.Size = new Size(72, 23);
            lblUserName6.TabIndex = 1;
            lblUserName6.Text = "TRỐNG";
            // 
            // picAvatar6
            // 
            picAvatar6.Image = Properties.Resources._006_unicorn;
            picAvatar6.Location = new Point(6, 21);
            picAvatar6.Margin = new Padding(3, 4, 3, 4);
            picAvatar6.Name = "picAvatar6";
            picAvatar6.Size = new Size(50, 50);
            picAvatar6.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar6.TabIndex = 0;
            picAvatar6.TabStop = false;
            // 
            // gbPlayer7
            // 
            gbPlayer7.Controls.Add(lblUserName7);
            gbPlayer7.Controls.Add(picAvatar7);
            gbPlayer7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbPlayer7.Location = new Point(239, 182);
            gbPlayer7.Margin = new Padding(3, 4, 3, 4);
            gbPlayer7.Name = "gbPlayer7";
            gbPlayer7.Padding = new Padding(3, 4, 3, 4);
            gbPlayer7.Size = new Size(230, 81);
            gbPlayer7.TabIndex = 0;
            gbPlayer7.TabStop = false;
            // 
            // lblUserName7
            // 
            lblUserName7.AutoSize = true;
            lblUserName7.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName7.ForeColor = Color.White;
            lblUserName7.Location = new Point(62, 37);
            lblUserName7.Name = "lblUserName7";
            lblUserName7.Size = new Size(72, 23);
            lblUserName7.TabIndex = 1;
            lblUserName7.Text = "TRỐNG";
            // 
            // picAvatar7
            // 
            picAvatar7.Image = Properties.Resources._007_wrestler;
            picAvatar7.Location = new Point(6, 21);
            picAvatar7.Margin = new Padding(3, 4, 3, 4);
            picAvatar7.Name = "picAvatar7";
            picAvatar7.Size = new Size(50, 50);
            picAvatar7.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar7.TabIndex = 0;
            picAvatar7.TabStop = false;
            // 
            // gbPlayer8
            // 
            gbPlayer8.Controls.Add(lblUserName8);
            gbPlayer8.Controls.Add(picAvatar8);
            gbPlayer8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbPlayer8.Location = new Point(239, 271);
            gbPlayer8.Margin = new Padding(3, 4, 3, 4);
            gbPlayer8.Name = "gbPlayer8";
            gbPlayer8.Padding = new Padding(3, 4, 3, 4);
            gbPlayer8.Size = new Size(230, 81);
            gbPlayer8.TabIndex = 0;
            gbPlayer8.TabStop = false;
            // 
            // lblUserName8
            // 
            lblUserName8.AutoSize = true;
            lblUserName8.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName8.ForeColor = Color.White;
            lblUserName8.Location = new Point(62, 37);
            lblUserName8.Name = "lblUserName8";
            lblUserName8.Size = new Size(72, 23);
            lblUserName8.TabIndex = 1;
            lblUserName8.Text = "TRỐNG";
            // 
            // picAvatar8
            // 
            picAvatar8.Image = Properties.Resources._008_gnome;
            picAvatar8.Location = new Point(6, 21);
            picAvatar8.Margin = new Padding(3, 4, 3, 4);
            picAvatar8.Name = "picAvatar8";
            picAvatar8.Size = new Size(50, 50);
            picAvatar8.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar8.TabIndex = 0;
            picAvatar8.TabStop = false;
            // 
            // btnInvite
            // 
            btnInvite.BackColor = Color.White;
            btnInvite.FlatStyle = FlatStyle.Flat;
            btnInvite.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInvite.ForeColor = Color.MidnightBlue;
            btnInvite.Location = new Point(14, 485);
            btnInvite.Margin = new Padding(3, 4, 3, 4);
            btnInvite.Name = "btnInvite";
            btnInvite.Size = new Size(130, 45);
            btnInvite.TabIndex = 1;
            btnInvite.Text = "MỜI";
            btnInvite.UseVisualStyleBackColor = false;
            btnInvite.Visible = false;
            // 
            // btnStartRoom
            // 
            btnStartRoom.BackColor = Color.White;
            btnStartRoom.FlatStyle = FlatStyle.Flat;
            btnStartRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStartRoom.ForeColor = Color.MidnightBlue;
            btnStartRoom.Location = new Point(1058, 485);
            btnStartRoom.Margin = new Padding(3, 4, 3, 4);
            btnStartRoom.Name = "btnStartRoom";
            btnStartRoom.Size = new Size(130, 45);
            btnStartRoom.TabIndex = 1;
            btnStartRoom.Text = "BẮT ĐẦU";
            btnStartRoom.UseVisualStyleBackColor = false;
            btnStartRoom.Click += btnStartRoom_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Indigo;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.AliceBlue;
            btnBack.Location = new Point(12, 15);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(146, 43);
            btnBack.TabIndex = 1;
            btnBack.Text = "◀ QUAY LẠI";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lstChat
            // 
            lstChat.BackColor = SystemColors.Window;
            lstChat.FormattingEnabled = true;
            lstChat.Location = new Point(262, 112);
            lstChat.Margin = new Padding(3, 4, 3, 4);
            lstChat.Name = "lstChat";
            lstChat.Size = new Size(288, 424);
            lstChat.TabIndex = 30;
            // 
            // lblNumberofPlayer
            // 
            lblNumberofPlayer.AutoSize = true;
            lblNumberofPlayer.BackColor = Color.Transparent;
            lblNumberofPlayer.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumberofPlayer.ForeColor = Color.White;
            lblNumberofPlayer.Location = new Point(37, 110);
            lblNumberofPlayer.Name = "lblNumberofPlayer";
            lblNumberofPlayer.Size = new Size(201, 31);
            lblNumberofPlayer.TabIndex = 31;
            lblNumberofPlayer.Text = "NGƯỜI CHƠI 1/2";
            lblNumberofPlayer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelTimer
            // 
            panelTimer.BorderStyle = BorderStyle.FixedSingle;
            panelTimer.Controls.Add(pictureBox4);
            panelTimer.Controls.Add(cbbTimer);
            panelTimer.Controls.Add(lblTimerDescription);
            panelTimer.Controls.Add(lblTimer);
            panelTimer.Dock = DockStyle.Top;
            panelTimer.Location = new Point(0, 0);
            panelTimer.Margin = new Padding(3, 4, 3, 4);
            panelTimer.Name = "panelTimer";
            panelTimer.Size = new Size(631, 100);
            panelTimer.TabIndex = 0;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(15, 25);
            pictureBox4.Margin = new Padding(3, 4, 3, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(50, 50);
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // cbbTimer
            // 
            cbbTimer.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTimer.Font = new Font("Segoe UI Semilight", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbTimer.FormattingEnabled = true;
            cbbTimer.Items.AddRange(new object[] { "10 GIÂY", "15 GIÂY", "30 GIÂY", "60 GIÂY" });
            cbbTimer.Location = new Point(456, 30);
            cbbTimer.Margin = new Padding(3, 4, 3, 4);
            cbbTimer.Name = "cbbTimer";
            cbbTimer.Size = new Size(165, 39);
            cbbTimer.TabIndex = 2;
            cbbTimer.SelectedIndexChanged += cbbTimer_SelectedIndexChanged;
            // 
            // lblTimerDescription
            // 
            lblTimerDescription.AutoSize = true;
            lblTimerDescription.ForeColor = Color.White;
            lblTimerDescription.Location = new Point(90, 60);
            lblTimerDescription.Name = "lblTimerDescription";
            lblTimerDescription.Size = new Size(160, 20);
            lblTimerDescription.TabIndex = 1;
            lblTimerDescription.Text = "Thời gian cho mỗi lượt";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimer.ForeColor = Color.White;
            lblTimer.Location = new Point(90, 25);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(117, 28);
            lblTimer.TabIndex = 0;
            lblTimer.Text = "THỜI GIAN";
            // 
            // cbbNumofPlayer
            // 
            cbbNumofPlayer.BackColor = SystemColors.Window;
            cbbNumofPlayer.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbNumofPlayer.Font = new Font("Segoe UI Semilight", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbNumofPlayer.FormattingEnabled = true;
            cbbNumofPlayer.Items.AddRange(new object[] { "2 NGƯỜI", "3 NGƯỜI", "4 NGƯỜI", "5 NGƯỜI", "6 NGƯỜI", "7 NGƯỜI", "8 NGƯỜI" });
            cbbNumofPlayer.Location = new Point(10, 39);
            cbbNumofPlayer.Margin = new Padding(3, 4, 3, 4);
            cbbNumofPlayer.Name = "cbbNumofPlayer";
            cbbNumofPlayer.Size = new Size(237, 39);
            cbbNumofPlayer.TabIndex = 0;
            cbbNumofPlayer.SelectedIndexChanged += cbbNumofPlayer_SelectedIndexChanged;
            // 
            // txtInRoomMessage
            // 
            txtInRoomMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtInRoomMessage.Location = new Point(262, 541);
            txtInRoomMessage.Margin = new Padding(3, 4, 3, 4);
            txtInRoomMessage.Name = "txtInRoomMessage";
            txtInRoomMessage.Size = new Size(207, 34);
            txtInRoomMessage.TabIndex = 33;
            // 
            // btnSendMsg
            // 
            btnSendMsg.BackColor = Color.Transparent;
            btnSendMsg.BackgroundImageLayout = ImageLayout.None;
            btnSendMsg.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSendMsg.ForeColor = Color.Indigo;
            btnSendMsg.Location = new Point(475, 541);
            btnSendMsg.Margin = new Padding(3, 4, 3, 4);
            btnSendMsg.Name = "btnSendMsg";
            btnSendMsg.Size = new Size(75, 34);
            btnSendMsg.TabIndex = 34;
            btnSendMsg.Text = "GỬI";
            btnSendMsg.UseVisualStyleBackColor = false;
            btnSendMsg.Click += btnSendMsg_Click;
            // 
            // panelTurns
            // 
            panelTurns.BorderStyle = BorderStyle.FixedSingle;
            panelTurns.Controls.Add(pictureBox7);
            panelTurns.Controls.Add(cbbTurns);
            panelTurns.Controls.Add(lblTurnDescription);
            panelTurns.Controls.Add(lblTurn);
            panelTurns.Location = new Point(0, 180);
            panelTurns.Margin = new Padding(3, 4, 3, 4);
            panelTurns.Name = "panelTurns";
            panelTurns.Size = new Size(631, 100);
            panelTurns.TabIndex = 0;
            // 
            // pictureBox7
            // 
            pictureBox7.Location = new Point(15, 25);
            pictureBox7.Margin = new Padding(3, 4, 3, 4);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(50, 50);
            pictureBox7.TabIndex = 3;
            pictureBox7.TabStop = false;
            // 
            // cbbTurns
            // 
            cbbTurns.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTurns.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbbTurns.FormattingEnabled = true;
            cbbTurns.Items.AddRange(new object[] { "SỐ NGƯỜI CHƠI", "SỐ NGƯỜI CHƠI + 1", "4 LƯỢT", "5 LƯỢT", "6 LƯỢT", "7 LƯỢT", "8 LƯỢT", "9 LƯỢT", "10 LƯỢT" });
            cbbTurns.Location = new Point(340, 30);
            cbbTurns.Margin = new Padding(3, 4, 3, 4);
            cbbTurns.Name = "cbbTurns";
            cbbTurns.Size = new Size(281, 39);
            cbbTurns.TabIndex = 2;
            cbbTurns.SelectedIndexChanged += cbbTurns_SelectedIndexChanged;
            // 
            // lblTurnDescription
            // 
            lblTurnDescription.AutoSize = true;
            lblTurnDescription.ForeColor = Color.White;
            lblTurnDescription.Location = new Point(90, 60);
            lblTurnDescription.Name = "lblTurnDescription";
            lblTurnDescription.Size = new Size(220, 20);
            lblTurnDescription.TabIndex = 1;
            lblTurnDescription.Text = "Số lượt viết cho mỗi câu chuyện";
            // 
            // lblTurn
            // 
            lblTurn.AutoSize = true;
            lblTurn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTurn.ForeColor = Color.White;
            lblTurn.Location = new Point(90, 25);
            lblTurn.Name = "lblTurn";
            lblTurn.Size = new Size(98, 28);
            lblTurn.TabIndex = 0;
            lblTurn.Text = "SỐ LƯỢT";
            // 
            // panelTransferRole
            // 
            panelTransferRole.BorderStyle = BorderStyle.FixedSingle;
            panelTransferRole.Controls.Add(txtHost);
            panelTransferRole.Controls.Add(pictureBox9);
            panelTransferRole.Controls.Add(labelHostDescription);
            panelTransferRole.Controls.Add(lblHosting);
            panelTransferRole.Location = new Point(0, 360);
            panelTransferRole.Margin = new Padding(3, 4, 3, 4);
            panelTransferRole.Name = "panelTransferRole";
            panelTransferRole.Size = new Size(631, 100);
            panelTransferRole.TabIndex = 0;
            // 
            // txtHost
            // 
            txtHost.Enabled = false;
            txtHost.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtHost.Location = new Point(456, 30);
            txtHost.Name = "txtHost";
            txtHost.ReadOnly = true;
            txtHost.Size = new Size(165, 38);
            txtHost.TabIndex = 4;
            txtHost.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox9
            // 
            pictureBox9.Location = new Point(15, 25);
            pictureBox9.Margin = new Padding(3, 4, 3, 4);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(50, 50);
            pictureBox9.TabIndex = 3;
            pictureBox9.TabStop = false;
            // 
            // labelHostDescription
            // 
            labelHostDescription.AutoSize = true;
            labelHostDescription.ForeColor = Color.White;
            labelHostDescription.Location = new Point(90, 60);
            labelHostDescription.Name = "labelHostDescription";
            labelHostDescription.Size = new Size(174, 20);
            labelHostDescription.TabIndex = 1;
            labelHostDescription.Text = "Quyền cài đặt và bắt đầu";
            // 
            // lblHosting
            // 
            lblHosting.AutoSize = true;
            lblHosting.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHosting.ForeColor = Color.White;
            lblHosting.Location = new Point(90, 25);
            lblHosting.Name = "lblHosting";
            lblHosting.Size = new Size(139, 28);
            lblHosting.TabIndex = 0;
            lblHosting.Text = "QUYỀN HOST";
            // 
            // panelSettings
            // 
            panelSettings.BackColor = Color.Indigo;
            panelSettings.Controls.Add(panelTurns);
            panelSettings.Controls.Add(panelTransferRole);
            panelSettings.Controls.Add(panelTimer);
            panelSettings.Location = new Point(554, 1);
            panelSettings.Margin = new Padding(3, 4, 3, 4);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(631, 463);
            panelSettings.TabIndex = 35;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = Properties.Resources.Story;
            picLogo.Location = new Point(164, 50);
            picLogo.Margin = new Padding(3, 4, 3, 4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(265, 195);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 29;
            picLogo.TabStop = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.Image = Properties.Resources.close;
            btnExit.Location = new Point(1153, 13);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(35, 35);
            btnExit.SizeMode = PictureBoxSizeMode.StretchImage;
            btnExit.TabIndex = 27;
            btnExit.TabStop = false;
            btnExit.Click += btnExit_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.MidnightBlue;
            button1.Location = new Point(17, 489);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(130, 45);
            button1.TabIndex = 1;
            button1.Text = "MỜI";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.MidnightBlue;
            button3.Location = new Point(1061, 489);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(130, 45);
            button3.TabIndex = 1;
            button3.Text = "BẮT ĐẦU";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Indigo;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.AliceBlue;
            button4.Location = new Point(15, 19);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(146, 43);
            button4.TabIndex = 1;
            button4.Text = "QUAY LẠI";
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnBack_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(20, 199);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(237, 380);
            panel2.TabIndex = 36;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Location = new Point(266, 116);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(289, 463);
            panel3.TabIndex = 36;
            // 
            // panelHost
            // 
            panelHost.BackColor = Color.Transparent;
            panelHost.Controls.Add(panelSettings);
            panelHost.Controls.Add(btnInvite);
            panelHost.Controls.Add(panel1);
            panelHost.Controls.Add(btnStartRoom);
            panelHost.Controls.Add(cbbNumofPlayer);
            panelHost.Controls.Add(button3);
            panelHost.Controls.Add(button1);
            panelHost.Location = new Point(5, 111);
            panelHost.Name = "panelHost";
            panelHost.Size = new Size(1188, 547);
            panelHost.TabIndex = 37;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(558, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(630, 463);
            panel1.TabIndex = 36;
            // 
            // lblWaiting
            // 
            lblWaiting.AutoSize = true;
            lblWaiting.BackColor = Color.Transparent;
            lblWaiting.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWaiting.ForeColor = Color.White;
            lblWaiting.Location = new Point(706, 500);
            lblWaiting.Name = "lblWaiting";
            lblWaiting.Size = new Size(384, 20);
            lblWaiting.TabIndex = 39;
            lblWaiting.Text = "CHỜ QUẢN TRÒ THIẾT LẬP VÀ BẮT ĐẦU TRÒ CHƠI...";
            lblWaiting.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picWaiting
            // 
            picWaiting.BackColor = Color.Transparent;
            picWaiting.Image = Properties.Resources.loading_loader;
            picWaiting.Location = new Point(639, 494);
            picWaiting.Name = "picWaiting";
            picWaiting.Size = new Size(61, 26);
            picWaiting.SizeMode = PictureBoxSizeMode.Zoom;
            picWaiting.TabIndex = 40;
            picWaiting.TabStop = false;
            // 
            // panelWaitingRoom
            // 
            panelWaitingRoom.BackColor = Color.Transparent;
            panelWaitingRoom.Controls.Add(panel5);
            panelWaitingRoom.Controls.Add(lblWaiting);
            panelWaitingRoom.Controls.Add(picWaiting);
            panelWaitingRoom.Controls.Add(panel9);
            panelWaitingRoom.Controls.Add(flowLayoutPanel1);
            panelWaitingRoom.Controls.Add(panel11);
            panelWaitingRoom.Location = new Point(5, 111);
            panelWaitingRoom.Name = "panelWaitingRoom";
            panelWaitingRoom.Size = new Size(1188, 547);
            panelWaitingRoom.TabIndex = 41;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Indigo;
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(panel8);
            panel5.Location = new Point(554, 1);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(631, 463);
            panel5.TabIndex = 35;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(txtTurns);
            panel6.Controls.Add(pictureBox6);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(0, 180);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(631, 100);
            panel6.TabIndex = 0;
            // 
            // txtTurns
            // 
            txtTurns.BackColor = Color.White;
            txtTurns.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTurns.Location = new Point(340, 33);
            txtTurns.Name = "txtTurns";
            txtTurns.ReadOnly = true;
            txtTurns.Size = new Size(281, 38);
            txtTurns.TabIndex = 5;
            // 
            // pictureBox6
            // 
            pictureBox6.Location = new Point(15, 25);
            pictureBox6.Margin = new Padding(3, 4, 3, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(50, 50);
            pictureBox6.TabIndex = 3;
            pictureBox6.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(90, 60);
            label4.Name = "label4";
            label4.Size = new Size(220, 20);
            label4.TabIndex = 1;
            label4.Text = "Số lượt viết cho mỗi câu chuyện";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(90, 25);
            label5.Name = "label5";
            label5.Size = new Size(98, 28);
            label5.TabIndex = 0;
            label5.Text = "SỐ LƯỢT";
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(txtHost_ReadOnly);
            panel7.Controls.Add(pictureBox8);
            panel7.Controls.Add(label6);
            panel7.Controls.Add(label7);
            panel7.Location = new Point(0, 360);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(631, 100);
            panel7.TabIndex = 0;
            // 
            // txtHost_ReadOnly
            // 
            txtHost_ReadOnly.BackColor = Color.White;
            txtHost_ReadOnly.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHost_ReadOnly.Location = new Point(456, 35);
            txtHost_ReadOnly.Name = "txtHost_ReadOnly";
            txtHost_ReadOnly.ReadOnly = true;
            txtHost_ReadOnly.Size = new Size(165, 38);
            txtHost_ReadOnly.TabIndex = 5;
            // 
            // pictureBox8
            // 
            pictureBox8.Location = new Point(15, 25);
            pictureBox8.Margin = new Padding(3, 4, 3, 4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(50, 50);
            pictureBox8.TabIndex = 3;
            pictureBox8.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(90, 60);
            label6.Name = "label6";
            label6.Size = new Size(251, 20);
            label6.TabIndex = 1;
            label6.Text = "Quyền cài đặt và bắt đầu câu chuyện";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(90, 25);
            label7.Name = "label7";
            label7.Size = new Size(117, 28);
            label7.TabIndex = 0;
            label7.Text = "QUẢN TRÒ";
            // 
            // panel8
            // 
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(txtTimer);
            panel8.Controls.Add(pictureBox10);
            panel8.Controls.Add(label8);
            panel8.Controls.Add(label9);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Margin = new Padding(3, 4, 3, 4);
            panel8.Name = "panel8";
            panel8.Size = new Size(631, 100);
            panel8.TabIndex = 0;
            // 
            // txtTimer
            // 
            txtTimer.BackColor = Color.White;
            txtTimer.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimer.Location = new Point(456, 31);
            txtTimer.Name = "txtTimer";
            txtTimer.ReadOnly = true;
            txtTimer.Size = new Size(165, 38);
            txtTimer.TabIndex = 5;
            // 
            // pictureBox10
            // 
            pictureBox10.Location = new Point(15, 25);
            pictureBox10.Margin = new Padding(3, 4, 3, 4);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(50, 50);
            pictureBox10.TabIndex = 3;
            pictureBox10.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(90, 60);
            label8.Name = "label8";
            label8.Size = new Size(160, 20);
            label8.TabIndex = 1;
            label8.Text = "Thời gian cho mỗi lượt";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(90, 25);
            label9.Name = "label9";
            label9.Size = new Size(117, 28);
            label9.TabIndex = 0;
            label9.Text = "THỜI GIAN";
            // 
            // panel9
            // 
            panel9.BackColor = Color.Black;
            panel9.Location = new Point(558, 5);
            panel9.Name = "panel9";
            panel9.Size = new Size(630, 463);
            panel9.TabIndex = 36;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Indigo;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(groupBox1);
            flowLayoutPanel1.Controls.Add(groupBox2);
            flowLayoutPanel1.Controls.Add(groupBox3);
            flowLayoutPanel1.Controls.Add(groupBox4);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(7, 84);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(240, 380);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(pictureBox11);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(3, 4);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(230, 83);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(62, 38);
            label11.Name = "label11";
            label11.Size = new Size(72, 23);
            label11.TabIndex = 1;
            label11.Text = "TRỐNG";
            // 
            // pictureBox11
            // 
            pictureBox11.Location = new Point(6, 23);
            pictureBox11.Margin = new Padding(3, 4, 3, 4);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(50, 50);
            pictureBox11.TabIndex = 0;
            pictureBox11.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(pictureBox12);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(3, 95);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(230, 83);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(62, 38);
            label12.Name = "label12";
            label12.Size = new Size(72, 23);
            label12.TabIndex = 1;
            label12.Text = "TRỐNG";
            // 
            // pictureBox12
            // 
            pictureBox12.Location = new Point(6, 23);
            pictureBox12.Margin = new Padding(3, 4, 3, 4);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new Size(50, 50);
            pictureBox12.TabIndex = 0;
            pictureBox12.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(pictureBox13);
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(3, 186);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(230, 83);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(62, 38);
            label13.Name = "label13";
            label13.Size = new Size(72, 23);
            label13.TabIndex = 1;
            label13.Text = "TRỐNG";
            // 
            // pictureBox13
            // 
            pictureBox13.Location = new Point(6, 23);
            pictureBox13.Margin = new Padding(3, 4, 3, 4);
            pictureBox13.Name = "pictureBox13";
            pictureBox13.Size = new Size(50, 50);
            pictureBox13.TabIndex = 0;
            pictureBox13.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(pictureBox14);
            groupBox4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(3, 277);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(230, 83);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.White;
            label14.Location = new Point(62, 38);
            label14.Name = "label14";
            label14.Size = new Size(72, 23);
            label14.TabIndex = 1;
            label14.Text = "TRỐNG";
            // 
            // pictureBox14
            // 
            pictureBox14.Location = new Point(6, 23);
            pictureBox14.Margin = new Padding(3, 4, 3, 4);
            pictureBox14.Name = "pictureBox14";
            pictureBox14.Size = new Size(50, 50);
            pictureBox14.TabIndex = 0;
            pictureBox14.TabStop = false;
            // 
            // panel11
            // 
            panel11.BackColor = Color.Black;
            panel11.Location = new Point(14, 88);
            panel11.Margin = new Padding(3, 4, 3, 4);
            panel11.Name = "panel11";
            panel11.Size = new Size(237, 380);
            panel11.TabIndex = 36;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.BackColor = Color.Transparent;
            lblRoomNumber.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomNumber.ForeColor = Color.White;
            lblRoomNumber.Location = new Point(795, 48);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(106, 38);
            lblRoomNumber.TabIndex = 42;
            lblRoomNumber.Text = "ROOM";
            lblRoomNumber.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelPlaying
            // 
            panelPlaying.BorderStyle = BorderStyle.FixedSingle;
            panelPlaying.Controls.Add(rtfSentence);
            panelPlaying.Controls.Add(picWrite);
            panelPlaying.Controls.Add(barTimer);
            panelPlaying.Controls.Add(btnSubmit);
            panelPlaying.Controls.Add(txtSentence);
            panelPlaying.Controls.Add(picLogo);
            panelPlaying.Location = new Point(558, 112);
            panelPlaying.Name = "panelPlaying";
            panelPlaying.Size = new Size(631, 463);
            panelPlaying.TabIndex = 43;
            // 
            // rtfSentence
            // 
            rtfSentence.BackColor = Color.White;
            rtfSentence.BorderStyle = BorderStyle.None;
            rtfSentence.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtfSentence.Location = new Point(121, 240);
            rtfSentence.Name = "rtfSentence";
            rtfSentence.ReadOnly = true;
            rtfSentence.Size = new Size(386, 120);
            rtfSentence.TabIndex = 30;
            rtfSentence.Text = "";
            // 
            // picWrite
            // 
            picWrite.BackColor = Color.Transparent;
            picWrite.Image = Properties.Resources.Word_2;
            picWrite.Location = new Point(209, 263);
            picWrite.Name = "picWrite";
            picWrite.Size = new Size(231, 62);
            picWrite.SizeMode = PictureBoxSizeMode.StretchImage;
            picWrite.TabIndex = 3;
            picWrite.TabStop = false;
            // 
            // barTimer
            // 
            barTimer.ForeColor = Color.DarkViolet;
            barTimer.Location = new Point(17, 14);
            barTimer.Name = "barTimer";
            barTimer.RightToLeftLayout = true;
            barTimer.Size = new Size(603, 29);
            barTimer.Step = 5;
            barTimer.Style = ProgressBarStyle.Continuous;
            barTimer.TabIndex = 2;
            barTimer.Value = 100;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(522, 384);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(98, 42);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "XONG";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtSentence
            // 
            txtSentence.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSentence.Location = new Point(17, 383);
            txtSentence.Name = "txtSentence";
            txtSentence.Size = new Size(499, 43);
            txtSentence.TabIndex = 0;
            // 
            // countdownTimer
            // 
            countdownTimer.Tick += countdownTimer_Tick;
            // 
            // panelEnd
            // 
            panelEnd.Controls.Add(btnSave);
            panelEnd.Controls.Add(rtfStory);
            panelEnd.Location = new Point(558, 112);
            panelEnd.Name = "panelEnd";
            panelEnd.Size = new Size(631, 463);
            panelEnd.TabIndex = 44;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(270, 389);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 1;
            btnSave.Text = "LƯU";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // rtfStory
            // 
            rtfStory.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtfStory.Location = new Point(15, 17);
            rtfStory.Name = "rtfStory";
            rtfStory.Size = new Size(602, 344);
            rtfStory.TabIndex = 0;
            rtfStory.Text = "";
            // 
            // frmRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.BACKGROUND;
            ClientSize = new Size(1200, 670);
            Controls.Add(panelPlaying);
            Controls.Add(flpanelPlayerList);
            Controls.Add(panel2);
            Controls.Add(lblRoomNumber);
            Controls.Add(btnSendMsg);
            Controls.Add(txtInRoomMessage);
            Controls.Add(lstChat);
            Controls.Add(panel3);
            Controls.Add(lblNumberofPlayer);
            Controls.Add(btnExit);
            Controls.Add(btnBack);
            Controls.Add(button4);
            Controls.Add(panelHost);
            Controls.Add(panelWaitingRoom);
            Controls.Add(panelEnd);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmRoom";
            Text = "Room";
            FormClosing += frmRoom_FormClosing;
            Load += Room_Load;
            flpanelPlayerList.ResumeLayout(false);
            gbPlayer1.ResumeLayout(false);
            gbPlayer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar1).EndInit();
            gbPlayer2.ResumeLayout(false);
            gbPlayer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar2).EndInit();
            gbPlayer3.ResumeLayout(false);
            gbPlayer3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar3).EndInit();
            gbPlayer4.ResumeLayout(false);
            gbPlayer4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar4).EndInit();
            gbPlayer5.ResumeLayout(false);
            gbPlayer5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar5).EndInit();
            gbPlayer6.ResumeLayout(false);
            gbPlayer6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar6).EndInit();
            gbPlayer7.ResumeLayout(false);
            gbPlayer7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar7).EndInit();
            gbPlayer8.ResumeLayout(false);
            gbPlayer8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar8).EndInit();
            panelTimer.ResumeLayout(false);
            panelTimer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panelTurns.ResumeLayout(false);
            panelTurns.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            panelTransferRole.ResumeLayout(false);
            panelTransferRole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            panelSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnExit).EndInit();
            panelHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picWaiting).EndInit();
            panelWaitingRoom.ResumeLayout(false);
            panelWaitingRoom.PerformLayout();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox14).EndInit();
            panelPlaying.ResumeLayout(false);
            panelPlaying.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picWrite).EndInit();
            panelEnd.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpanelPlayerList;
        private System.Windows.Forms.Button btnInvite;
        private System.Windows.Forms.Button btnStartRoom;
        private System.Windows.Forms.GroupBox gbPlayer1;
        private System.Windows.Forms.Label lblUserName1;
        private System.Windows.Forms.PictureBox picAvatar1;
        private System.Windows.Forms.GroupBox gbPlayer2;
        private System.Windows.Forms.Label lblUserName2;
        private System.Windows.Forms.PictureBox picAvatar2;
        private System.Windows.Forms.GroupBox gbPlayer3;
        private System.Windows.Forms.Label lblUserName3;
        private System.Windows.Forms.PictureBox picAvatar3;
        private System.Windows.Forms.GroupBox gbPlayer4;
        private System.Windows.Forms.Label lblUserName4;
        private System.Windows.Forms.PictureBox picAvatar4;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.Label lblNumberofPlayer;
        private System.Windows.Forms.Panel panelTimer;
        private System.Windows.Forms.ComboBox cbbNumofPlayer;
        private System.Windows.Forms.TextBox txtInRoomMessage;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ComboBox cbbTimer;
        private System.Windows.Forms.Label lblTimerDescription;
        private System.Windows.Forms.Panel panelTurns;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.ComboBox cbbTurns;
        private System.Windows.Forms.Label lblTurnDescription;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Panel panelTransferRole;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label labelHostDescription;
        private System.Windows.Forms.Label lblHosting;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Panel panelHost;
        private Panel panel1;
        private Label lblWaiting;
        private PictureBox picWaiting;
        private Panel panelWaitingRoom;
        private Panel panel5;
        private Panel panel6;
        private PictureBox pictureBox6;
        private Label label4;
        private Label label5;
        private Panel panel8;
        private PictureBox pictureBox10;
        private Label label8;
        private Label label9;
        private Button button5;
        private Panel panel9;
        private Button button7;
        private Button button8;
        private Label lblNumofPlayer_Normal;
        private Button button9;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox1;
        private Label label11;
        private PictureBox pictureBox11;
        private GroupBox groupBox2;
        private Label label12;
        private PictureBox pictureBox12;
        private GroupBox groupBox3;
        private Label label13;
        private PictureBox pictureBox13;
        private GroupBox groupBox4;
        private Label label14;
        private PictureBox pictureBox14;
        private Panel panel11;
        private Panel panel7;
        private PictureBox pictureBox8;
        private Label label6;
        private Label label7;
        private Label lblRoomNumber;
        private GroupBox gbPlayer5;
        private Label lblUserName5;
        private PictureBox picAvatar5;
        private GroupBox gbPlayer6;
        private Label lblUserName6;
        private PictureBox picAvatar6;
        private GroupBox gbPlayer7;
        private Label lblUserName7;
        private PictureBox picAvatar7;
        private GroupBox gbPlayer8;
        private Label lblUserName8;
        private PictureBox picAvatar8;
        private TextBox txtHost;
        private TextBox txtHost_ReadOnly;
        private Panel panelPlaying;
        private Button btnSubmit;
        private TextBox txtSentence;
        private ProgressBar barTimer;
        private PictureBox picWrite;
        private TextBox txtTurns;
        private TextBox txtTimer;
        private System.Windows.Forms.Timer countdownTimer;
        private RichTextBox rtfSentence;
        private Panel panelEnd;
        private RichTextBox rtfStory;
        private Button btnSave;
    }
}