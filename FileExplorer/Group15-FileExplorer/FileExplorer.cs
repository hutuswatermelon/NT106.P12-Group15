using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Group15_FileExplorer
{
    public partial class Form1 : Form
    {
        ImageList imageList1;
        private string currentPath;
        private string sourcePath = "";
        private string destinationPath = "";
        private bool isCopying = false; // Để phân biệt khi thao tác với file
        private Stack<string> backwardHistory = new Stack<string>();
        private Stack<string> forwardHistory = new Stack<string>();
        private string oldPath; // Store the old path

        public Form1()
        {
            InitializeComponent();
            //PopulateTreeView();
            progressBar1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowDrives();
            if (treeView1.Nodes.Count > 0)
            {
                treeView1.SelectedNode = treeView1.Nodes[0]; // Select the first drive
                LoadDirectory(treeView1.Nodes[0].FullPath); // Load the first drive's directory
            }
            txtPath.Text = "Path";
        }
        public void ShowDrives()
        {
            treeView1.BeginUpdate();
            string[] drives = Directory.GetLogicalDrives();
            foreach (string adrive in drives)
            {
                TreeNode tn = new TreeNode(adrive);
                treeView1.Nodes.Add(tn);
                AddDirs(tn);
            }
            treeView1.EndUpdate();
        }
        private string GetAtts(FileInfo fi)
        {
            string atts = "";
            if ((fi.Attributes & FileAttributes.Archive) != 0)
                atts += "A";
            if ((fi.Attributes & FileAttributes.Hidden) != 0)
                atts += "H";
            if ((fi.Attributes & FileAttributes.ReadOnly) != 0)
                atts += "R";
            if ((fi.Attributes & FileAttributes.System) != 0)
                atts += "S";
            return atts;
        }
        public void ShowFileNames()
        {
            DirectoryInfo di = new DirectoryInfo(treeView1.SelectedNode.FullPath);
            FileInfo[] fiarray = { };
            DirectoryInfo[] diarray = { };
            ListViewItem item;

            imageList1 = new ImageList();
            listView1.Items.Clear(); // Clear ListView
            listView1.SmallImageList = imageList1;

            if (di.Exists)
            {
                // Get directories and files
                diarray = di.GetDirectories();
                fiarray = di.GetFiles();
            }

            listView1.BeginUpdate();

            // Display directories
            foreach (DirectoryInfo dir in diarray)
            {
                Icon folderIcon;
                item = new ListViewItem(dir.Name);
                listView1.Items.Add(item);

                // Set the folder icon if it's not already in the ImageList
                folderIcon = SystemIcons.WinLogo; // Default folder icon
                if (!imageList1.Images.ContainsKey("folder"))
                {
                    folderIcon = SystemIcons.WinLogo; // Get the system folder icon
                    imageList1.Images.Add("folder", folderIcon);
                }
                item.ImageKey = "folder";
                item.SubItems.Add("Folder"); // Mark as folder
                item.SubItems.Add(dir.LastWriteTime.ToString());
                item.SubItems.Add(""); // No size for folders
                item.SubItems.Add(""); // No attributes for folders
            }

            // Display files
            foreach (FileInfo fi in fiarray)
            {
                Icon fileIcon;
                item = new ListViewItem(fi.Name);
                listView1.Items.Add(item);

                // Set the file icon if it's not already in the ImageList
                fileIcon = SystemIcons.WinLogo; // Default file icon
                if (!imageList1.Images.ContainsKey(fi.Extension))
                {
                    fileIcon = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName);
                    imageList1.Images.Add(fi.Extension, fileIcon);
                }
                item.ImageKey = fi.Extension;
                item.SubItems.Add(fi.GetType().ToString());
                item.SubItems.Add(fi.LastWriteTime.ToString());
                item.SubItems.Add(fi.Length.ToString() + " bytes");
                item.SubItems.Add(GetAtts(fi)); // Get attributes (A, H, R, S)
            }

            listView1.EndUpdate();
        }

        public void AddDirs(TreeNode tn)
        {
            string path = tn.FullPath;
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] diarray = { };

            try
            {
                if (di.Exists) // trap, for example, empty disk drive
                    diarray = di.GetDirectories();
            }
            catch
            {
                return;
            }
            foreach (DirectoryInfo d in diarray)
            {
                TreeNode tndir = new TreeNode(d.Name);
                tn.Nodes.Add(tndir);
            }
        }
        //private void PopulateTreeView()
        //{
        //    TreeNode rootNode;

        //    // Specify the root directory you want to display in the TreeView
        //    DirectoryInfo info = new DirectoryInfo(@"..\.."); // Change as needed
        //    if (info.Exists)
        //    {
        //        rootNode = new TreeNode(info.Name)
        //        {
        //            Tag = info
        //        };
        //        GetDirectories(info.GetDirectories(), rootNode);
        //        treeView1.Nodes.Add(rootNode);
        //    }
        //}

        //private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        //{
        //    foreach (DirectoryInfo subDir in subDirs)
        //    {
        //        TreeNode aNode = new TreeNode(subDir.Name, 0, 0)
        //        {
        //            Tag = subDir
        //        };

        //        // Recursively get subdirectories
        //        GetDirectories(subDir.GetDirectories(), aNode);
        //        nodeToAddTo.Nodes.Add(aNode);
        //    }
        //}

        // Sao chép file khi nhấn nút Copy
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                sourcePath = Path.Combine(currentPath, selectedItem.Text);  // Lưu đường dẫn nguồn
                isCopying = true;  // Đặt cờ trạng thái là đang copy
            }
        }
        private void btnCut_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                sourcePath = Path.Combine(currentPath, selectedItem.Text);  // Lưu đường dẫn nguồn
                isCopying = false;  // Đặt cờ trạng thái là đang cut
            }
        }
        // Dán file khi nhấn nút Paste
        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sourcePath))  // Kiểm tra xem đường dẫn nguồn có hợp lệ không
            {
                destinationPath = Path.Combine(currentPath, Path.GetFileName(sourcePath));  // Tạo đường dẫn đích
                if (!backgroundWorker1.IsBusy)  // Chạy worker để paste tệp
                {
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    backgroundWorker1.RunWorkerAsync(new Tuple<string, string>(sourcePath, destinationPath));  // Truyền đường dẫn nguồn và đích
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedItems = listView1.SelectedItems.Cast<ListViewItem>().ToList();
            if (selectedItems.Any())
            {
                if (!backgroundWorkerDelete.IsBusy)
                {
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    backgroundWorkerDelete.RunWorkerAsync(selectedItems);
                }
            }
        }
        private void backgroundWorkerDelete_DoWork(object sender, DoWorkEventArgs e)
        {
            var itemsToDelete = (List<ListViewItem>)e.Argument;

            foreach (var item in itemsToDelete)
            {
                string filePath = Path.Combine(currentPath, item.Text);
                FileInfo fileInfo = new FileInfo(filePath);

                // Check if the file is hidden or a system file
                if ((fileInfo.Attributes & FileAttributes.Hidden) != 0 ||
                    (fileInfo.Attributes & FileAttributes.System) != 0)
                {
                    continue; // Skip deletion for hidden/system files
                }

                try
                {
                    File.Delete(filePath);
                    backgroundWorkerDelete.ReportProgress(0); // Update progress
                }
                catch (Exception ex)
                {
                    // Handle the exception (e.g., log it or notify the user)
                }
            }
        }

        private void backgroundWorkerDelete_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false; // Hide progress bar after completion
            MessageBox.Show("Deletion completed!");
        }
        // Xử lý sao chép file/thư mục trong background worker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var filePaths = (Tuple<string, string>)e.Argument;
            string sourceFile = filePaths.Item1;
            string destinationFile = filePaths.Item2;

            const int bufferSize = 1024 * 1024;  // 1MB buffer
            using (var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (var destinationStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                long totalBytes = sourceStream.Length;
                long totalBytesCopied = 0;
                int bytesRead;

                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    destinationStream.Write(buffer, 0, bytesRead);
                    totalBytesCopied += bytesRead;

                    int progressPercentage = (int)((totalBytesCopied * 100) / totalBytes);
                    backgroundWorker1.ReportProgress(progressPercentage);
                } 
            }

            // Nếu là thao tác cut, sau khi sao chép xong thì xóa tệp nguồn
            if (!isCopying)
            {
                File.Delete(sourceFile);
            }
        }

        // Cập nhật tiến độ khi sao chép
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        // Khi hoàn tất sao chép
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Operation canceled!");
            }
            else
            {
                MessageBox.Show(isCopying ? "File copied successfully!" : "File moved successfully!");
            }

            progressBar1.Visible = false;  // Ẩn thanh tiến trình sau khi hoàn tất
            ShowFileNames();  // Cập nhật lại ListView để hiển thị các tệp mới
        }
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                string oldFilePath = Path.Combine(currentPath, selectedItem.Text);

                // Show input dialog to get new name
                string newFileName = Microsoft.VisualBasic.Interaction.InputBox("Enter new name:", "Rename File", selectedItem.Text);
                if (!string.IsNullOrEmpty(newFileName) && newFileName != selectedItem.Text)
                {
                    string newFilePath = Path.Combine(currentPath, newFileName);

                    // Check if file is hidden or a system file
                    FileInfo fileInfo = new FileInfo(oldFilePath);
                    if ((fileInfo.Attributes & FileAttributes.Hidden) != 0 ||
                        (fileInfo.Attributes & FileAttributes.System) != 0)
                    {
                        MessageBox.Show("You cannot rename hidden or system files.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        File.Move(oldFilePath, newFilePath);
                        selectedItem.Text = newFileName; // Update the ListView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error renaming file: " + ex.Message);
                    }
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentPath))
            {
                // Lấy đường dẫn thư mục cha
                string parentDirectory = Directory.GetParent(currentPath)?.FullName;

                if (parentDirectory != null)
                {
                    // Lưu đường dẫn hiện tại vào lịch sử tiến
                    forwardHistory.Push(currentPath);

                    // Tải thư mục cha
                    LoadDirectory(parentDirectory);
                }
            }
        }
        private void btnForward_Click(object sender, EventArgs e)
        {
            if (forwardHistory.Count > 0)
            {
                backwardHistory.Push(currentPath);  // Add current path to backward history
                string nextPath = forwardHistory.Pop();  // Get the next path to visit
                LoadDirectory(nextPath);
                SelectTreeViewNodeByPath(nextPath);
            }
        }
        private void LoadDirectory(string path)
        {
            // Cập nhật lịch sử điều hướng
            if (!string.IsNullOrEmpty(currentPath))
            {
                backwardHistory.Push(currentPath); // Lưu đường dẫn hiện tại vào lịch sử lùi
            }

            try
            {
                currentPath = path;
                txtPath.Text = path; // Cập nhật textbox với đường dẫn hiện tại
                ShowFileNames(); // Hiển thị tệp trong ListView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading directory: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDirectory(currentPath);
        }
        private void txtPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if an item is selected under the mouse cursor
                ListViewItem clickedItem = listView1.GetItemAt(e.X, e.Y);
                if (clickedItem != null)
                {
                    // Set the selected item
                    clickedItem.Selected = true;

                    // Show the context menu at the mouse cursor position
                    mnuRightClick.Show(listView1, e.Location);
                }
            }
        }
        private void SelectTreeViewNodeByPath(string path)
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (SelectNodeByPath(node, path))
                    break;
            }
        }
        private bool SelectNodeByPath(TreeNode node, string path)
        {
            if (node.FullPath == path)
            {
                treeView1.SelectedNode = node;
                node.Expand();
                return true;
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                if (SelectNodeByPath(childNode, path))
                    return true;
            }
            return false;
        }

        // Recursive function to find a TreeView node based on the directory path
        private TreeNode FindNodeByPath(TreeNode treeNode, string path)
        {
            //    DirectoryInfo dirInfo = (DirectoryInfo)treeNode.Tag;

            //    // Compare the full directory path with the path provided
            //    if (dirInfo.FullName.Equals(path, StringComparison.InvariantCultureIgnoreCase))
            //    {
            //        return treeNode;  // Return the node if the path matches
            //    }

            //    // Recursively search in child nodes (subdirectories)
            //    foreach (TreeNode childNode in treeNode.Nodes)
            //    {
            //        TreeNode foundNode = FindNodeByPath(childNode, path);
            //        if (foundNode != null)
            //        {
            //            return foundNode;
            //        }
            //}

            return null;  // Return null if no match is found
        }

        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) // Check if ENTER key is pressed
            //{
            //    string enteredPath = txtPath.Text.Trim(); // Get the path entered in the textbox

            //    if (Directory.Exists(enteredPath)) // Check if the directory exists
            //    {
            //        // Update navigation history
            //        backwardHistory.Push(currentPath);
            //        forwardHistory.Clear(); // Clear forward history as it's a new navigation

            //        // Load the directory in the ListView
            //        LoadDirectory(enteredPath);

            //        // Update TreeView to highlight the folder corresponding to enteredPath
            //        SelectTreeViewNodeByPath(enteredPath);

            //        oldPath = enteredPath; // Update the oldPath to the newly valid path
            //    }
            //    else
            //    {
            //        // Restore the old path if the new path is invalid
            //        MessageBox.Show("The specified path does not exist.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtPath.Text = oldPath; // Immediately restore the old path
            //    }

            //    // Prevents the beep sound when pressing ENTER in a TextBox
            //    e.Handled = true;
            //    e.SuppressKeyPress = true;
            //}
        }

        private void txtPath_Enter(object sender, EventArgs e)
        {
            //if (txtPath.Text == "Path")
            //{
            //    txtPath.Text = ""; // Clear the placeholder
            //    txtPath.ForeColor = Color.Black; // Set the text color to normal
            //}
            //oldPath = txtPath.Text;
            //txtPath.SelectAll();
        }

        private void txtPath_Leave(object sender, EventArgs e)
        {
            //if (!Directory.Exists(txtPath.Text.Trim()))
            //{
            //    txtPath.Text = oldPath; // Restore old valid path if path entered was invalid or left blank
            //}
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog() { Description = "Select Path: " })
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //WebBrowser.Url = new Uri(folderBrowserDialog.SelectedPath);
                    txtPath.Text = folderBrowserDialog.SelectedPath;
                    LoadDirectory(folderBrowserDialog.SelectedPath);
                    ShowFileNames();
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadDirectory(e.Node.FullPath);
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeView1.BeginUpdate();
            foreach (TreeNode tn in e.Node.Nodes)
            {
                AddDirs(tn);
            }
            treeView1.EndUpdate();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string diskfile = treeView1.SelectedNode.FullPath;
            if (!diskfile.EndsWith("\\"))
            {
                diskfile += "\\";
            }
            diskfile += listView1.FocusedItem.Text;
            FileInfo fileInfo = new FileInfo(diskfile);

            // Check if the file is hidden or a system file
            if ((fileInfo.Attributes & FileAttributes.Hidden) != 0 ||
                (fileInfo.Attributes & FileAttributes.System) != 0)
            {
                MessageBox.Show("You cannot open hidden or system files.",
                                "Access Denied",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Exit the method without opening the file
            }

            Process.Start(new ProcessStartInfo { FileName = diskfile, UseShellExecute = true });
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Delete") // Adjust according to your context menu item text
            {
                var selectedItem = listView1.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
                if (selectedItem != null)
                {
                    string filePath = Path.Combine(currentPath, selectedItem.Text);
                    FileInfo fileInfo = new FileInfo(filePath);

                    // Check if the file is hidden or a system file
                    if ((fileInfo.Attributes & FileAttributes.Hidden) != 0 ||
                        (fileInfo.Attributes & FileAttributes.System) != 0)
                    {
                        MessageBox.Show("You cannot delete hidden or system files.",
                                        "Access Denied",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return; // Exit the method without deleting the file
                    }

                    // Proceed with deletion
                    if (MessageBox.Show($"Are you sure you want to delete {selectedItem.Text}?",
                                        "Confirm Deletion",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(filePath);
                        listView1.Items.Remove(selectedItem);
                    }
                }
            }
        }
    }
}

