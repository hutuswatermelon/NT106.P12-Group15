namespace Client_System
{
    public partial class frmLobby : Form
    {
        private delegate void updateUI(string message);
        private updateUI updateUi;
        public frmLobby()
        {
            InitializeComponent();
            SocketClientSingleton.Instance.CommandReceived += HandleServerCommand;
            updateUi = new updateUI(update);
            this.MouseDown += YourForm_MouseDown;
            this.MouseMove += YourForm_MouseMove;
            this.MouseUp += YourForm_MouseUp;

            for (int i = 0; i < 10; i++)
            {
                SocketClientSingleton.Instance.Infor[i] = new System.Windows.Forms.Label();
                SocketClientSingleton.Instance.Infor[i].Text = SocketClientSingleton.Instance.playerOfRoom[1, i].ToString();
            }

        }

        #region Window Dragging
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void YourForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Kiểm tra xem nút chuột trái có được nhấn không
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                // Lưu vị trí chuột và vị trí form
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }
        private void YourForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                // Tính toán vị trí mới của form
                Point newLocation = new Point(
                    dragFormPoint.X + (Cursor.Position.X - dragCursorPoint.X),
                    dragFormPoint.Y + (Cursor.Position.Y - dragCursorPoint.Y)
                );
                this.Location = newLocation; // Di chuyển form
            }
        }
        private void YourForm_MouseUp(object sender, MouseEventArgs e)
        {
            // Ngừng kéo form khi nút chuột được nhả
            dragging = false;
        }
        #endregion

        private void update(string msg)
        {
            lstChatAll.Items.Add(msg);
            lstChatAll.TopIndex = lstChatAll.Items.Count - 1;
        }
        private frmRoom currentRoom = null;

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            string roomID = ((Button)sender).Tag.ToString();
            int roomIndex = int.Parse(roomID[0].ToString());

            // Check if `frmRoom` is already open
            if (currentRoom == null || currentRoom.IsDisposed)
            {
                // Check if room is full
                if (SocketClientSingleton.Instance.playerOfRoom[1, roomIndex] < SocketClientSingleton.Instance.playerOfRoom[2, roomIndex])
                {
                    // Increment player count
                    SocketClientSingleton.Instance.playerOfRoom[1, roomIndex]++;
                    (this.Controls.Find($"lblNumInRoom{roomIndex}", true).FirstOrDefault() as Label).Text =
                        SocketClientSingleton.Instance.playerOfRoom[1, roomIndex].ToString();

                    // Open the room form
                    currentRoom = new frmRoom(roomIndex);
                    currentRoom.SetLabelText("ROOM " + (roomIndex + 1).ToString(), roomIndex);
                    currentRoom.Show();
                    this.Hide();

                    SocketClientSingleton.Instance.inRoom = true;
                    SocketClientSingleton.Instance.roomNumber = roomIndex;

                    // Send join room message to the server
                    string message = "#_TCP_IR" + roomID[0].ToString();
                    if (SocketClientSingleton.Instance.Client.Connected)
                    {
                        try
                        {
                            SocketClientSingleton.Instance.SendData(message);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi gửi dữ liệu: " + ex.Message, "Send Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Socket chưa kết nối.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Notify that the room is full
                    MessageBox.Show("Phòng đã đầy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Notify that the room is already open
                MessageBox.Show("Bạn đã ở trong phòng.");
            }
        }

        private void HandleServerCommand(ServerCommand command, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HandleServerCommand(command, message)));
                return;
            }
            switch (command)
            {
                case ServerCommand.ChatMessage:
                    updateUi(message.Substring(9));
                    break;
                case ServerCommand.UpdateLobby:

                    int roomIndex = int.Parse(message[8].ToString());
                    int numPlayers = int.Parse(message[9].ToString());
                    (this.Controls.Find($"lblNumInRoom{roomIndex}", true).FirstOrDefault() as Label).Text = numPlayers.ToString();
                    break;
                case ServerCommand.StartRoom:
                    int startedRoomIndex = int.Parse(message[8].ToString());
                    (this.Controls.Find($"btnJoinRoom{startedRoomIndex}", true).FirstOrDefault() as Button).Enabled = false;
                    (this.Controls.Find($"lblRoomStatus{startedRoomIndex}", true).FirstOrDefault() as Label).Text = "Đã bắt đầu";
                    break;
                case ServerCommand.UpdateLobbyforNewJoining:
                    for (int i = 0; i < 10; i++)
                    {
                        (this.Controls.Find($"lblNumInRoom{i}", true).FirstOrDefault() as Label).Text = SocketClientSingleton.Instance.playerOfRoom[1, i].ToString();
                    }
                    break;
                case ServerCommand.EndRoom:
                    int endRoomIndex = int.Parse(message[8].ToString());
                    (this.Controls.Find($"btnJoinRoom{endRoomIndex}", true).FirstOrDefault() as Button).Enabled = true;
                    (this.Controls.Find($"lblRoomStatus{endRoomIndex}", true).FirstOrDefault() as Label).Text = "Chưa bắt đầu";
                    break;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSendLobby_Click(object sender, EventArgs e)
        {
            string str = "#_Chat_00" + txtLobbyMessage.Text;
            SocketClientSingleton.Instance.SendData(str);
            //updateUi("_Client: " + txtSend.Text);
            txtLobbyMessage.Text = "";
        }

        private void btnHowtoplay_Click(object sender, EventArgs e)
        {
            frmRule rule = Application.OpenForms["frmRule"] as frmRule;
            if (rule == null)
            {
                rule = new frmRule();
                rule.Show();
            }
            else
            {
                rule.Show();
            }
        }

        private void picAccSettings_Click(object sender, EventArgs e)
        {
            frmChangePassword pw = Application.OpenForms["frmChangePassword"] as frmChangePassword;
            if (pw == null)
            {
                pw = new frmChangePassword();
                pw.Show();
            }
            else
            {
                pw.Show();
            }
        }
    }
}