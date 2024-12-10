namespace Client_System
{
    public partial class frmSignin : Form
    {
        public frmSignin()
        {
            InitializeComponent();
            SocketClientSingleton.Instance.CommandReceived += HandleServerCommand;
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
        }
        #region Window Dragging
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void Form_MouseDown(object sender, MouseEventArgs e)
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
        private void Form_MouseMove(object sender, MouseEventArgs e)
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
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            // Ngừng kéo form khi nút chuột được nhả
            dragging = false;
        }
        #endregion
        private void btnSignin_Click(object sender, EventArgs e)
        {
            string message = "#_TCP_DN" + txtUsername.Text + " " + txtPassword.Text;
            if (SocketClientSingleton.Instance.Client.Connected)
            {
                try
                {
                    // Use the new SendMessage method without managing `buffSend` directly
                    SocketClientSingleton.Instance.SendData(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending data: " + ex.Message, "Send Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Socket is not connected. Please check the connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleServerCommand(ServerCommand command, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HandleServerCommand(command, message)));
                return;
            }
            // Xử lý các loại lệnh cụ thể
            switch (command)
            {
                case ServerCommand.SignInFailed:
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                    break;
                case ServerCommand.SIF_AccountUsing:
                    MessageBox.Show("Tài khoản đang được sử dụng");
                    break;
                case ServerCommand.SignInSuccess:
                    this.Close();
                    //MessageBox.Show("Đăng nhập thành công");
                    new frmLobby().Show();
                    SocketClientSingleton.Instance.SetUserName(txtUsername.Text);
                    break;
                default:
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void lbRegister_Click(object sender, EventArgs e)
        {
            new frmSignup().Show();
            this.Hide();
        }

        private void ShowPassIcon_Click(object sender, EventArgs e)
        {
            //ShowPassIcon.SizeMode = PictureBoxSizeMode.StretchImage;

            // Check if the password is currently hidden
            if (txtPassword.PasswordChar == '•')
            {
                // Show the password
                txtPassword.PasswordChar = '\0';  // This means no masking
                ShowPassIcon.Image = Properties.Resources.ShowPasIcon;  // Change the icon to a closed eye
            }
            else
            {
                // Hide the password
                txtPassword.PasswordChar = '•';  // Set the password character back
                ShowPassIcon.Image = Properties.Resources.UnShowPasIcon;  // Change the icon to an open eye
            }

        }
        private void frmSignin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
