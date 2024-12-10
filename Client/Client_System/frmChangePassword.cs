namespace Client_System
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            SocketClientSingleton.Instance.CommandReceived += HandleServerCommand;
            InitializeComponent();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            string password = txtPass.Text;
            string cfpassword = txtConfirmPass.Text;
            //Kiểm tra pw trống
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(cfpassword))
            {
                MessageBox.Show("Trường Password trống!", "THẤT BẠI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra độ dài mật khẩu
            if (password.Length < 8 || password.Length > 20)
            {
                MessageBox.Show("Mật khẩu phải có độ dài 8 - 20 ký tự", "THẤT BẠI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra độ mạnh của mật khẩu (ít nhất một chữ cái, một số, và một ký tự đặc biệt)
            if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit) || !password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 1 chữ cái, 1 chữ số và 1 kí tự đặc biệt", "THẤT BẠI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra nếu mật khẩu và mật khẩu xác nhận không khớp
            if (password != cfpassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không đúng", "THẤT BẠI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Clear();
                txtConfirmPass.Clear();
                txtPass.Focus();
                return;
            }
            string msg = "#_TCP_DMK" + txtConfirmPass.Text;
            SocketClientSingleton.Instance.SendData(msg);
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
                case ServerCommand.ChangePasswordSuccess:
                    MessageBox.Show("Đổi mật khẩu thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

    }
}
