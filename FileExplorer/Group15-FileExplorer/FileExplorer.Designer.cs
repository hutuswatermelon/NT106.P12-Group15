using System.ComponentModel;

namespace Group15_FileExplorer
{
    partial class Form1
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
            components = new Container();
            mnuRightClick = new ContextMenuStrip(components);
            copyToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem1 = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem1 = new ToolStripMenuItem();
            backgroundWorker1 = new BackgroundWorker();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnBack = new Button();
            btnForward = new Button();
            btnRefresh = new Button();
            txtPath = new TextBox();
            txtSearch = new TextBox();
            btnOpen = new Button();
            splitContainer1 = new SplitContainer();
            treeView1 = new TreeView();
            progressBar1 = new ProgressBar();
            listView1 = new ListView();
            ColumnHeader0 = new ColumnHeader();
            ColumnHeader1 = new ColumnHeader();
            ColumnHeader2 = new ColumnHeader();
            ColumnHeader3 = new ColumnHeader();
            ColumnHeader4 = new ColumnHeader();
            backgroundWorkerDelete = new BackgroundWorker();
            mnuRightClick.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // mnuRightClick
            // 
            mnuRightClick.ImageScalingSize = new Size(20, 20);
            mnuRightClick.Items.AddRange(new ToolStripItem[] { copyToolStripMenuItem, copyToolStripMenuItem1, cutToolStripMenuItem, toolStripMenuItem2, toolStripSeparator1, deleteToolStripMenuItem, deleteToolStripMenuItem1 });
            mnuRightClick.Name = "contextMenuStrip1";
            mnuRightClick.Size = new Size(124, 154);
            mnuRightClick.ItemClicked += contextMenuStrip1_ItemClicked;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.ShowShortcutKeys = false;
            copyToolStripMenuItem.Size = new Size(123, 24);
            copyToolStripMenuItem.Text = "Open";
            // 
            // copyToolStripMenuItem1
            // 
            copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            copyToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem1.ShowShortcutKeys = false;
            copyToolStripMenuItem1.Size = new Size(123, 24);
            copyToolStripMenuItem1.Text = "Copy";
            copyToolStripMenuItem1.Click += btnCopy_Click;
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.ShowShortcutKeys = false;
            cutToolStripMenuItem.Size = new Size(123, 24);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += btnCut_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.ShortcutKeys = Keys.Control | Keys.V;
            toolStripMenuItem2.ShowShortcutKeys = false;
            toolStripMenuItem2.Size = new Size(123, 24);
            toolStripMenuItem2.Text = "Paste";
            toolStripMenuItem2.Click += btnPaste_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(120, 6);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteToolStripMenuItem.ShowShortcutKeys = false;
            deleteToolStripMenuItem.Size = new Size(123, 24);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += btnDelete_Click;
            // 
            // deleteToolStripMenuItem1
            // 
            deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            deleteToolStripMenuItem1.ShortcutKeys = Keys.F2;
            deleteToolStripMenuItem1.ShowShortcutKeys = false;
            deleteToolStripMenuItem1.Size = new Size(123, 24);
            deleteToolStripMenuItem1.Text = "Rename";
            deleteToolStripMenuItem1.Click += btnRename_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.5F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel2.Controls.Add(splitContainer1, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1176, 474);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel2.SetColumnSpan(tableLayoutPanel1, 2);
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 91.8552F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.144796F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165F));
            tableLayoutPanel1.Controls.Add(btnBack, 0, 0);
            tableLayoutPanel1.Controls.Add(btnForward, 1, 0);
            tableLayoutPanel1.Controls.Add(btnRefresh, 2, 0);
            tableLayoutPanel1.Controls.Add(txtPath, 3, 0);
            tableLayoutPanel1.Controls.Add(txtSearch, 5, 0);
            tableLayoutPanel1.Controls.Add(btnOpen, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1170, 34);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Image = Properties.Resources.Back;
            btnBack.Location = new Point(3, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(34, 28);
            btnBack.TabIndex = 0;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnForward
            // 
            btnForward.Image = Properties.Resources.Forward;
            btnForward.Location = new Point(43, 3);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(34, 28);
            btnForward.TabIndex = 1;
            btnForward.UseVisualStyleBackColor = true;
            btnForward.Click += btnForward_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Image = Properties.Resources.Refresh;
            btnRefresh.Location = new Point(83, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(34, 28);
            btnRefresh.TabIndex = 2;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtPath
            // 
            txtPath.Dock = DockStyle.Fill;
            txtPath.Location = new Point(123, 3);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(806, 27);
            txtPath.TabIndex = 3;
            txtPath.Text = "Path";
            txtPath.Enter += txtPath_Enter;
            txtPath.KeyDown += txtPath_KeyDown;
            txtPath.Leave += txtPath_Leave;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Location = new Point(1007, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(160, 27);
            txtSearch.TabIndex = 4;
            txtSearch.Text = "Search";
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(935, 3);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(66, 28);
            btnOpen.TabIndex = 5;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // splitContainer1
            // 
            tableLayoutPanel2.SetColumnSpan(splitContainer1, 2);
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 43);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(progressBar1);
            splitContainer1.Panel2.Controls.Add(listView1);
            splitContainer1.Size = new Size(1170, 428);
            splitContainer1.SplitterDistance = 328;
            splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(328, 428);
            treeView1.TabIndex = 0;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 399);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(838, 29);
            progressBar1.TabIndex = 1;
            progressBar1.Visible = false;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { ColumnHeader0, ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4 });
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(838, 428);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DoubleClick += listView1_DoubleClick;
            listView1.MouseClick += listView1_MouseClick;
            // 
            // ColumnHeader0
            // 
            ColumnHeader0.Text = "Name";
            // 
            // ColumnHeader1
            // 
            ColumnHeader1.Text = "Type";
            ColumnHeader1.TextAlign = HorizontalAlignment.Center;
            ColumnHeader1.Width = 150;
            // 
            // ColumnHeader2
            // 
            ColumnHeader2.Text = "Date Modified";
            ColumnHeader2.TextAlign = HorizontalAlignment.Center;
            // 
            // ColumnHeader3
            // 
            ColumnHeader3.Text = "Size";
            ColumnHeader3.TextAlign = HorizontalAlignment.Center;
            // 
            // ColumnHeader4
            // 
            ColumnHeader4.Text = "Attribute";
            ColumnHeader4.TextAlign = HorizontalAlignment.Center;
            ColumnHeader4.Width = 100;
            // 
            // backgroundWorkerDelete
            // 
            backgroundWorkerDelete.DoWork += backgroundWorkerDelete_DoWork;
            backgroundWorkerDelete.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorkerDelete.RunWorkerCompleted += backgroundWorkerDelete_RunWorkerCompleted;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 474);
            Controls.Add(tableLayoutPanel2);
            Name = "Form1";
            Text = "File Explorer";
            Load += Form1_Load;
            mnuRightClick.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip mnuRightClick;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem copyToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnBack;
        private Button btnForward;
        private Button btnRefresh;
        private TextBox txtPath;
        private TextBox txtSearch;
        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private ListView listView1;
        private ProgressBar progressBar1;
        private ColumnHeader ColumnHeader0;
        private ColumnHeader ColumnHeader1;
        private ColumnHeader ColumnHeader2;
        private ColumnHeader ColumnHeader3;
        private ToolStripMenuItem copyToolStripMenuItem1;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private Button btnOpen;
        private ColumnHeader ColumnHeader4;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDelete;
    }
}
