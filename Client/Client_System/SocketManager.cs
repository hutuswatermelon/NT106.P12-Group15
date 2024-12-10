using System.Net.Sockets;
using System.Net;
using System.Text;
using Client_System;
using Microsoft.VisualBasic.Logging;

public class SocketClientSingleton
{
    private static SocketClientSingleton instance;
    public Socket Client { get; private set; }
    private byte[] buffSend = new byte[1024];
    private byte[] buffReceive = new byte[1024];
    public event Action<string> DataReceived;
    public int[,] playerOfRoom = {
    {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}, // ID phòng
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // Số người chơi hiện tại trong phòng
    {2, 2, 2, 2, 2, 2, 2, 2, 2, 2},  // Số người chơi tối đa của mỗi phòng
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //Trạng thái: 0 chưa bắt đầu, 1 đã bắt đầu
    };

    public Label[] Infor = new Label[10];
    public event Action<ServerCommand, string> CommandReceived;
    public event Action<string> MasterChanged;
    string Username = "";
    public bool inRoom = false;
    //public event Action InitializationCompleted;
    public int roomNumber = 0;
    private SocketClientSingleton()
    {
        Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public static SocketClientSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SocketClientSingleton();
            }
            return instance;
        }
    }
    public event Action ConnectionSuccessful;
    public event Action<int, int> PlayerCountChanged;
    public bool ConnectSuccess = false;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Timer timer2;
    public void BeginConnect(string ipAddress, int port, AsyncCallback callback)
    {
        if (!Client.Connected)
        {
            EndPoint ipep = new IPEndPoint(IPAddress.Parse(ipAddress.ToString()), Convert.ToInt32(port.ToString()));

            Client.BeginConnect(ipep, new AsyncCallback(beginConnect), Client);
        }
    }
    public void beginConnect(IAsyncResult ar)
    {
        try
        {
            Client.EndConnect(ar);
            string welcome = "Hello Server";
            buffSend = Encoding.UTF8.GetBytes(welcome);

            // Gửi dữ liệu chào mừng tới server
            Client.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendData), Client);

            // Bắt đầu nhận dữ liệu từ server ngay sau khi kết nối thành công
            BeginReceive(); // Gọi trực tiếp để nhận dữ liệu thay vì để frmStart.cs gọi.

            // Thông báo kết nối thành công
            MessageBox.Show("Kết nối thành công đến máy chủ.");
            ConnectSuccess = true;
            ConnectionSuccessful?.Invoke();
        }
        catch (SocketException)
        {
            MessageBox.Show("Kết nối đến Server không thành công");
        }
    }
    private void sendData(IAsyncResult ai)
    {
        Client.EndSend(ai);
    }

    public void SendData(string data)
    {
        buffSend = Encoding.UTF8.GetBytes(data);
        Client.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, new AsyncCallback(sendData), Client);
        //updateUi("_Client: " + txtSend.Text);
    }
    public void BeginSend(string message, AsyncCallback callback)
    {
        buffSend = Encoding.UTF8.GetBytes(message);
        Client.BeginSend(buffSend, 0, buffSend.Length, SocketFlags.None, callback, Client);
    }

    public void BeginReceive(AsyncCallback callback)
    {
        Client.BeginReceive(buffReceive, 0, buffReceive.Length, SocketFlags.None, callback, Client);
    }
    public void BeginReceive()
    {
        Client.BeginReceive(buffReceive, 0, buffReceive.Length, SocketFlags.None, new AsyncCallback(OnReceiveData), Client);
    }
    private void OnReceiveData(IAsyncResult iar)
    {
        try
        {
            Socket s = (Socket)iar.AsyncState;
            int bytesReceived = Client.EndReceive(iar);
            string receivedData = Encoding.UTF8.GetString(buffReceive, 0, bytesReceived);

            var command = ParseCommand(receivedData);
            CommandReceived?.Invoke(command, receivedData);
            // Tiếp tục lắng nghe dữ liệu từ server
            BeginReceive();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in receiving data: " + ex.Message);
        }
    }
    public void SetUserName(string username)
    {
        Username = username;
    }
    public string GetUserName()
    {
        return Username;
    }
    private ServerCommand ParseCommand(string data)
    {
        //
        if (data.Length >= 10 && data.Substring(0, 10) == "#_TCP_DNTB") return ServerCommand.SignInFailed;

        else if (data.Length >= 8 && data.Substring(0, 8) == "#_TCP_TO") return ServerCommand.TimeOut;
        else if (data.Length >= 8 && data.Substring(0, 8) == "#_TCP_NT")
        {
            //MessageBox.Show(data);
            return ServerCommand.NextRound;
        }
        else if (data.Length >= 9 && data.Substring(0, 9) == "#_TCP_END") return ServerCommand.EndStory;
        
        else if (data.Length >= 8 && data.Substring(0, 8) == "#_TCP_UF")
        {
            string[] parts = data.Split('|');
            int[] num = new int[10];

            for (int i = 0; i < 10; i++)
            {
                num[i] = int.Parse(parts[i + 1]);
                playerOfRoom[1, i] = num[i];
            }
            return ServerCommand.UpdateLobbyforNewJoining;
        }
        else if (data.Length >= 9 && data.Substring(0, 9) == "#_Chat_00") return ServerCommand.ChatMessage;
        else if (data.Length >= 8 && data.Substring(0, 8) == "#_TCP_ST") return ServerCommand.StartRoom;
        else if (data.Length >= 8 && data.Substring(0, 8) == "#_TCP_BM") return ServerCommand.BecomeMaster;
        else if (data.Length >= 14 && data.Substring(0, 14) == "#_TCP_NM")
        {
            //
            return ServerCommand.NewMaster;
        }
        else if (data.Length >= 8 && data.Substring(0, 8) == "#_TCP_US")
        {
            Console.Write(data);
            return ServerCommand.UpdateSettings;
        }
        else if (data.Length >= 8 && data.Substring(0, 8) == "#_TCP_UL")
        {
            playerOfRoom[1, int.Parse(data[8].ToString())] = int.Parse(data[9].ToString());
            Infor[int.Parse(data[8].ToString())].Text = data[9].ToString();
            return ServerCommand.UpdateLobby;
        }
        else if (data.Length >= 8 && data.Substring(0, 8) == "#_TCP_MP")
        {
            int roomId = int.Parse(data.Substring(8, 1));  // X represents the room ID
            int newMaxPlayers = int.Parse(data.Substring(9, 1));  // Y represents the new maximum number of players

            // Update the maximum number of players for the specified room
            if (roomId >= 0 && roomId < playerOfRoom.GetLength(1))
            {
                playerOfRoom[2, roomId] = newMaxPlayers;
            }
            return ServerCommand.UpdateMaxPlayer;
        }
        else if (data.Length >= 8 && data.Substring(0, 8) == "#_TCP_UP")
        {
            return ServerCommand.UpdatePlayerinRoom;
        }
        else if (data.Length >= 9 && data.Substring(0, 8) == "#_TCP_ER") 
        {
            int roomID = int.Parse(data.Substring(8, 1));
            playerOfRoom[3, roomID] = 0;
            return ServerCommand.EndRoom;
        }
        else if (data.Length >= 10 && data.Substring(0, 10) == "#_TCP_DNTT") return ServerCommand.SIF_AccountUsing;
        else if (data.Length >= 10 && data.Substring(0, 10) == "#_TCP_DNTC") return ServerCommand.SignInSuccess;
        else if (data.Length >= 10 && data.Substring(0, 10) == "#_TCP_DKTB") return ServerCommand.SignUpFailed;
        else if (data.Length >= 10 && data.Substring(0, 10) == "#_TCP_DKTC") return ServerCommand.SignUpSuccess;
        else if (data.Length >= 10 && data.Substring(0, 10) == "#_TCP_DMKTC") return ServerCommand.ChangePasswordSuccess;

        return ServerCommand.Unknown;
    }

    public void EndSend(IAsyncResult ai)
    {
        Client.EndSend(ai);
    }

    public bool isConnected()
    {
        try
        {
            return !(Client.Poll(10, SelectMode.SelectRead) && Client.Available == 0);
        }
        catch (SocketException)
        {
            return false;
        }
    }

}