using System.ComponentModel;

namespace Group15_FileExplorer
{
    partial class fExplorer
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
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnBack = new Button();
            btnForward = new Button();
            btnRefresh = new Button();
            txtPath = new TextBox();
            btnOpen = new Button();
            labelPath = new Label();
            splitContainer1 = new SplitContainer();
            treeView = new TreeView();
            progressBar1 = new ProgressBar();
            listViewApp = new ListView();
            columnHeader5 = new ColumnHeader();
            ColumnHeader1 = new ColumnHeader();
            ColumnHeader2 = new ColumnHeader();
            ColumnHeader3 = new ColumnHeader();
            ColumnHeader4 = new ColumnHeader();
            backgroundWorkerDelete = new BackgroundWorker();
            folderBrowserDialog = new FolderBrowserDialog();
            mnuRightClick = new ContextMenuStrip(components);
            copyToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            renameToolStripMenuItem = new ToolStripMenuItem();
            newFolderToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            mnuRightClick.SuspendLayout();
            SuspendLayout();
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
            tableLayoutPanel2.Size = new Size(892, 474);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel2.SetColumnSpan(tableLayoutPanel1, 2);
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.Controls.Add(btnBack, 0, 0);
            tableLayoutPanel1.Controls.Add(btnForward, 1, 0);
            tableLayoutPanel1.Controls.Add(btnRefresh, 2, 0);
            tableLayoutPanel1.Controls.Add(txtPath, 4, 0);
            tableLayoutPanel1.Controls.Add(btnOpen, 5, 0);
            tableLayoutPanel1.Controls.Add(labelPath, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(886, 34);
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
            txtPath.BackColor = SystemColors.ControlLightLight;
            txtPath.Dock = DockStyle.Fill;
            txtPath.Location = new Point(183, 3);
            txtPath.Name = "txtPath";
            txtPath.ReadOnly = true;
            txtPath.Size = new Size(620, 27);
            txtPath.TabIndex = 3;
            // 
            // btnOpen
            // 
            btnOpen.Dock = DockStyle.Fill;
            btnOpen.Location = new Point(809, 3);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(74, 28);
            btnOpen.TabIndex = 5;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // labelPath
            // 
            labelPath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelPath.AutoSize = true;
            labelPath.Location = new Point(123, 7);
            labelPath.Name = "labelPath";
            labelPath.Size = new Size(54, 20);
            labelPath.TabIndex = 6;
            labelPath.Text = "Path:";
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
            splitContainer1.Panel1.Controls.Add(treeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(progressBar1);
            splitContainer1.Panel2.Controls.Add(listViewApp);
            splitContainer1.Size = new Size(886, 428);
            splitContainer1.SplitterDistance = 248;
            splitContainer1.TabIndex = 1;
            // 
            // treeView
            // 
            treeView.Dock = DockStyle.Fill;
            treeView.Location = new Point(0, 0);
            treeView.Name = "treeView";
            treeView.Size = new Size(248, 428);
            treeView.TabIndex = 0;
            treeView.BeforeExpand += treeView1_BeforeExpand;
            treeView.AfterSelect += treeView1_AfterSelect;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 399);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(634, 29);
            progressBar1.TabIndex = 1;
            progressBar1.Visible = false;
            // 
            // listViewApp
            // 
            listViewApp.Columns.AddRange(new ColumnHeader[] { columnHeader5, ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4 });
            listViewApp.Dock = DockStyle.Fill;
            listViewApp.Location = new Point(0, 0);
            listViewApp.Name = "listViewApp";
            listViewApp.Size = new Size(634, 428);
            listViewApp.TabIndex = 0;
            listViewApp.UseCompatibleStateImageBehavior = false;
            listViewApp.View = View.Details;
            listViewApp.DoubleClick += listviewApp_DoubleClick;
            listViewApp.MouseClick += listviewApp_MouseClick;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Name";
            columnHeader5.Width = 180;
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
            ColumnHeader2.Width = 150;
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
            backgroundWorkerDelete.RunWorkerCompleted += backgroundWorkerDelete_RunWorkerCompleted;
            // 
            // mnuRightClick
            // 
            mnuRightClick.ImageScalingSize = new Size(20, 20);
            mnuRightClick.Items.AddRange(new ToolStripItem[] { copyToolStripMenuItem, cutToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator2, deleteToolStripMenuItem, toolStripSeparator3, renameToolStripMenuItem, newFolderToolStripMenuItem });
            mnuRightClick.Name = "mnuRightClick";
            mnuRightClick.Size = new Size(211, 188);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(210, 24);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += btnCopy_Click;
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(210, 24);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += btnCut_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(210, 24);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += btnPaste_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(207, 6);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(210, 24);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += btnDelete_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(207, 6);
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(210, 24);
            renameToolStripMenuItem.Text = "Rename";
            renameToolStripMenuItem.Click += btnRename_Click;
            // 
            // newFolderToolStripMenuItem
            // 
            newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            newFolderToolStripMenuItem.Size = new Size(210, 24);
            newFolderToolStripMenuItem.Text = "New Folder";
            newFolderToolStripMenuItem.Click += NewFolderItem_Click;
            // 
            // fExplorer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 474);
            Controls.Add(tableLayoutPanel2);
            MinimumSize = new Size(875, 521);
            Name = "fExplorer";
            Text = "File Explorer";
            Load += fExplorer_Load;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            mnuRightClick.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ToolStripMenuItem openToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnBack;
        private Button btnForward;
        private Button btnRefresh;
        private TextBox txtPath;
        private SplitContainer splitContainer1;
        private TreeView treeView;
        private ProgressBar progressBar1;

        private Button btnOpen;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDelete;
        private Label labelPath;
        private FolderBrowserDialog folderBrowserDialog;
        private ListView listViewApp;
        private ColumnHeader columnHeader5;
        private ColumnHeader ColumnHeader1;
        private ColumnHeader ColumnHeader2;
        private ColumnHeader ColumnHeader3;
        private ColumnHeader ColumnHeader4;
        private ContextMenuStrip mnuRightClick;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStripMenuItem newFolderToolStripMenuItem;
    }
}
