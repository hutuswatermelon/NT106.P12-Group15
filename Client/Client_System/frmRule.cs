using Client_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_System
{
    public partial class frmRule : Form
    {
        public frmRule()
        {
            InitializeComponent();
            lbRules_MemDetail1.Visible = false;
            lbRules_MemDetail2.Visible = false;
            lbRules_MemDetail3.Visible = false;
            lbRules_Detail.Visible = false;
            lbRules_HostDetail1.Visible = false;
            lbRules_HostDetail2.Visible = false;
            lbRules_HostDetail3.Visible = false;
            this.MouseDown += YourForm_MouseDown;
            this.MouseMove += YourForm_MouseMove;
            this.MouseUp += YourForm_MouseUp;

        }
        #region EventHandle Drag Window
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

        private void ptbRules1_Click(object sender, EventArgs e)
        {
            lbRules_MemDetail1.Visible = true;
            lbRules_HostDetail1.Visible = true;
            lbRules_Detail.Visible = false;
            lbRules_MemDetail2.Visible = false;
            lbRules_HostDetail2.Visible = false;
            lbRules_MemDetail3.Visible = false;
            lbRules_HostDetail3.Visible = false;
        }
        private void ptbRules2_Click(object sender, EventArgs e)
        {
            lbRules_MemDetail1.Visible = false;
            lbRules_HostDetail1.Visible = false;
            lbRules_MemDetail2.Visible = true;
            lbRules_HostDetail2.Visible = true;
            lbRules_MemDetail3.Visible = false;
            lbRules_HostDetail3.Visible = false;
            lbRules_Detail.Visible = false;
        }
        private void ptbRules3_Click(object sender, EventArgs e)
        {
            lbRules_MemDetail2.Visible = false;
            lbRules_HostDetail2.Visible = false;
            lbRules_MemDetail1.Visible = false;
            lbRules_HostDetail1.Visible = false;
            lbRules_MemDetail3.Visible = true;
            lbRules_HostDetail3.Visible = true;
            lbRules_Detail.Visible = false;
        }
        private void ptbRules4_Click(object sender, EventArgs e)
        {
            lbRules_MemDetail2.Visible = false;
            lbRules_HostDetail2.Visible = false;
            lbRules_MemDetail1.Visible = false;
            lbRules_HostDetail1.Visible = false;
            lbRules_MemDetail3.Visible = false;
            lbRules_HostDetail3.Visible = false;
            lbRules_Detail.Visible = true;
        }

        private void ptbBack_Click(object sender, EventArgs e)
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
            this.Close(); // Đóng Room
        }
    }
}