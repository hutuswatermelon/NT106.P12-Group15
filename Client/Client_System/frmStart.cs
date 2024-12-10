using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Client_System
{

    public partial class frmStart : Form
    {
        private delegate void updateUI(string message);
        private updateUI updateUi;
        string ipAddress = "";
        string port = "8000";
        private const string apiKey = "YOUR_API_KEY";
        private const string secretKey = "YOUR_SECRET_KEY"; // Khóa bí mật chung cho cả client và server   

        public frmStart()
        {
            InitializeComponent();
            updateUi = new updateUI(update);
            CheckForIllegalCrossThreadCalls = false;
            btnSignin.Enabled = false;
            btnSignup.Enabled = false;
            SocketClientSingleton.Instance.ConnectionSuccessful += EnableButtons;
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
        private void update(string msg)
        {

        }
        private void btnSignup_Click(object sender, EventArgs e)
        {
            new frmSignup().Show();
            this.Hide();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            new frmSignin().Show();
            this.Hide();
        }
        private void startClient()
        {
            ipAddress = txtServerIP.Text;

            // Kiểm tra tính hợp lệ của địa chỉ IP
            if (!IPAddress.TryParse(ipAddress, out _))
            {
                MessageBox.Show("Địa chỉ IP không hợp lệ!");
                return;
            }

            try
            {
                // Tạo kết nối nếu địa chỉ IP hợp lệ
                updateUi("Đang kết nối...");
                SocketClientSingleton.Instance.BeginConnect(ipAddress, int.Parse(port), new AsyncCallback(SocketClientSingleton.Instance.beginConnect));
                // Tạo thông điệp yêu cầu và mã HMAC
                string requestData = "YOUR_API_KEY";
                string hmac = CreateHMAC(requestData, secretKey);

                // Gửi yêu cầu cùng mã HMAC và API Key đến server
                SendDataToServer(apiKey, requestData, hmac);
            }
            catch (SocketException)
            {
                MessageBox.Show("Kết nối thất bại. Địa chỉ IP không tồn tại hoặc Server offline.");
                updateUi("Kết nối thất bại.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message);
            }
        }
        public void EnableButtons()
        {
            btnSignin.Enabled = true;
            btnSignup.Enabled = true;
        }

        private void frmStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            //this.Close();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            startClient();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool shown = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!SocketClientSingleton.Instance.isConnected() && !shown)
            {
                MessageBox.Show("Mất kết nối đến server");
                shown = true;
                timer1.Stop();
            }
        }

        private string CreateHMAC(string data, string secretKey)
        {
            // Tạo HMAC SHA256 từ dữ liệu và khóa bí mật
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                byte[] hashValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(hashValue); // Trả về mã HMAC dưới dạng chuỗi Base64
            }
        }
        private Task SendDataToServer(string apiKey, string data, string hmac)
        {
            try
            {
                if (SocketClientSingleton.Instance.isConnected())
                {
                    string messageToSend = $"{apiKey}|{data}|{hmac}";
                    SocketClientSingleton.Instance.BeginSend(messageToSend, new AsyncCallback(SocketClientSingleton.Instance.EndSend));

                }
                else
                {
                    MessageBox.Show("Không có kết nối đến server.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi dữ liệu: " + ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}

