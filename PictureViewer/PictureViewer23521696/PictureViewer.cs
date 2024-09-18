namespace PictureViewer23521696
{
    public partial class PictureViewer : Form
    {
        public PictureViewer()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShowaPic_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);

                // Lấy kích thước của ảnh vừa được tải
                Image loadedImage = Image.FromFile(openFileDialog1.FileName);
                int imgWidth = loadedImage.Width;
                int imgHeight = loadedImage.Height;
                if (imgWidth > 3000 || imgHeight > 2000)
                {
                    double scale = 1000.0 / Math.Max(imgWidth, imgHeight);
                    int scaledWidth = (int)(imgWidth * scale);   // Chiều rộng đã scale
                    int scaledHeight = (int)(imgHeight * scale); // Chiều cao đã scale

                    // Thay đổi kích thước cửa sổ theo kích thước ảnh đã điều chỉnh
                    //this.ClientSize = new Size(scaledWidth, scaledHeight);

                    // Đặt lại PictureBox kích thước bằng kích thước ảnh đã điều chỉnh
                    //pictureBox1.Size = new Size(scaledWidth, scaledHeight);

                    // Load ảnh đã điều chỉnh vào PictureBox
                    pictureBox1.Image = new Bitmap(loadedImage, new Size(scaledWidth, scaledHeight));
                }


                loadedImage.Dispose(); // Giải phóng tài nguyên
            }
        }

        private void btnClearPicture_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void btnSetBGColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}
