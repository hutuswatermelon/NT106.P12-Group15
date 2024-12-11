using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Linq.Expressions;
using System.Timers;

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
        Dictionary<int, System.Timers.Timer> roomTimers = new Dictionary<int, System.Timers.Timer>();

        private bool isServerRunning = false; // Kiểm tra trạng thái server

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
            if (isServerRunning) return; // Kiểm tra nếu server đang chạy
            EndPoint ipep = new IPEndPoint(IPAddress.Any, 8000);    // khai báo ip và port

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // tạo 1 đối tượng socket
            server.Bind(ipep);      // gán socket với địa chỉ ip và port
            server.Listen(10);
            server.BeginAccept(new AsyncCallback(beginAccept), server); // định nghĩa delegate đx dùng khi có kết nối tới. truyền tham số beginAccept vào
            updateUi("Đang lắng nghe các kết nối...");
            isServerRunning = true;
        }

        // send data  
        private void sendText(IAsyncResult iar)
        {
            Socket s = (Socket)iar.AsyncState;
            s.EndSend(iar);
        }
        private void sendData(string data, Socket sk)
        {
            buffSend = new byte[1024];
            buffSend = Encoding.UTF8.GetBytes(data);
            sk.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendText), sk);
        }

        private void beginAccept(IAsyncResult ar)  // iasyncResult truyền giá trị bất đồng bộ từ BeginAccept đến EndAccept
        {
            if (server == null || !server.IsBound) return;
            // ar chứ
            Socket s = (Socket)ar.AsyncState; // nhận socket ban đầu của Server . ép kiểu đối tượng qua soket
            client = s.EndAccept(ar);   // trả về socket dùng để kết nối với client trong nhận gửi data
            updateUi("Đã kết nối với " + client.RemoteEndPoint.ToString());

            // đăng ký nhận dữ liệu
            client.BeginReceive(buffReceive, 0, buffReceive.Length, SocketFlags.None, new AsyncCallback(beginReceive), client);
            Client.Add(client);

            EndPoint ipep = new IPEndPoint(IPAddress.Any, 8000);    // khai báo ip và port
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
                if (receive.StartsWith("YOUR_API_KEY"))
                {


                    string[] parts = receive.Split('|');
                    if (parts.Length < 2)
                    {
                        updateUi("Định dạng thông điệp không hợp lệ.");
                        s.Close();
                        return;
                    }

                    // Lấy APIKey HMAC từ chuỗi nhận được
                    string clientHMAC = parts[2];
                    string apiKey = "YOUR_API_KEY";  // APIKey thực tế của bạn
                    string secret = "YOUR_SECRET_KEY";  // Secret thực tế của bạn

                    // Xác thực HMAC
                    if (ValidateHMAC(clientHMAC, apiKey, secret))
                    {
                        updateUi("HMAC hợp lệ, kết nối client thành công!");

                        // Gửi lệnh xác thực thành công về client
                        sendData("#_APIKeyValidated",s); // Lệnh này sẽ bật nút btnSignin và btnSignup ở client
                                                              // Cho phép client tiếp tục gửi các lệnh khác
                        s.BeginReceive(buffReceive, 0, buffReceive.Length, SocketFlags.None, new AsyncCallback(beginReceive), s);
                        updateUi("Đã gửi #_APIKeyValidated đến client.");


                    }
                    else
                    {
                        updateUi("HMAC không hợp lệ, ngắt kết nối!");
                        s.Close();
                        return;
                    }

                }
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
                                    int roomID = int.Parse(receive[8].ToString());
                                    if (lstRoom.ListRoom[roomID].ListPlayer.Count() >= lstRoom.ListRoom[roomID].MaxPlayers)
                                    {
                                        
                                    }
                                    else
                                    {
                                        lstRoom.ListRoom[roomID].addPlayer(us);
                                        us.RoomNumber = _nr;
                                        updateListView(us);
                                        updateUi(us.UserName + " đã vào phòng " + _nr.ToString());
                                        if (lstRoom.ListRoom[roomID].ListPlayer.Count() == 1)
                                        {
                                            us.IsMaster = true;
                                            sendData("#_TCP_BM", s);
                                        }
                                        us.InRoom = true;

                                        int timeIndex = 1;
                                        int roundIndex = 1;
                                        int timelimit = lstRoom.ListRoom[roomID].StoryTimeLimit;
                                        int maxRounds = lstRoom.ListRoom[roomID].MaxRounds;
                                        updateUi(roomID + " " + timelimit.ToString() + " " + maxRounds.ToString());
                                        switch (lstRoom.ListRoom[roomID].StoryTimeLimit)
                                        {
                                            case 10:
                                                timeIndex = 0;
                                                break;
                                            case 15:
                                                timeIndex = 1;
                                                break;
                                            case 30:
                                                timeIndex = 2;
                                                break;
                                            case 60:
                                                timeIndex = 3;
                                                break;
                                            default:
                                                break;
                                        }

                                        if (maxRounds == lstRoom.ListRoom[roomID].playerCount() + 1)
                                            roundIndex = 0;
                                        else if (maxRounds == lstRoom.ListRoom[roomID].playerCount() + 2)
                                            roundIndex = 1;
                                        else
                                        {
                                            switch(maxRounds)
                                            {
                                                case 4:
                                                    roundIndex = 2;
                                                    break;
                                                case 5:
                                                    roundIndex = 3;
                                                    break;
                                                case 6:
                                                    roundIndex = 4;
                                                    break;
                                                case 7:
                                                    roundIndex = 5;
                                                    break;
                                                case 8:
                                                    roundIndex = 6;
                                                    break;
                                                case 9:
                                                    roundIndex = 7;
                                                    break;
                                                case 10:
                                                    roundIndex = 8;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        updateUi(roundIndex.ToString() + " " + timeIndex.ToString());
       

                                        for (int i = 0; i < lstRoom.ListRoom[roomID].playerCount(); i++)
                                        {
                                            User _us = lstRoom.ListRoom[roomID].ListPlayer[i];

                                            Thread.Sleep(200);

                                            // Cập nhật danh sách tên người chơi trong phòng
                                            string msg2 = "#_TCP_UP" + receive[8].ToString() + lstRoom.ListRoom[roomID].playerCount()
                                                + lstRoom.ListRoom[roomID].MaxPlayers;
                                            // Lấy danh sách tên người chơi
                                            var playerNames = lstRoom.ListRoom[roomID].ListPlayer.Select(p => p.UserName);
                                            msg2 += string.Join(" ", playerNames); // Sử dụng Join để tạo chuỗi tên người chơi
                                            sendData(msg2, _us._Socket);
                                        }
                                        foreach (User _us in lstUser.ListPlayer)
                                        {
                                            Thread.Sleep(200);
                                            string msg1 = "#_TCP_UL" + receive[8].ToString() + lstRoom.ListRoom[roomID].playerCount();
                                            sendData(msg1, _us._Socket);
                                            Thread.Sleep(200);
                                            
                                            //MessageBox.Show(msg2);
                                        }
                                        string msg = "#_TCP_US" + lstRoom.ListRoom[roomID].RoomNumber + timeIndex + roundIndex;
                                        sendData(msg, us._Socket);
                                    }
                                    break;
                                }
                            }
                        }
                        if (receive.Substring(0, 8) == "#_TCP_MP") //Max player in room
                        {
                            lstRoom.ListRoom[int.Parse(receive[8].ToString())].MaxPlayers = int.Parse(receive[9].ToString());
                            foreach (User _us in lstUser.ListPlayer)
                            {
                                sendData("#_TCP_MP" + receive[8].ToString() + lstRoom.ListRoom[int.Parse(receive[8].ToString())].MaxPlayers, _us._Socket);
                            }
                        }
                        if (receive.Substring(0, 8) == "#_TCP_OR")
                        {
                            int roomID = int.Parse(receive[8].ToString());
                            foreach (User us in lstUser.ListPlayer)
                            {
                                if (us._Socket.RemoteEndPoint.ToString() == s.RemoteEndPoint.ToString())
                                {
                                    int roomNumber = us.RoomNumber;
                                    if (us.IsMaster)
                                    {
                                        updateUi($"Quản trò phòng {roomNumber} đã rời.");
                                        HandleMasterExit(s, roomNumber);
                                    }
                                    
                                    updateUi(us.UserName + " đã rời phòng " + roomNumber.ToString());
                                    us.RoomNumber = 0;
                                    us.IsMaster = false;
                                    us.InRoom = false;
                                    updateListView(us);
                                    lstRoom.ListRoom[roomID].ListPlayer.Remove(us);
                                    foreach (User _us in lstUser.ListPlayer)
                                    {
                                        sendData("#_TCP_UL" + roomID + lstRoom.ListRoom[roomID].playerCount(), _us._Socket);
                                        Thread.Sleep(200);    
                                        // Cập nhật danh sách tên người chơi trong phòng
                                        string msg2 = "#_TCP_UP" + roomID + lstRoom.ListRoom[roomID].playerCount()
                                            + lstRoom.ListRoom[roomID].MaxPlayers;

                                        // Lấy danh sách tên người chơi
                                        var playerNames = lstRoom.ListRoom[roomID].ListPlayer.Select(p => p.UserName);
                                        msg2 += string.Join(" ", playerNames); // Sử dụng Join để tạo chuỗi tên người chơi
                                        sendData(msg2, _us._Socket);
                                    }
                                    break;
                                }
                            }

                            if (lstRoom.ListRoom[roomID].ListPlayer.Count == 0)
                            {
                                string msg = "#_TCP_ER" + roomID;
                                foreach (User _us in lstUser.ListPlayer)
                                {
                                    sendData(msg, _us._Socket);
                                }
                                Room room = lstRoom.ListRoom[roomID];
                                room.ResetRoom();   
                            }
                        }
                        if (receive.Substring(0, 8) == "#_TCP_US")
                        {
                            int roomID = int.Parse(receive[8].ToString());
                            int timelimit = int.Parse(receive[9].ToString());
                            int maxRound = int.Parse(receive[10].ToString());
                            switch (timelimit)
                            {
                                case 0:
                                    lstRoom.ListRoom[roomID].StoryTimeLimit = 10;
                                    break;
                                case 1:
                                    lstRoom.ListRoom[roomID].StoryTimeLimit = 15;
                                    break;
                                case 2:
                                    lstRoom.ListRoom[roomID].StoryTimeLimit = 30;
                                    break;
                                case 3:
                                    lstRoom.ListRoom[roomID].StoryTimeLimit = 60;
                                    break;
                                default:
                                    break;

                            }
                            
                            if (maxRound == 0)
                            {
                                lstRoom.ListRoom[roomID].MaxRounds = lstRoom.ListRoom[roomID].playerCount();
                            }

                            else if (maxRound == 1)
                            {
                                lstRoom.ListRoom[roomID].MaxRounds = lstRoom.ListRoom[roomID].playerCount() + 1;
                            }
                            else
                            {
                                switch (maxRound)
                                {
                                    case 2:
                                        lstRoom.ListRoom[roomID].MaxRounds = 4;
                                        break;
                                    case 3:
                                        lstRoom.ListRoom[roomID].MaxRounds = 5;
                                        break;
                                    case 4:
                                        lstRoom.ListRoom[roomID].MaxRounds = 6;
                                        break;
                                    case 5:
                                        lstRoom.ListRoom[roomID].MaxRounds = 7;
                                        break;
                                    case 6:
                                        lstRoom.ListRoom[roomID].MaxRounds = 8;
                                        break;
                                    case 7:
                                        lstRoom.ListRoom[roomID].MaxRounds = 9;
                                        break;
                                    case 8:
                                        lstRoom.ListRoom[roomID].MaxRounds = 10;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            updateUi(lstRoom.ListRoom[roomID].StoryTimeLimit + " " + lstRoom.ListRoom[roomID].MaxRounds);
                            for (int i = 0; i < lstRoom.ListRoom[roomID].playerCount(); i++)
                            {
                                sendData("#_TCP_US" + receive[8].ToString() + receive[9].ToString() + receive[10].ToString(), lstRoom.ListRoom[roomID].ListPlayer[i]._Socket);
                            }
                            updateUi("Room" + receive[8].ToString() + ": Changed Settings.");
                        }


                        // Khi nhận thông điệp bắt đầu trò chơi
                        if (receive.Substring(0, 8) == "#_TCP_ST")
                        {
                            int roomIndex = int.Parse(receive[8].ToString());
                            Room currentRoom = lstRoom.ListRoom[roomIndex];
                            updateUi($"Room {roomIndex + 1} started.");
                            // Khởi động trò chơi và Timer nếu chưa có trong roomTimers
                            if (!roomTimers.ContainsKey(roomIndex))
                            {
                                currentRoom.StartGame(); // Bắt đầu trò chơi

                                // Gửi thông báo bắt đầu đến tất cả người chơi trong phòng
                                foreach (User player in currentRoom.ListPlayer)
                                {
                                    sendData($"#_TCP_ST{roomIndex}" + currentRoom.StoryTimeLimit, player._Socket);
                                }

                                // Khởi tạo và bắt đầu Timer cho phòng (nếu chưa có)
                                var roomTimer = new System.Timers.Timer();
                                roomTimer.Interval = currentRoom.StoryTimeLimit * 1000; // Thời gian giới hạn (tính bằng mili giây)
                                roomTimer.Elapsed += (sender, e) => OnRoomTimerElapsed(sender, e, roomIndex); // Gọi hàm khi hết thời gian
                                roomTimers[roomIndex] = roomTimer;
                                roomTimer.Start(); // Bắt đầu Timer cho phòng
                            }
                        }
                        if (receive.Substring(0,8) == "#_TCP_SM")
                        {
                            lock (roomTimers)
                            {
                                string[] parts = receive.Split('|');

                                int roomId = int.Parse(parts[1]);
                                int currentRound = int.Parse(parts[2]);
                                string username = parts[3];
                                string sentence = parts[4];

                                Room currentRoom = lstRoom.ListRoom[roomId];
                                User player = currentRoom.ListPlayer.FirstOrDefault(user => user.UserName == username);
                                if (player != null)
                                {
                                    currentRoom.SubmitSentence(player, sentence);
                                }
                                updateUi(currentRoom.CurrentRound + " " + currentRoom.MaxRounds.ToString());
                            }
                        }
                           
                        if (receive.Substring(0, 9) == "#_TCP_DMK") //Change password
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
                    Array.Clear(buffReceive, 0, buffReceive.Length);
                    s.BeginReceive(buffReceive, 0, buffReceive.Length, SocketFlags.None, new AsyncCallback(beginReceive), s);
                }
            }
            catch { }
        }
        // Hàm xử lý khi hết thời gian của Timer cho phòng
        private void OnRoomTimerElapsed(object sender, ElapsedEventArgs e, int roomIndex)
        {

            Room currentRoom = lstRoom.ListRoom[roomIndex];
            if (roomTimers.ContainsKey(roomIndex))
            {
                System.Timers.Timer roomTimer = roomTimers[roomIndex];
                roomTimer.Stop(); // Dừng timer hiện tại
                                  // Gửi thông báo hết thời gian
                foreach (User player in currentRoom.ListPlayer)
                {
                    sendData($"#_TCP_TO{roomIndex}{currentRoom.CurrentRound}", player._Socket); // Thông báo thời gian hết
                }

                // Tạm dừng 5 giây
                Thread.Sleep(5000);
                
                // Thực hiện các hành động tiếp theo
                if (currentRoom.CurrentRound < currentRoom.MaxRounds)
                {
                    while (!currentRoom.IsRoundSubmitted) { Thread.Sleep(1); } // Vòng lặp tránh lỗi chưa đủ câu (index)
                    List<string> shownrotatedSentences = currentRoom.showRotateStories();

                    // Gửi câu đã rotate tới mỗi người chơi
                    for (int i = 0; i < currentRoom.playerCount(); i++)
                    {
                        User us = currentRoom.ListPlayer[i];
                        string rotatedSentence = shownrotatedSentences[i];
                        updateUi(rotatedSentence);
                        sendData($"#_TCP_NT{currentRoom.CurrentRound}{rotatedSentence}", us._Socket);
                    }
                  
                    roomTimer.Interval = currentRoom.StoryTimeLimit * 1000; // Thiết lập lại thời gian
                    roomTimer.Start(); // Bắt đầu lại Timer
                    currentRoom.StartNextRound(); // Tiến hành vòng mới
                }
                else
                {
                    // Kết thúc trò chơi nếu đã đạt đến giới hạn số vòng
                    currentRoom.EndGame();
                    string completeStories = currentRoom.GetCompleteStories();
                    updateUi($"Room {roomIndex + 1} ended round.");

                    // Gửi thông điệp kết thúc trò chơi với danh sách câu chuyện cho tất cả người chơi
                    foreach (User us in currentRoom.ListPlayer)
                    {
                        sendData($"#_TCP_END{roomIndex}|{completeStories}", us._Socket);
                    }

                    // Dừng và hủy bỏ timer sau khi kết thúc trò chơi
                    if (roomTimer != null)
                    {
                        roomTimer.Stop(); // Dừng timer
                        roomTimer.Dispose(); // Giải phóng tài nguyên
                    }
                }

            }
 
        }

        // Hàm xử lý khi chủ phòng rời đi
        private void HandleMasterExit(Socket masterSocket, int roomNumber)
        {
            // Lấy phòng mà chủ phòng hiện tại đang ở
            var room = lstRoom.ListRoom[roomNumber - 1];
            User exitingMaster = room.ListPlayer.FirstOrDefault(u => u._Socket == masterSocket);

            // Nếu tìm thấy chủ phòng hiện tại, hủy quyền chủ phòng của người này
            if (exitingMaster != null)
            {
                exitingMaster.IsMaster = false;

                // Tìm người chơi khác trong cùng phòng và gán quyền chủ phòng
                User newMaster = room.ListPlayer.FirstOrDefault(u => u != exitingMaster);

                if (newMaster != null)
                {
                    newMaster.IsMaster = true;
                    sendData($"#_TCP_BM", newMaster._Socket);
                    foreach (User u in room.ListPlayer)
                        sendData($"#_TCP_NM{newMaster.UserName}", u._Socket);
                    updateUi($"{newMaster.UserName} là quản trò mới của phòng {roomNumber}.");
                }
            }
        }

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
        private bool ValidateHMAC(string clientHMAC, string apiKey, string secret)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(apiKey));
                string expectedHMAC = Convert.ToBase64String(hash);
                return clientHMAC == expectedHMAC;
            }
        }
        private void Check_SignIn(string str, Socket sk)
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

            if (checkStt == false)
            {
                XmlDocument docXML = new XmlDocument();
                docXML.Load("ACCOUNT.xml");

                XmlNode user = docXML.SelectSingleNode("//account");
                XmlNodeList userList = user.SelectNodes("//user");

                foreach (XmlNode node in userList)
                {
                    if (node.Attributes != null)
                    {
                        if (node.Attributes["id"].Value == user_client)
                        {
                            if (node.InnerText == pass_client)
                            {
                                updateUi(user_client + " đã online");
                                User us = new User(user_client, sk);
                                lstUser.addPlayer(us);
                                buffSend = new byte[1024];
                                buffSend = Encoding.UTF8.GetBytes("#_TCP_DNTC");
                                sk.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendText), sk);
                                Thread.Sleep(200);
                                string s = "#_TCP_UF";
                                for (int i = 0; i < 10; i++)
                                {
                                    s += "|" + lstRoom.ListRoom[i].playerCount().ToString();
                                }
                                sendData(s, sk);
                                addListView(us);
                                checkLogIn = true;
                                break;
                            }
                        }
                    }
                }
                if (checkLogIn == false)
                {
                    buffSend = new byte[1024];
                    buffSend = Encoding.UTF8.GetBytes("#_TCP_DNTB");
                    sk.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendText), sk);
                }
            }
            else
            {
                buffSend = new byte[1024];
                buffSend = Encoding.UTF8.GetBytes("#_TCP_DNTT");
                sk.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendText), sk);
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
        private void CloseServer()
        {
            if (!isServerRunning) return; // Nếu server chưa chạy, không làm gì

            try
            {
                // Ngừng chấp nhận kết nối mới
                if (server != null)
                {
                    server.Close();
                    server = null;
                    updateUi("Server đã được đóng.");
                }

                // Đóng các kết nối client đang hoạt động
                foreach (var clientSocket in Client)
                {
                    if (clientSocket != null && clientSocket.Connected)
                    {
                        try
                        {
                            clientSocket.Close();
                        }
                        catch (Exception ex)
                        {
                            // Ghi lại thông báo lỗi (có thể hiển thị cho người dùng nếu cần)
                            MessageBox.Show("Lỗi khi đóng kết nối client: " + ex.Message);
                        }
                    }
                }

                // Xóa danh sách client
                Client.Clear();
            }
            catch (Exception ex)
            {
                // Ghi lại thông báo lỗi khi đóng server
                Console.WriteLine("Lỗi khi đóng server: " + ex.Message);
            }
        }

        private void btnCloseServer_Click(object sender, EventArgs e)
        {
            lstAccount.Items.Clear();
            CloseServer();
            timer2.Stop();
        }

        private void btnSendMsgfromServer_Click(object sender, EventArgs e)
        {
            if (lblReceiver.Text != "Chọn 1 Tài khoản Online")
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
            Thread threadRun = new(
                timTimeOut
                );
            threadRun.Start();
        }
        private void timTimeOut()
        {
            try
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
            catch { }
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


        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseServer();
        }

    }
}
