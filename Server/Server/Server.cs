using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;
using System.Net.NetworkInformation;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace frmServer
{
    public partial class frmServer : Form
    {
        private Socket server, client;
        Socket initalize_sk;
        byte[] buffReceive = new byte[1024];
        byte[] buffSend = new byte[1024];
        string userSend = "";
        private delegate void updateUI(string message);
        private updateUI updateUi;

        RoomList lstRoom = new RoomList();
        UserList lstUser = new UserList();
        List<Socket> Client = new List<Socket>();
        public frmServer()
        {
            InitializeComponent();
            updateUi = new updateUI(Update);
            CheckForIllegalCrossThreadCalls = false;
            IPAddress iPAddress = getIP();
            txtIPServer.Text = iPAddress.ToString();
        }
        private void Update(string msg)
        {
            lstLog.Items.Add(msg);
            lstLog.TopIndex = lstLog.Items.Count - 1;
        }
        private IPAddress getIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    //MessageBox.Show(ip.ToString());
                    return ip;
                }
            }
            throw new Exception("No IPv4 address found.");
        }
        private void startServer()
        {
            EndPoint ipep = new IPEndPoint(IPAddress.Any, 8000);    // khai báo ip và port


            //IPAddress ipAddress = getIP();
            //IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 9050);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // tạo 1 đối tượng socket
            server.Bind(ipep);      // gán socket với địa chỉ ip và port
            server.Listen(10);
            server.BeginAccept(new AsyncCallback(beginAccept), server); // định nghĩa delegate đx dùng khi có kết nối tới. truyền tham số beginAccept vào
            updateUi("Đang lắng nghe các kết nối...");
            //StartUDPBroadcast();
        }

        // send data  
        private void sendText(IAsyncResult iar)
        {
            Socket s = (Socket)iar.AsyncState;
            //socket_send.EndSend(iar);
            s.EndSend(iar);
        }
        private void sendData(string data, Socket sk)
        {
            buffSend = new byte[1024];
            buffSend = Encoding.UTF8.GetBytes(data);
            sk.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendText), sk);
            //updateUi("Server: " + txtSend.Text);
        }

        Socket socket_send;
        private void beginAccept(IAsyncResult ar)  // iasyncResult truyền giá trị bất đồng bộ từ BeginAccept đến EndAccept
        {
            // ar chứ
            Socket s = (Socket)ar.AsyncState; // nhận socket ban đầu của Server . ép kiểu đối tượng qua soket
            client = s.EndAccept(ar);   // trả về socket dùng để kết nối với client trong nhận gửi data
            updateUi("Đã kết nối với " + client.RemoteEndPoint.ToString());


            // đăng ký nhận dữ liệu
            client.BeginReceive(buffReceive, 0, buffReceive.Length, SocketFlags.None, new AsyncCallback(beginReceive), client);
            Client.Add(client);
            socket_send = client;

            EndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);    // khai báo ip và port
            server.BeginAccept(new AsyncCallback(beginAccept), server);
        }

        // thực hiện việc nhận dữ liệu khi có dữ liệu tới
        private void beginReceive(IAsyncResult ia)
        {
            int bytesReceive = 0;
            try
            {
                Socket s = (Socket)ia.AsyncState;
                bytesReceive = s.EndReceive(ia);
                string receive = Encoding.UTF8.GetString(buffReceive, 0, bytesReceive);
                string str = receive;

                if (receive == "exit")
                {
                    s.Close();
                }
                else
                {
                    try
                    {
                        string playerName = "";
                        // lấy tên người chơi
                        foreach (User us in lstUser.ListPlayer)
                        {
                            if (us._Socket.RemoteEndPoint.ToString() == s.RemoteEndPoint.ToString())
                            {
                                playerName = us.UserName;
                                break;
                            }
                        }
                        //Kiểm tra đăng nhập
                        if (receive.Substring(0, 8) == "#_TCP_DN")
                        {
                            Check_SignIn(receive, s);
                        }
                        //Kiểm tra đăng ký
                        if (receive.Substring(0, 8) == "#_TCP_DK")
                        {
                            Check_SignUp(receive, s);
                        }
                        if (receive.Substring(0, 8) == "#_TCP_IR")
                        {
                            foreach (User us in lstUser.ListPlayer)
                            {
                                if (us._Socket.RemoteEndPoint.ToString() == s.RemoteEndPoint.ToString())
                                {
                                    int _nr = (int.Parse(receive[8].ToString()) + 1);
                                    if (lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer.Count() >= 2)
                                    {
                                        sendData("#_TCP_FULL", s);
                                    }
                                    else
                                    {
                                        lstRoom.ListRoom[int.Parse(receive[8].ToString())].addPlayer(us);
                                        us.RoomNumber = _nr;
                                        updateListView(us);
                                        updateUi(us.UserName + " đã vào phòng " + _nr.ToString());
                                        if (lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer.Count() == 2)
                                        {
                                            lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer[0].LuotDi = 1;
                                            sendData("#_TCP_LD1" + lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer[0].UserName.ToString(), lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer[0]._Socket);
                                            updateUi("Room" + receive[8].ToString() + "_" + lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer[0].UserName.ToString() + " có lượt đi " + (1).ToString());
                                            lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer[1].LuotDi = 2;
                                            sendData("#_TCP_LD2" + lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer[1].UserName.ToString(), lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer[1]._Socket);
                                            updateUi("Room" + receive[8].ToString() + "_" + lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer[1].UserName.ToString() + " có lượt đi " + (2).ToString());
                                        }

                                        us.InRoom = true;
                                        foreach (User _us in lstUser.ListPlayer)
                                        {
                                            sendData("#_TCP_UD" + receive[8].ToString() + lstRoom.ListRoom[int.Parse(receive[8].ToString())].playerCount(), _us._Socket);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        if (receive.Substring(0, 8) == "#_TCP_OR")
                        {
                            foreach (User us in lstUser.ListPlayer)
                            {
                                if (us._Socket.RemoteEndPoint.ToString() == s.RemoteEndPoint.ToString())
                                {
                                    int _nr = (int.Parse(receive[8].ToString()) + 1);
                                    updateUi(us.UserName + " đã rời phòng " + _nr.ToString());
                                    us.RoomNumber = 0;
                                    updateListView(us);
                                    us.InRoom = false;
                                    lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer.Remove(us);
                                    foreach (User _us in lstUser.ListPlayer)
                                    {
                                        sendData("#_TCP_UD" + receive[8].ToString() + lstRoom.ListRoom[int.Parse(receive[8].ToString())].playerCount(), _us._Socket);
                                    }
                                    break;
                                }
                            }
                        }
                        if (receive.Substring(0, 8) == "#_TCP_DO")
                        {
                            Random rd = new Random();
                            int number = rd.Next(1, 7);

                            if (lstRoom.ListRoom[int.Parse(receive[9].ToString())].GiaTriXNTruoc == 0)
                            {
                                if (number == 1 || number == 6)
                                {
                                    foreach (User us in lstRoom.ListRoom[int.Parse(receive[9].ToString())].ListPlayer)
                                    {
                                        sendData("#_TCP_VA" + receive[8].ToString() + number.ToString(), us._Socket);
                                    }
                                }
                                else
                                {
                                    foreach (User us in lstRoom.ListRoom[int.Parse(receive[9].ToString())].ListPlayer)
                                    {
                                        //int ld = doiLuotDi(int.Parse(receive[8].ToString()));
                                        //sendData("#_TCP_VA" + ld.ToString() + number.ToString(), us._Socket);
                                    }
                                }
                                lstRoom.ListRoom[int.Parse(receive[9].ToString())].GiaTriXNTruoc = number;
                            }
                            else
                            {
                                if (number == 1 || number == 6)
                                {
                                    foreach (User us in lstRoom.ListRoom[int.Parse(receive[9].ToString())].ListPlayer)
                                    {
                                        sendData("#_TCP_VA" + receive[8].ToString() + number.ToString(), us._Socket);
                                    }
                                }
                                else
                                {
                                    foreach (User us in lstRoom.ListRoom[int.Parse(receive[9].ToString())].ListPlayer)
                                    {
                                        //int ld = doiLuotDi(int.Parse(receive[8].ToString()));
                                        //sendData("#_TCP_VA" + ld.ToString() + number.ToString(), us._Socket);
                                    }
                                }
                            }
                            updateUi("Room" + receive[9].ToString() + "_" + playerName + ": lắc được xí ngầu " + number.ToString());
                        }
                        if (receive.Substring(0, 8) == "#_TCP_UB")
                        {
                            string _str = "";
                            for (int i = 11; i < receive.Length; i++)
                            {
                                if (receive[i] == '_')
                                {
                                    break;
                                }
                                _str += receive[i];
                            }
                            foreach (User us in lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer)
                            {
                                if (us._Socket.RemoteEndPoint.ToString() != s.RemoteEndPoint.ToString())
                                {
                                    sendData("#_TCP_UB" + receive[8].ToString() + receive[9].ToString() + receive[10].ToString() + _str, us._Socket);
                                    //MessageBox.Show("#_TCP_UB" + receive[8].ToString() + receive[9].ToString() + receive[10].ToString() + _str);
                                }
                                //sendData("#_TCP_UB" + receive[8].ToString() + receive[9].ToString() + receive[10].ToString() + _str, us._Socket);
                            }
                        }
                        if (receive.Substring(0, 8) == "#_TCP_VD")
                        {
                            foreach (User us in lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer)
                            {
                                sendData("#_TCP_KQ" + playerName, us._Socket);
                            }
                        }
                        if (receive.Substring(0, 9) == "#_TCP_DMK")
                        {
                            ChangePassword(receive, s, playerName);
                        }
                        if (receive.Substring(0, 9) == "#_Chat_00")
                        {
                            updateUi(playerName + ": " + receive.Substring(9));

                            for (int i = 0; i < lstUser.ListPlayer.Count; i++)
                            {
                                if (!lstUser.ListPlayer[i].InRoom)
                                {
                                    sendData("#_Chat_00" + playerName + ": " + receive.Substring(9), lstUser.ListPlayer[i]._Socket);
                                }
                            }
                        }
                        if (receive.Substring(0, 8) == "#_Chat_1")
                        {
                            for (int i = 0; i < lstRoom.ListRoom[int.Parse(receive[8].ToString())].playerCount(); i++)
                            {
                                sendData("#_Chat_00" + playerName + ": " + receive.Substring(9), lstRoom.ListRoom[int.Parse(receive[8].ToString())].ListPlayer[i]._Socket);
                                updateUi("Room" + receive[8].ToString() + "_" + playerName + ": " + receive.Substring(9));
                            }
                        }
                        updateUi(s.RemoteEndPoint.ToString() + ": " + receive);
                    }
                    catch
                    {
                        updateUi("Client: " + receive);
                    }

                    s.BeginReceive(buffReceive, 0, buffReceive.Length, SocketFlags.None, new AsyncCallback(beginReceive), s);
                }
            }
            catch { }
        }

        /// <summary>
        /// Listview kiểm tra account online
        /// </summary>
        /// <param name="us"></param>
        private void addListView(User us)
        {

            int s = lstUser.playerCount();
            string[] _str = { s.ToString(), us.UserName, us._Socket.RemoteEndPoint.ToString(), us.RoomNumber.ToString() };
            ListViewItem item = new ListViewItem(_str);
            lstAccount.Items.Add(item);
        }
        private void updateListView(User us)
        {
            for (int i = 0; i < lstAccount.Items.Count; i++)
            {
                if (us.UserName == lstAccount.Items[i].SubItems[1].Text.ToString())
                {
                    lstAccount.Items[i].SubItems[3].Text = us.RoomNumber.ToString();
                    break;
                }
            }
        }
        #region Check_SignInUp
        private void Check_SignIn(string str, Socket sk)
        {
            string user_client = "";
            string pass_client = "";

            // Đảm bảo độ dài chuỗi hợp lệ trước khi truy cập
            if (str.Length > 8)
            {
                for (int i = 8; i < str.Length; i++)
                {
                    if (str[i] == ' ')
                    {
                        pass_client = str.Substring(i + 1);
                        break;
                    }
                    user_client += str[i];
                }
            }

            bool checkLogIn = false;
            bool checkStt = false;
            foreach (User us in lstUser.ListPlayer)
            {
                if (us.UserName == user_client)
                {
                    checkStt = true;
                    break;
                }
            }

            if (!checkStt)
            {
                XmlReaderSettings settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Prohibit };
                using (XmlReader reader = XmlReader.Create("ACCOUNT.xml", settings))
                {
                    XmlDocument docXML = new XmlDocument();
                    docXML.Load(reader);

                    XmlNodeList userList = docXML.SelectNodes("//user");
                    foreach (XmlNode node in userList)
                    {
                        if (node.Attributes?["id"]?.Value == user_client)
                        {
                            if (node.InnerText ==   HashPassword(pass_client))
                            {
                                updateUi(user_client + " đã online");
                                User us = new User(user_client, sk);
                                lstUser.addPlayer(us);
                                buffSend = Encoding.UTF8.GetBytes("#_TCP_DNTC");
                                sk.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendText), sk);
                                checkLogIn = true;
                                break;
                            }
                        }
                    }
                }
                if (!checkLogIn)
                {
                    buffSend = Encoding.UTF8.GetBytes("#_TCP_DNTB");
                    sk.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendText), sk);
                }
            }
            else
            {
                buffSend = Encoding.UTF8.GetBytes("#_TCP_DNTT");
                sk.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendText), sk);
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // chuyển byte sang chuỗi thập lục phân
                }
                return builder.ToString();
            }
        }


        public void Check_SignUp(string str, Socket sk)
        {
            string user_client = "";
            string pass_client = "";
            for (int i = 8; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    pass_client = str.Substring(i + 1);
                    break;
                }
                user_client += str[i];
            }

            XmlDocument docXML = new XmlDocument();
            docXML.Load("ACCOUNT.xml");

            XmlNode user = docXML.SelectSingleNode("//account");
            XmlNodeList userList = user.SelectNodes("//user");
            bool check = true;
            foreach (XmlNode nd in userList)
            {
                if (nd.Attributes != null)
                {
                    if (nd.Attributes["id"].Value == user_client)
                    {
                        check = false;
                        buffSend = new byte[1024];
                        buffSend = Encoding.UTF8.GetBytes("#_TCP_DKTB");
                        sk.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendText), sk);
                    }
                }
            }

            if (check == true)
            {
                XmlNode node = docXML.CreateNode(XmlNodeType.Element, "user", null);
                node.InnerText = pass_client;
                XmlAttribute id1 = docXML.CreateAttribute("id");
                id1.Value = user_client;
                node.Attributes.Append(id1);
                docXML.SelectSingleNode("account").AppendChild(node);
                docXML.Save("ACCOUNT.xml");

                updateUi("Tài khoản " + user_client + " đã đăng kí thành công!");

                buffSend = new byte[1024];
                buffSend = Encoding.UTF8.GetBytes("#_TCP_DKTC");
                sk.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendText), sk);
            }
        }
        public void ChangePassword(string str, Socket sk, string name)
        {
            string pass_client = "";
            pass_client = str.Substring(9);
            XmlDocument docXML = new XmlDocument(); // tạo đối tượng xml
            docXML.Load("ACCOUNT.xml"); //load file xml có sẵn
            XmlNode user = docXML.SelectSingleNode("//account"); // chọn node gốc
            XmlNodeList userList = user.SelectNodes("//user");  //lấy danh sách các node có tên user
            foreach (XmlNode nd in userList)                    // duyệt danh sách node
            {
                if (nd.Attributes != null)
                {
                    if (nd.Attributes["id"].Value == name) /// so sánh thuộc tính node với username
                    {
                        nd.InnerText = pass_client;
                        buffSend = new byte[1024];
                        buffSend = Encoding.UTF8.GetBytes("#_TCP_DMKTC");
                        sk.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendText), sk);
                        break;
                    }
                }
            }
            docXML.Save("ACCOUNT.xml");
        }
        #endregion
        private void btnListen_Click(object sender, EventArgs e)
        {
            startServer();
            timer2.Start();
        }

        private void btnCloseServer_Click(object sender, EventArgs e)
        {
            
            timer2.Stop();
        }

        private void btnSendMsgfromServer_Click(object sender, EventArgs e)
        {
            if (lblReceiver.Text != "")
            {

                if (txtMessage.Text != "")
                {
                    for (int i = 0; i < lstUser.playerCount(); i++)
                    {
                        if (lblReceiver.Text == lstUser.ListPlayer[i].UserName)
                        {
                            initalize_sk = lstUser.ListPlayer[i]._Socket;
                            break;
                        }
                    }
                    buffSend = new byte[1024];
                    buffSend = Encoding.UTF8.GetBytes("#_Chat_00Server: " + txtMessage.Text);
                    initalize_sk.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendText), initalize_sk);
                    updateUi("Server -> " + lblReceiver.Text + ": " + txtMessage.Text);
                    txtMessage.Text = "";
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("Chưa nhập nội dung tin nhắn.");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn người gửi !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lstAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = lstAccount.SelectedItems[0];
                lblReceiver.Text = item.SubItems[1].Text.ToString();
            }
            catch
            {

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblReceiver.Text = "";
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Thread threadRun = new Thread(
                delegate ()
                {
                    timTimeOut();
                }
                );
            threadRun.Start();
        }
        private void timTimeOut()
        {
            if (lstUser.ListPlayer.Count > 0)
            {
                foreach (User us in lstUser.ListPlayer)
                {
                    if (!isConnected(us._Socket))
                    {
                        if (us.InRoom == true)
                        {
                            lstRoom.ListRoom[us.RoomNumber].ListPlayer.Remove(us);
                        }

                        foreach (ListViewItem item in lstAccount.Items)
                        {
                            if (item.SubItems[1].Text == us.UserName)
                            {
                                lstAccount.Items.Remove(item);
                            }
                        }
                        updateUi(us.UserName + " is disconnected ...");
                        lstUser.ListPlayer.Remove(us);
                        break;
                    }
                }
            }
            else
            {
                //MessageBox.Show("No connect ...");
            }
        }
        public bool isConnected(Socket s)
        {
            try
            {
                return !(s.Poll(10, SelectMode.SelectRead) && s.Available == 0);
            }
            catch (SocketException)
            {
                return false;
            }
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            lstAccount.Columns.Add("STT", 60);
            lstAccount.Columns.Add("Tên", 130);
            lstAccount.Columns.Add("Địa chỉ IP", 110);
            lstAccount.Columns.Add("Phòng", 60);
        }
    }
}
