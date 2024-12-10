using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml.Linq;
using System.Net.Sockets;

namespace Client_System
{
    public partial class frmSignup : Form
    {

        public frmSignup()
        {
            InitializeComponent();
            // Đăng ký sự kiện để lắng nghe các thông điệp từ server
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

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtComPassword.Text;

            // Kiểm tra nếu các trường trống
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Không được để trống Tên đăng nhập/Mật khẩu", "ĐĂNG KÍ THẤT BẠI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra độ dài tên đăng nhập
            if (username.Length < 4 || username.Length > 20)
            {
                MessageBox.Show("Tên đăng nhập phải có độ dài 4 - 20 ký tự", "ĐĂNG KÍ THẤT BẠI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra ký tự không hợp lệ trong tên đăng nhập
            if (!username.All(char.IsLetterOrDigit))
            {
                MessageBox.Show("Tên đăng nhập chỉ chứa chữ cái hoặc chữ số", "ĐĂNG KÍ THẤT BẠI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra độ dài mật khẩu
            if (password.Length < 8 || password.Length > 20)
            {
                MessageBox.Show("Mật khẩu phải có độ dài 8 - 20 ký tự", "ĐĂNG KÍ THẤT BẠI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra độ mạnh của mật khẩu (ít nhất một chữ cái, một số, và một ký tự đặc biệt)
            if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit) || !password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 1 chữ cái, 1 chữ số và 1 kí tự đặc biệt", "ĐĂNG KÍ THẤT BẠI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra nếu mật khẩu và mật khẩu xác nhận không khớp
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không đúng", "ĐĂNG KÍ THẤT BẠI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtComPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // Định dạng và gửi thông điệp đăng ký tới server
            string message = "#_TCP_DK" + username + " " + password;


            if (SocketClientSingleton.Instance.Client.Connected)
            {
                try {
                    // Use the new SendMessage method without managing `buffSend` directly
                    SocketClientSingleton.Instance.SendData(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Send Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa kết nối...", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleServerCommand(ServerCommand command, string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => HandleServerCommand(command, message)));
                return;
            }

            switch (command)
            {
                case ServerCommand.SignUpFailed:
                    MessageBox.Show("Tên đăng nhập đã tồn tại", "ĐĂNG KÍ THẤT BẠI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ServerCommand.SignUpSuccess:
                    // Close the SignUp form and open the SignIn form
                    DialogResult result = MessageBox.Show("Đăng kí thành công, bạn có muốn chuyển sang trang đăng nhập?", "ĐĂNG KÍ THÀNH CÔNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        this.Hide();
                        new frmSignin().Show();

                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }
                    break;
                default:
                    // Handle other cases if needed
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtUsername.Focus();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            new frmSignin().Show();
            this.Hide();
        }

        private void ShowPassIcon_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '•')
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
                ShowPassIcon.Image = Properties.Resources.ShowPasIcon;
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
                ShowPassIcon.Image = Properties.Resources.UnShowPasIcon;
            }
        }

        private void frmSignup_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
