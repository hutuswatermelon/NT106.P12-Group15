using System;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClientChat
{
    public partial class ClientForm : Form
    {
        private TcpClient tcpClient;
        private StreamReader sReader;
        private StreamWriter sWriter;
        private Thread clientThread;
        private int serverPort = 8000;
        private bool stopTcpClient = true;
        public const int BufferSize = 4096;
        public const int FileBufferSize = 3072;
        private string SaveFileName = string.Empty;
        private MemoryStream fileSaveMemoryStream;
        public enum
            MessageType
        {
            Text,
            FileEof,
            FilePart,
        }
        public ClientForm()
        {
            InitializeComponent();

        }
        
        /*[STAThread]
        private void ClientRecv()
        {
            NetworkStream networkStream = tcpClient.GetStream();
            //StreamReader sr = new StreamReader(networkStream);
            try
            {
                while (!stopTcpClient && tcpClient.Connected)
                {
                    Application.DoEvents();
                    //string data = sr.ReadLine();
                    byte[] readBuffers = new byte[BufferSize];
                    //                    string tmp = "";
                    while (networkStream.DataAvailable)
                    {
                        networkStream.Read(readBuffers, 0, BufferSize);
                        //tmp = Encoding.UTF8.GetString(readBuffers).Replace("\0", string.Empty);
                    }
                    string headerAndMessage = Encoding.UTF8.GetString(readBuffers).Replace("\0", string.Empty); ;
                    string[] arrPayload = headerAndMessage.Split(';');
                    if (arrPayload.Length >= 3)
                    {
                        string senderUsername = arrPayload[0];
                        MessageType msgType = (MessageType)Enum.Parse(typeof(MessageType), arrPayload[1], true);
                        if (msgType == MessageType.Text)
                        {
                            string content = arrPayload[2].Replace("\0", string.Empty);
                            string formattedMsg = $"{senderUsername}: {content} \n";
                            UpdateChatHistoryThreadSafe(formattedMsg);
                        }
                        else if (msgType == MessageType.FilePart)
                        {

                            if (string.IsNullOrEmpty(SaveFileName))
                            {
                                string message = "Receive incoming file ";
                                string caption = "File sent request";
                                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                DialogResult result;
                                result = MessageBox.Show(message, caption, buttons);
                                if (result == DialogResult.Yes)
                                {
                                    SaveFileDialog DialogSave = new SaveFileDialog();
                                    DialogSave.Filter = "All files (*.*)|*.*";
                                    DialogSave.RestoreDirectory = true;
                                    DialogSave.Title = "Where do you want to save the file?";
                                    DialogSave.InitialDirectory = @"C:/";
                                    if (DialogSave.ShowDialog() == DialogResult.OK)
                                    {
                                        SaveFileName = DialogSave.FileName;
                                        fileSaveMemoryStream = new MemoryStream();
                                    }

                                }
                            }

                            byte[] filePart = Encoding.UTF8.GetBytes(arrPayload[2].Replace("\0", string.Empty));
                            //                                byte[] RecData = new byte[FileBufferSize];

                            //                                FileStream fileStream = new FileStream
                            //                                    (SaveFileName, FileMode.OpenOrCreate, FileAccess.Write);
                            //                                while ((RecBytes = networkStream.Read
                            //                                           (RecData, 0, RecData.Length)) > 0)
                            //                                {
                            //                                    fileStream.Write(RecData, 0, RecBytes);
                            //                                    totalrecbytes += RecBytes;
                            //                                }

                            fileSaveMemoryStream?.Write(filePart, 0, filePart.Length);
                            //                                FileStream fs = File.OpenWrite(SaveFileName);
                            //                                fs.Close();


                        }
                        else if (msgType == MessageType.FileEof)
                        {
                            if (string.IsNullOrEmpty(SaveFileName))
                            {
                                string message = "Receive incoming file ";
                                string caption = "File sent request";
                                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                DialogResult result;
                                result = MessageBox.Show(message, caption, buttons);
                                if (result == DialogResult.Yes)
                                {
                                    SaveFileDialog DialogSave = new SaveFileDialog();
                                    DialogSave.Filter = "All files (*.*)|*.*";
                                    DialogSave.RestoreDirectory = true;
                                    DialogSave.Title = "Where do you want to save the file?";
                                    DialogSave.InitialDirectory = @"C:/";

                                    Invoke((Action)(() =>
                                    {
                                        if (DialogSave.ShowDialog() == DialogResult.OK)
                                        {
                                            SaveFileName = DialogSave.FileName;
                                        }
                                    }));


                                }
                            }
                            byte[] finalFilePart = Encoding.UTF8.GetBytes(arrPayload[2].Replace("\0", string.Empty));

                            if (fileSaveMemoryStream != null)
                            {
                                fileSaveMemoryStream.Write(finalFilePart, 0, finalFilePart.Length);
                                using (FileStream fs = File.OpenWrite(SaveFileName))
                                {
                                    fileSaveMemoryStream.WriteTo(fs);
                                }
                            }
                            else
                            {
                                using (FileStream fs = File.OpenWrite(SaveFileName))
                                {
                                    fs.Write(finalFilePart, 0, finalFilePart.Length);
                                }

                            }
                            fileSaveMemoryStream = null;
                            SaveFileName = null;
                        }
                    }
                }
            }
            catch (SocketException sockEx)
            {
                tcpClient.Close();

            }
        }
        */
        private delegate void SafeCallDelegate(string text);

        private delegate void SaveFileConfirmDialogDelegate(DialogResult result);
        private void UpdateChatHistoryThreadSafe(string text)
        {
            if (txtChatLog.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateChatHistoryThreadSafe);
                txtChatLog.Invoke(d, new object[] { text });
            }
            else
            {
                txtChatLog.Text += text;
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkStream ns = tcpClient.GetStream();
                string allInOneMsg = $"{txtFriend.Text};{MessageType.Text.ToString()};{sendMsgTextBox.Text}";
                byte[] sendingBytes = Encoding.UTF8.GetBytes(allInOneMsg);
                ns.Write(sendingBytes, 0, sendingBytes.Length);
                //                sWriter.WriteLine($"{textBox3.Text};{sendMsgTextBox.Text}");
                sendMsgTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool isConnected = false;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (isConnected == false)
                {
                    button2.Text = "Connected";
                    isConnected = true;
                }
                else
                {
                    button2.Text = "Connect";
                }
                stopTcpClient = false;

                this.tcpClient = new TcpClient();
                this.tcpClient.Connect(new IPEndPoint(IPAddress.Parse(txtIPAddr.Text), serverPort));
                this.sWriter = new StreamWriter(tcpClient.GetStream())
                {
                    AutoFlush = true
                };
                sWriter.WriteLine(this.txtUsername.Text);
                clientThread = new Thread(this.ClientRecv);
                clientThread.Start();
                if (isConnected == false) MessageBox.Show("Disconnected");
                else MessageBox.Show("Connected");
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show(sockEx.Message, "Network error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void openToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string fileContent = string.Empty;
        //    string filePath = string.Empty;
        //    byte[] sendingBuffer = null;
        //    try
        //    {
        //        NetworkStream networkStream = tcpClient.GetStream();
        //        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //        {
        //            openFileDialog.InitialDirectory = "c:\\";
        //            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        //            openFileDialog.FilterIndex = 2;
        //            openFileDialog.RestoreDirectory = true;

        //            if (openFileDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                //Get the path of specified file
        //                // filePath = openFileDialog.FileName
        //                byte[] headerBytes = Encoding.UTF8.GetBytes($"{txtFriend.Text};{MessageType.FilePart};");

        //                using (Stream fileStream = openFileDialog.OpenFile())
        //                {
        //                    int NoOfPackets = Convert.ToInt32
        //                        (Math.Ceiling(Convert.ToDouble(fileStream.Length) / Convert.ToDouble(FileBufferSize)));
        //                    progressBar1.Maximum = NoOfPackets;
        //                    int TotalLength = (int)fileStream.Length, CurrentPacketLength, counter = 0;
        //                    for (int i = 0; i < NoOfPackets; i++)
        //                    {
        //                        if (TotalLength > FileBufferSize)
        //                        {
        //                            CurrentPacketLength = FileBufferSize;
        //                            TotalLength = TotalLength - CurrentPacketLength;
        //                        }
        //                        else
        //                        {
        //                            CurrentPacketLength = TotalLength;
        //                            headerBytes = Encoding.UTF8.GetBytes($"{txtFriend.Text};{MessageType.FileEof};");
        //                        }

        //                        sendingBuffer = new byte[CurrentPacketLength];
        //                        fileStream.Read(sendingBuffer, 0, CurrentPacketLength);

        //                        byte[] sendingBytes = headerBytes.Concat(sendingBuffer).ToArray();
        //                        networkStream.Write(sendingBytes, 0, (int)sendingBytes.Length);
        //                        if (progressBar1.Value >= progressBar1.Maximum)
        //                            progressBar1.Value = progressBar1.Minimum;
        //                        progressBar1.PerformStep();
        //                    }

        //                    progressBar1.Value = progressBar1.Minimum;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        private void btnSendFile(object sender, EventArgs e)
        {
            try
            {
                NetworkStream networkStream = tcpClient.GetStream();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the path of the selected file
                        string filePath = openFileDialog.FileName;

                        // Read file in binary mode
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[FileBufferSize]; // Use binary buffer
                            int bytesRead = 0;
                            int totalBytes = (int)fileStream.Length;
                            int packetsCount = (int)Math.Ceiling((double)totalBytes / FileBufferSize);
                            progressBar1.Maximum = packetsCount;

                            // Sending file in chunks
                            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                // Check if this is the last chunk
                                string messageType = (bytesRead < FileBufferSize) ? MessageType.FileEof.ToString() : MessageType.FilePart.ToString();

                                // Build header
                                byte[] headerBytes = Encoding.UTF8.GetBytes($"{txtFriend.Text};{messageType};");

                                // Combine header and file chunk
                                byte[] sendingBytes = headerBytes.Concat(buffer.Take(bytesRead)).ToArray();

                                // Send data
                                networkStream.Write(sendingBytes, 0, sendingBytes.Length);

                                // Update progress bar
                                progressBar1.PerformStep();
                            }

                            // Reset progress bar
                            progressBar1.Value = progressBar1.Minimum;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        [STAThread]
        private void ClientRecv()
        {
            NetworkStream networkStream = tcpClient.GetStream();
            try
            {
                while (!stopTcpClient && tcpClient.Connected)
                {
                    byte[] readBuffer = new byte[BufferSize];
                    int bytesRead = 0;
                    string headerAndMessage = string.Empty;

                    // Đọc dữ liệu từ luồng
                    if (networkStream.DataAvailable)
                    {
                        bytesRead = networkStream.Read(readBuffer, 0, BufferSize);
                        headerAndMessage = Encoding.UTF8.GetString(readBuffer, 0, bytesRead).Replace("\0", string.Empty);
                    }

                    string[] arrPayload = headerAndMessage.Split(';');
                    if (arrPayload.Length >= 3)
                    {
                        string senderUsername = arrPayload[0];
                        MessageType msgType = (MessageType)Enum.Parse(typeof(MessageType), arrPayload[1], true);

                        if (msgType == MessageType.Text)
                        {
                            string content = arrPayload[2];
                            string formattedMsg = $"{senderUsername}: {content} \n";
                            UpdateChatHistoryThreadSafe(formattedMsg);
                        }
                        else if (msgType == MessageType.FilePart || msgType == MessageType.FileEof)
                        {
                            if (fileSaveMemoryStream == null)
                            {
                                // Khởi tạo MemoryStream để lưu file tạm thời
                                fileSaveMemoryStream = new MemoryStream();
                            }

                            // Nhận phần file
                            byte[] filePart = Encoding.UTF8.GetBytes(arrPayload[2]);

                            // Ghi phần file vào MemoryStream
                            fileSaveMemoryStream.Write(filePart, 0, filePart.Length);

                            // Khi nhận được tín hiệu EOF (cuối file)
                            if (msgType == MessageType.FileEof)
                            {
                                // Hiển thị hộp thoại xác nhận sau khi tải file xong
                                Invoke((Action)(() =>
                                {
                                    DialogResult result = MessageBox.Show("File download completed. Do you want to save the file?", "File Transfer", MessageBoxButtons.YesNo);
                                    if (result == DialogResult.Yes)
                                    {
                                        SaveFileDialog saveFileDialog = new SaveFileDialog
                                        {
                                            Filter = "All files (*.*)|*.*",
                                            RestoreDirectory = true
                                        };

                                        // Nếu người dùng chọn vị trí để lưu file
                                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                        {
                                            SaveFileName = saveFileDialog.FileName;

                                            // Ghi dữ liệu từ MemoryStream ra file
                                            using (FileStream fs = new FileStream(SaveFileName, FileMode.Create, FileAccess.Write))
                                            {
                                                fileSaveMemoryStream.WriteTo(fs);
                                            }

                                            MessageBox.Show("File saved successfully!");
                                        }
                                    }

                                    // Dọn dẹp bộ nhớ sau khi hoàn thành
                                    fileSaveMemoryStream = null;
                                    SaveFileName = string.Empty;
                                }));
                            }
                        }
                    }
                }
            }
            catch (SocketException sockEx)
            {
                tcpClient.Close();
                MessageBox.Show("Connection lost: " + sockEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

