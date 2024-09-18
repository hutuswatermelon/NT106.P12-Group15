namespace PictureViewer23521696
{
    partial class PictureViewer
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
            tableLayoutPanel1 = new TableLayoutPanel();
            checkBox1 = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnShowaPic = new Button();
            btnClearPicture = new Button();
            btnSetBGColor = new Button();
            btnClose = new Button();
            openFileDialog1 = new OpenFileDialog();
            colorDialog1 = new ColorDialog();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.Controls.Add(checkBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(3, 408);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(114, 39);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Stretch";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnShowaPic);
            flowLayoutPanel1.Controls.Add(btnClearPicture);
            flowLayoutPanel1.Controls.Add(btnSetBGColor);
            flowLayoutPanel1.Controls.Add(btnClose);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(123, 408);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.RightToLeft = RightToLeft.Yes;
            flowLayoutPanel1.Size = new Size(674, 39);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // btnShowaPic
            // 
            btnShowaPic.AutoSize = true;
            btnShowaPic.Location = new Point(543, 3);
            btnShowaPic.Name = "btnShowaPic";
            btnShowaPic.Size = new Size(128, 30);
            btnShowaPic.TabIndex = 0;
            btnShowaPic.Text = "Show a Picture";
            btnShowaPic.UseVisualStyleBackColor = true;
            btnShowaPic.Click += btnShowaPic_Click;
            // 
            // btnClearPicture
            // 
            btnClearPicture.AutoSize = true;
            btnClearPicture.Location = new Point(402, 3);
            btnClearPicture.Name = "btnClearPicture";
            btnClearPicture.Size = new Size(135, 30);
            btnClearPicture.TabIndex = 1;
            btnClearPicture.Text = "Clear the picture";
            btnClearPicture.UseVisualStyleBackColor = true;
            btnClearPicture.Click += btnClearPicture_Click;
            // 
            // btnSetBGColor
            // 
            btnSetBGColor.AutoSize = true;
            btnSetBGColor.Location = new Point(210, 3);
            btnSetBGColor.Name = "btnSetBGColor";
            btnSetBGColor.Size = new Size(186, 30);
            btnSetBGColor.TabIndex = 2;
            btnSetBGColor.Text = "Set the background color";
            btnSetBGColor.UseVisualStyleBackColor = true;
            btnSetBGColor.Click += btnSetBGColor_Click;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.Location = new Point(110, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 30);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jepg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";
            // 
            // pictureBox1
            // 
            tableLayoutPanel1.SetColumnSpan(pictureBox1, 2);
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(794, 399);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Picture Viewer";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox checkBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnShowaPic;
        private Button btnClearPicture;
        private Button btnSetBGColor;
        private Button btnClose;
        private OpenFileDialog openFileDialog1;
        private ColorDialog colorDialog1;
        private PictureBox pictureBox1;
    }
}
