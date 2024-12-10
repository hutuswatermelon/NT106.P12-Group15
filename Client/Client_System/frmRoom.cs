using System.Windows.Forms;

namespace Client_System
{
    public partial class frmRoom : Form
    {
        private delegate void updateUI(string message);
        private updateUI updateUi;
        private bool isMaster = false;
        private int roomID;
        private List<string> playerNames = new List<string>(new string[8]);
        private int remainingTime;
        private int time;
        private int currentRound;
        public frmRoom(int roomID)
        {
            InitializeComponent();
            SocketClientSingleton.Instance.CommandReceived += HandleServerCommand;
            SocketClientSingleton.Instance.PlayerCountChanged += OnPlayerCountChanged;
            //SocketClientSingleton.Instance.MasterChanged += OnMasterChanged;
            this.MouseDown += YourForm_MouseDown;
            this.MouseMove += YourForm_MouseMove;
            this.MouseUp += YourForm_MouseUp;
            panelHost.Hide();
            panelHost.Enabled = false;
            this.roomID = roomID;
            SetLabelText("ROOM " + (roomID + 1).ToString(), roomID);
            updateUi = new updateUI(update);
            cbbTimer.SelectedIndex = 1;
            cbbTurns.SelectedIndex = 1;
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // 1 giây
            countdownTimer.Tick += countdownTimer_Tick;
            txtTimer.Text = "15 GIÂY";
            txtTurns.Text = "SỐ NGƯỜI CHƠI + 1";
            rtfSentence.Visible = false;
            currentRound = 0; // Track the current turn number
            panelPlaying.Visible = false;
            panelEnd.Visible = false;
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
        private void OnPlayerCountChanged(int current, int total)
        {
            lblNumberofPlayer.Text = $"NGƯỜI CHƠI {current}/{total}";
            lblNumberofPlayer.Invalidate(); // Forces the label to repaint
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu form Lobby đã mở
            frmLobby lobby = Application.OpenForms["frmLobby"] as frmLobby;
            if (lobby == null) // Nếu chưa mở Lobby, tạo mới
            {
                lobby = new frmLobby();
                lobby.Show();
            }
            else // Nếu đã mở Lobby, chỉ đưa nó lên phía trước
            {
                lobby.Show();
            }
            isMaster = true;
            SocketClientSingleton.Instance.inRoom = false;
            string s = "#_TCP_OR" + SocketClientSingleton.Instance.roomNumber.ToString();
            SocketClientSingleton.Instance.SendData(s);
            this.Close(); // Đóng Room
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            isMaster = false;
            SocketClientSingleton.Instance.inRoom = false;
            string s = "#_TCP_OR" + SocketClientSingleton.Instance.roomNumber.ToString();
            
            SocketClientSingleton.Instance.SendData(s);

            Application.Exit();
        }
        private void HandleServerCommand(ServerCommand command, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HandleServerCommand(command, message)));
                return;
            }
            //updateUi(message);
            switch (command)
            {
                case ServerCommand.BecomeMaster:
                    EnableMasterControls();
                    updateUi("Hiện tại bạn là quản trò!");
                    lblUserName1.Text = SocketClientSingleton.Instance.GetUserName();
                    break;
                case ServerCommand.StartRoom:
                    if (int.Parse(message[8].ToString()) == roomID)
                    {
                        updateUi("BẮT ĐẦU");
                        time = int.Parse(message.Substring(9).ToString());
                        panelWaitingRoom.Visible = false;
                        panelHost.Visible = false;
                        panelPlaying.Visible = true;
                        StartNextRound(message);
                        SocketClientSingleton.Instance.playerOfRoom[3, roomID] = 1;
                    }
                    break;
                case ServerCommand.ChatMessage:
                    updateUi(message.Substring(9));
                    break;
                case ServerCommand.UpdatePlayerinRoom:
                    UpdatePlayerCountUI(message);
                    try
                    {
                        string data = message.Substring(8);

                        // Lấy thông tin roomID, số người trong phòng, số lượng tối đa
                        int roomID = int.Parse(data[0].ToString());
                        int playerInRoom = int.Parse(data[1].ToString());
                        int maxPlayersInRoom = int.Parse(data[2].ToString());

                        // Lấy danh sách người chơi từ thông điệp
                        string[] usernames = new string[8];
                        string[] username = data.Substring(3).Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        // Cập nhật danh sách người chơi
                        for (int i = 0; i < 8; i++)
                        {
                            usernames[i] = i < username.Length ? username[i] : "TRỐNG";
                            if (i < playerNames.Count)
                            {
                                playerNames[i] = "TRỐNG";
                                playerNames[i] = usernames[i]; // Cập nhật tên người chơi vào danh sách
                            }
                        }
                        // Cập nhật UI
                        UpdatePlayerLabels();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error UpdatePlayerinRoom: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case ServerCommand.UpdateMaxPlayer:
                    UpdateMaxPlayerUI(message);
                    break;
                case ServerCommand.NewMaster:
                    string newMasterName = message.Substring(8);
                    OnMasterChanged(newMasterName);
                    UpdatePlayerLabels();
                    break;
                case ServerCommand.UpdateSettings:
                    int index1 = int.Parse(message[9].ToString());
                    int index2 = int.Parse(message[10].ToString());
                    switch (index1)
                    {
                        case 0:
                            txtTimer.Text = "10 GIÂY";
                            time = 10;
                            remainingTime = time;
                            break;
                        case 1:
                            txtTimer.Text = "15 GIÂY";
                            time = 15;
                            remainingTime = time;
                            break;
                        case 2:
                            txtTimer.Text = "30 GIÂY";
                            time = 30;
                            remainingTime = time;
                            break;
                        case 3:
                            txtTimer.Text = "60 GIÂY";
                            time = 60;
                            remainingTime = time;
                            break;
                    }
                    switch (index2)
                    {
                        case 0:
                            txtTurns.Text = "SỐ NGƯỜI CHƠI";
                            break;
                        case 1:
                            txtTurns.Text = "SỐ NGƯỜI CHƠI + 1";
                            break;
                        case 2:
                            txtTurns.Text = "4 LƯỢT";
                            break;
                        case 3:
                            txtTurns.Text = "5 LƯỢT";
                            break;
                        case 4:
                            txtTurns.Text = "6 LƯỢT";
                            break;
                        case 5:
                            txtTurns.Text = "7 LƯỢT";
                            break;
                        case 6:
                            txtTurns.Text = "8 LƯỢT";
                            break;
                        case 7:
                            txtTurns.Text = "9 LƯỢT";
                            break;
                        case 8:
                            txtTurns.Text = "10 LƯỢT";
                            break;
                    }
                    
                    break;
                case ServerCommand.TimeOut:
                    string RoomID = message.Substring(8, 1);

                    barTimer.Value = 0;
                    string msg = "#_TCP_SM" + "|" + roomID + "|" + currentRound + "|" + SocketClientSingleton.Instance.GetUserName() + "|" + txtSentence.Text;
                    SocketClientSingleton.Instance.SendData(msg);
                    break;
                case ServerCommand.NextRound:
                    StartNextRound(message);
                    break;
                case ServerCommand.EndStory:
                    this.BackgroundImage = Properties.Resources.BACKGROUNDEND;
                    panelPlaying.Visible = false;
                    panelEnd.Visible = true;
                    rtfStory.Text = message.Substring(10);
                    
                    break;
            }
        }
        
        // Phương thức cập nhật số lượng người chơi
        private void UpdatePlayerCountUI(string message)
        {
            // Lấy RoomID và số lượng người chơi từ thông điệp
            int roomId = int.Parse(message.Substring(8, 1));
            int playerCount = int.Parse(message.Substring(9, 1));
            SocketClientSingleton.Instance.playerOfRoom[1, roomId] = playerCount;
            int maxPlayer = int.Parse(message.Substring(10, 1));
            SocketClientSingleton.Instance.playerOfRoom[2, roomId] = maxPlayer;
            // Kiểm tra xem RoomID có khớp với phòng hiện tại không
            if (roomId == roomID)
            {
                lblNumberofPlayer.Text = $"NGƯỜI CHƠI {playerCount}/{maxPlayer}";
                lblNumberofPlayer.Invalidate(); // Yêu cầu vẽ lại label
            }

        }
        private void UpdateMaxPlayerUI(string message)
        {
            // Parse message to get new max player count (assuming message format "#_TCP_MP<RoomID><MaxPlayer>")
            if (message.StartsWith("#_TCP_MP"))
            {
                int roomId = int.Parse(message.Substring(8, 1));
                int maxPlayers = int.Parse(message.Substring(9));

                if (roomId == roomID)
                {
                    lblNumberofPlayer.Text = $"NGƯỜI CHƠI {SocketClientSingleton.Instance.playerOfRoom[1, roomId]}/{maxPlayers}";
                    lblNumberofPlayer.Invalidate();
                }
            }
        }
        // Phương thức cập nhật giao diện
        private void UpdatePlayerLabels()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdatePlayerLabels));
                return;
            }

            // Cập nhật UI các nhãn như bình thường
            lblUserName1.Text = playerNames[0] ?? "TRỐNG";
            lblUserName2.Text = playerNames[1] ?? "TRỐNG";
            lblUserName3.Text = playerNames[2] ?? "TRỐNG";
            lblUserName4.Text = playerNames[3] ?? "TRỐNG";
            lblUserName5.Text = playerNames[4] ?? "TRỐNG";
            lblUserName6.Text = playerNames[5] ?? "TRỐNG";
            lblUserName7.Text = playerNames[6] ?? "TRỐNG";
            lblUserName8.Text = playerNames[7] ?? "TRỐNG";
        }

        private void cbbNumofPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isMaster)
                return;
            // Lấy số người chơi tối đa từ ComboBox (định dạng "X người")
            string num = cbbNumofPlayer.SelectedItem.ToString();
            int maxPlayers = int.Parse(num.Split(' ')[0]); // Tách phần số trước dấu cách
            if (maxPlayers < SocketClientSingleton.Instance.playerOfRoom[1,roomID]) { return; }
            int roomIndex = Convert.ToInt32(lblRoomNumber.Tag);
            int currentPlayersInRoom = SocketClientSingleton.Instance.playerOfRoom[1, roomIndex];
            lblNumberofPlayer.Text = "NGƯỜI CHƠI " + currentPlayersInRoom.ToString() + "/" + maxPlayers.ToString();
            string msg = "#_TCP_MP" + roomIndex.ToString() + maxPlayers.ToString();
            SendDataThreadSafe(msg);
        }


        private void Room_Load(object sender, EventArgs e)
        {
            cbbNumofPlayer.SelectedIndex = 0;

        }
        private void EnableMasterControls()
        {
            isMaster = true;
            if (panelPlaying.Visible || panelEnd.Visible) { return; }
            panelWaitingRoom.Enabled = false;
            panelWaitingRoom.Visible = false;
            panelHost.Show();
            panelHost.Enabled = true;
        }

        private void DisableMasterControls()
        {
            panelHost.Hide();
            panelHost.Enabled = false;
            isMaster = false;
        }
        public void SetLabelText(string text, int tag)
        {
            lblRoomNumber.Text = text;
            lblRoomNumber.Tag = tag;
        }
        private void OnMasterChanged(string newMasterName)
        {
            if (newMasterName == SocketClientSingleton.Instance.GetUserName())
            {
                // Nếu người dùng là quản trò mới, kích hoạt các quyền đặc biệt
                EnableMasterControls();
                MessageBox.Show("Bạn hiện là quản trò của phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Nếu không, tắt quyền quản trò
                DisableMasterControls();
                MessageBox.Show($"{newMasterName} hiện là quản trò của phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnStartRoom_Click(object sender, EventArgs e)
        {
            if (SocketClientSingleton.Instance.playerOfRoom[1,roomID] < 2) { return; }
            panelPlaying.Visible = true;
            string message = "#_TCP_ST" + SocketClientSingleton.Instance.roomNumber.ToString();
            SocketClientSingleton.Instance.SendData(message);
            SocketClientSingleton.Instance.playerOfRoom[3, roomID] = 1;
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            string msg = "#_Chat_1" + SocketClientSingleton.Instance.roomNumber.ToString() + txtInRoomMessage.Text;
            SendDataThreadSafe(msg);
            //updateUi("_Client: " + txtSend.Text);
            txtInRoomMessage.Text = "";
        }
        private void update(string msg)
        {
            lstChat.Items.Add(msg);
            lstChat.TopIndex = lstChat.Items.Count - 1;
        }

        private void frmRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            SocketClientSingleton.Instance.inRoom = false;
            isMaster = false;
        }

        private void lblUserName1_TextChanged(object sender, EventArgs e)
        {
            txtHost.Text = lblUserName1.Text;
            txtHost_ReadOnly.Text = txtHost.Text;
        }

        private void cbbTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string message = "#_TCP_US" + roomID + cbbTimer.SelectedIndex + cbbTurns.SelectedIndex;
            SendDataThreadSafe(message);
        }

        private void cbbTurns_SelectedIndexChanged(object sender, EventArgs e)
        {
            string message = "#_TCP_US" + roomID + cbbTimer.SelectedIndex + cbbTurns.SelectedIndex;
            SendDataThreadSafe(message);
        }

        private void SendDataThreadSafe(string message)
        {
            // Ensure the SendData method is called on a separate thread to avoid blocking the UI thread
            Task.Run(() =>
            {
                try
                {
                    SocketClientSingleton.Instance.SendData(message);
                }
                catch (Exception ex)
                {
                    // Log or handle the exception as needed
                    Console.WriteLine("Lỗi gửi dữ liệu: " + ex.Message);
                }
            });
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!txtSentence.Enabled)
            {
                txtSentence.Enabled = true;
                btnSubmit.Text = "Xong";
            }
            else
            {
                txtSentence.Enabled = false;
                btnSubmit.Text = "Sửa";
            }

        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                // Cập nhật giá trị của barTimer theo thời gian còn lại
                int progress = (int)((remainingTime / (float)time) * 100);
                barTimer.Value = progress > 0 ? progress : 0;
            }
            else
            {
                countdownTimer.Stop();
                remainingTime = time;
            }
        }


        private void StartNextRound(string message)
        {
            int round = int.Parse(message.Substring(8,1));
            string data = message.Substring(9);

            countdownTimer.Stop();
            remainingTime = time;
            barTimer.Value = barTimer.Maximum;
            if (round >= 1)
            {
                rtfSentence.Visible = true;

                rtfSentence.Text = data;
            }
            else
            {
                rtfSentence.Visible = false;
                rtfSentence.Text = "";
            }
            txtSentence.Enabled = true;
            btnSubmit.Text = "XONG";
            txtSentence.Text = "";
            countdownTimer.Start();
            currentRound++;
        }
        private void SaveTextToFile()
        {
            // Tạo một đối tượng SaveFileDialog để người dùng chọn nơi lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Chọn định dạng file
            saveFileDialog.Title = "Save Text File";

            // Kiểm tra nếu người dùng đã chọn file để lưu
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lưu nội dung trong RichTextBox thành file
                string filePath = saveFileDialog.FileName; // Lấy đường dẫn file đã chọn
                File.WriteAllText(filePath, rtfStory.Text); // Lưu nội dung vào file
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveTextToFile();
        }
    }
}

