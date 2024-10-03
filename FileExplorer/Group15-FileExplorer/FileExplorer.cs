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
using Microsoft.VisualBasic.FileIO;

namespace Group15_FileExplorer
{
    public partial class fExplorer : Form
    {
        ImageList imageList;
        private string currentPath;
        private string sourcePath = "";
        private string destinationPath = "";
        private bool isCopying = false; //  A flag indicating if a copy operation is in progress
        private Stack<string> backwardHistory = new Stack<string>();
        private Stack<string> forwardHistory = new Stack<string>();
        private string clipboardFilePath; // Stores the path of the file currently in the clipboard
        private string cutFilePath;
        private bool isCutOperation = false;
        public fExplorer()
        {
            InitializeComponent();
            progressBar1.Visible = false;
        }

        private void fExplorer_Load(object sender, EventArgs e)
        {
            ShowDrives();
            if (treeView.Nodes.Count > 0)
            {
                treeView.SelectedNode = treeView.Nodes[0]; // Select the first drive
                LoadDirectory(treeView.Nodes[0].FullPath); // Load the first drive's directory
            }
        }
        public void ShowDrives()
        {
            treeView.BeginUpdate();
            string[] drives = Directory.GetLogicalDrives();
            foreach (string adrive in drives)
            {
                TreeNode tn = new TreeNode(adrive);
                treeView.Nodes.Add(tn);
                AddDirs(tn);
            }
            treeView.EndUpdate();
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
        private void LoadDirectory(string path)
        {
            // Update navigation history
            if (!string.IsNullOrEmpty(currentPath))
            {
                backwardHistory.Push(currentPath); // Save current path to back.history
            }

            try
            {
                currentPath = path;
                txtPath.Text = path;
                ShowFileNames();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading directory: " + ex.Message);
            }
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
        public void ShowFileNames()
        {
            DirectoryInfo di = new DirectoryInfo(txtPath.Text);
            FileInfo[] fiarray = { };
            DirectoryInfo[] diarray = { };
            ListViewItem item;

            imageList = new ImageList();
            listViewApp.Items.Clear(); // Clear ListView
            listViewApp.SmallImageList = imageList;

            if (di.Exists)
            {
                // Get directories and files
                diarray = di.GetDirectories();
                fiarray = di.GetFiles();
            }

            listViewApp.BeginUpdate();

            // Display directories
            foreach (DirectoryInfo dir in diarray)
            {
                Icon folderIcon;
                item = new ListViewItem(dir.Name);
                listViewApp.Items.Add(item);

                // Set the folder icon if it's not already in the ImageList
                folderIcon = SystemIcons.WinLogo; // Default folder icon
                if (!imageList.Images.ContainsKey("folder"))
                {
                    imageList.Images.Add("folder", folderIcon);
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
                listViewApp.Items.Add(item);

                // Set the file icon if it's not already in the ImageList
                fileIcon = SystemIcons.WinLogo; // Default file icon
                if (!imageList.Images.ContainsKey(fi.Extension))
                {
                    fileIcon = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName);
                    imageList.Images.Add(fi.Extension, fileIcon);
                }
                item.ImageKey = fi.Extension;
                item.SubItems.Add(fi.Extension);
                item.SubItems.Add(fi.LastWriteTime.ToString());
                item.SubItems.Add(fi.Length.ToString() + " bytes");
                item.SubItems.Add(GetAtts(fi)); // Get attributes (A, H, R, S)
            }

            listViewApp.EndUpdate();
        }

        private string GetSelectedFilePath()
        {
            // Gets the path of the selected item (file or folder) from the list view control
            if (listViewApp.SelectedItems.Count > 0)
            {
                // Get the file/folder name
                string selectedItemName = listViewApp.SelectedItems[0].Text;
                // Tạo đường dẫn đầy đủ bằng cách kết hợp với đường dẫn hiện tại
                return Path.Combine(currentPath, selectedItemName);
            }
            return null; // Null while no selected item
        }
        private string GetDestinationPath()
        {
            string destinationPath = this.txtPath.Text;

            // Check valid destinationfolder
            if (Directory.Exists(destinationPath))
            {
                return destinationPath;
            }
            else
            {
                MessageBox.Show("Đường dẫn đích không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            clipboardFilePath = GetSelectedFilePath();
            if (!string.IsNullOrEmpty(clipboardFilePath))
            {
                Clipboard.SetText(clipboardFilePath); // Store path in clipboard
                MessageBox.Show("File path copied to clipboard.");
            }
        }
        private async Task CopyFileAsync(string sourcePath, string destinationPath)
        {
            await Task.Run(() =>
            {
                using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024 * 1024]; // 1MB buffer
                    int bytesRead;
                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destinationStream.Write(buffer, 0, bytesRead);
                    }
                }
            });
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            cutFilePath = GetSelectedFilePath(); // Get the selected file/folder path
            if (!string.IsNullOrEmpty(cutFilePath))
            {
                isCutOperation = true; // Set cut operation flag
                clipboardFilePath = cutFilePath; // Store the path in clipboard
                MessageBox.Show("File path cut to clipboard.");
            }
        }
        private async Task MoveFileAsync(string sourcePath, string destinationPath)
        {
            await CopyFileAsync(sourcePath, destinationPath);
            File.Delete(sourcePath);
        }

        private async void btnPaste_Click(object sender, EventArgs e)
        {
            if (isCutOperation && !string.IsNullOrEmpty(cutFilePath))
            {
                string destinationPath = GetDestinationPath(); // Get the destination path
                if (!string.IsNullOrEmpty(destinationPath))
                {
                    try
                    {
                        // Perform the move operation
                        string fileName = Path.GetFileName(cutFilePath);
                        string destinationFilePath = Path.Combine(destinationPath, fileName);

                        // Check if the destination already has a file with the same name
                        if (File.Exists(destinationFilePath))
                        {
                            MessageBox.Show("File already exists at the destination!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Move the file
                        await MoveFileAsync(cutFilePath, destinationFilePath);
                        MessageBox.Show("File moved successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset cut operation flag
                        isCutOperation = false;
                        cutFilePath = ""; // Clear the cut file path
                        ShowFileNames();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while pasting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (File.Exists(clipboardFilePath))
            {
                await PasteFileAsync(clipboardFilePath);
                ShowFileNames();
            }
            else
            {
                MessageBox.Show("No valid file path in clipboard.");
            }
        }
        private async Task PasteFileAsync(string sourceFilePath)
        {
            string destinationPath = GetDestinationPath(); // Get the destination path

            if (!string.IsNullOrEmpty(destinationPath))
            {
                try
                {
                    string fileName = Path.GetFileName(sourceFilePath);
                    string destinationFilePath = Path.Combine(destinationPath, fileName);

                    // Check if the file already exists
                    if (File.Exists(destinationFilePath))
                    {
                        MessageBox.Show("File already exists at the destination!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Perform file copy
                    await CopyFileAsync(sourceFilePath, destinationFilePath);
                    MessageBox.Show("File pasted successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("You do not have permission to access this directory: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid destination path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedItems = listViewApp.SelectedItems.Cast<ListViewItem>().ToList();
            if (selectedItems.Any())
            {
                // Show confirmation dialog
                var confirmResult = MessageBox.Show("Are you sure you want to delete the selected items?",
                                                     "Confirm Deletion",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Check for hidden or system files
                    bool hasHiddenOrSystemFiles = selectedItems.Any(item =>
                    {
                        string filePath = Path.Combine(currentPath, item.Text);
                        FileInfo fileInfo = new FileInfo(filePath);
                        return (fileInfo.Attributes & FileAttributes.Hidden) != 0 ||
                               (fileInfo.Attributes & FileAttributes.System) != 0;
                    });

                    if (hasHiddenOrSystemFiles)
                    {
                        MessageBox.Show("Some selected items are hidden or system files and will not be deleted.",
                                        "Warning",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }

                    if (!backgroundWorkerDelete.IsBusy)
                    {
                        progressBar1.Visible = true;
                        progressBar1.Value = 0;
                        backgroundWorkerDelete.RunWorkerAsync(selectedItems);
                    }
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
                    // Check if the item is a file or a directory
                    if (fileInfo.Attributes.HasFlag(FileAttributes.Directory))
                    {
                        // Move directory to Recycle Bin
                        FileSystem.DeleteDirectory(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    }
                    else
                    {
                        // Move file to Recycle Bin
                        FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    }

                    backgroundWorkerDelete.ReportProgress(0); // Update progress
                }
                catch (Exception ex)
                {
                    // Handle the exception (e.g., log it or notify the user)
                    // You might want to report an error progress here
                }
            }
        }
        private void backgroundWorkerDelete_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false; // Hide progress bar after completion
            MessageBox.Show("Deletion completed!");
            ShowFileNames();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (listViewApp.SelectedItems.Count > 0)
            {
                var selectedItem = listViewApp.SelectedItems[0];
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
                // Get the parent directory path
                string parentDirectory = Directory.GetParent(currentPath)?.FullName;

                if (parentDirectory != null)
                {
                    // Push current path onto forward history
                    forwardHistory.Push(currentPath);

                    // Load the parent directory
                    LoadDirectory(parentDirectory);
                    ShowFileNames(); // Ensure listViewApp is updated
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
                ShowFileNames(); // Ensure listViewApp is updated
                SelectTreeViewNodeByPath(nextPath);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDirectory(currentPath);
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                //WebBrowser.Url = new Uri(folderBrowserDialog.SelectedPath);
                txtPath.Text = folderBrowserDialog.SelectedPath;

                LoadDirectory(folderBrowserDialog.SelectedPath);
                ShowFileNames();
            }
        }
        private void NewFolderItem_Click(object sender, EventArgs e)
        {
            string parentFolderPath = txtPath.Text;
            string newFolderName = "New Folder";
            string newFolderPath = Path.Combine(parentFolderPath, newFolderName);
            int count = 1;

            // Avoid duplicate folder names
            while (Directory.Exists(newFolderPath))
            {
                newFolderPath = Path.Combine(parentFolderPath, $"{newFolderName} {count}");
                count++;
            }

            // Create
            Directory.CreateDirectory(newFolderPath);
            MessageBox.Show($"New Folder Created: {newFolderPath}", "Notice");
        }

        private void listviewApp_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if an item is selected under the mouse cursor
                ListViewItem clickedItem = listViewApp.GetItemAt(e.X, e.Y);
                if (clickedItem != null)
                {
                    // Set the selected item
                    clickedItem.Selected = true;

                    // Show the existing context menu for files/folders
                    mnuRightClick.Show(listViewApp, e.Location);
                }
            }
        }
        private void listviewApp_DoubleClick(object sender, EventArgs e)
        {
            if (listViewApp.FocusedItem != null)
            {
                string diskfile = treeView.SelectedNode.FullPath;
                if (!diskfile.EndsWith("\\"))
                {
                    diskfile += "\\";
                }
                diskfile += listViewApp.FocusedItem.Text;

                FileInfo fileInfo = new FileInfo(diskfile);

                // Check if isFolder
                if (fileInfo.Attributes.HasFlag(FileAttributes.Directory))
                {
                    LoadDirectory(diskfile);
                    ShowFileNames();
                }
                else
                {
                    // Check hidden/system file
                    if ((fileInfo.Attributes & FileAttributes.Hidden) != 0 ||
                        (fileInfo.Attributes & FileAttributes.System) != 0)
                    {
                        MessageBox.Show("You cannot open hidden or system files.",
                                        "Access Denied",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }

                    // Open
                    Process.Start(new ProcessStartInfo { FileName = diskfile, UseShellExecute = true });
                }
            }
        }

        private void SelectTreeViewNodeByPath(string path)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                if (SelectNodeByPath(node, path))
                    break;
            }
        }
        private bool SelectNodeByPath(TreeNode node, string path)
        {
            if (node.FullPath.Equals(path, StringComparison.InvariantCultureIgnoreCase))
            {
                treeView.SelectedNode = node; // Select the node in the TreeView
                node.Expand(); // Expand the node
                return true;
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                if (SelectNodeByPath(childNode, path))
                    return true;
            }
            return false; // Return false if no match found
        }

        // Recursive function to find a TreeView node based on the directory path
        private TreeNode FindNodeByPath(TreeNode treeNode, string path)
        {
            DirectoryInfo dirInfo = (DirectoryInfo)treeNode.Tag;

            // Compare the full directory path with the path provided
            if (dirInfo.FullName.Equals(path, StringComparison.InvariantCultureIgnoreCase))
            {
                return treeNode;  // Return the node if the path matches
            }

            // Recursively search in child nodes (subdirectories)
            foreach (TreeNode childNode in treeNode.Nodes)
            {
                TreeNode foundNode = FindNodeByPath(childNode, path);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }

            return null;  // Return null if no match is found
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadDirectory(e.Node.FullPath);
        }
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeView.BeginUpdate();
            foreach (TreeNode tn in e.Node.Nodes)
            {
                AddDirs(tn);
            }
            treeView.EndUpdate();
        }
        
    }
}