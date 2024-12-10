using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace frmServer
{
    internal class User
    {
        //Tên người chơi
        string userName;
        // Danh sách các câu viết của user trong câu chuyện
        public List<string> Story { get; set; } = new List<string>();
        // Trạng thái kiểm tra xem user đã submit câu trong vòng hiện tại hay chưa
        public bool HasSubmitted { get; set; } = false;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        Socket socket;

        public Socket _Socket
        {
            get { return socket; }
            set { socket = value; }
        }
        bool inRoom; // trạng thái ở ngoài phòng hay trong phòng, false: ngoài, true: trong

        public bool InRoom
        {
            get { return inRoom; }
            set { inRoom = value; }
        }
        bool isMaster; // trạng thái chủ phòng
        public bool IsMaster
        {
            get { return isMaster; }
            set { isMaster = value; }
        }

        int roomNumber; // mã số phòng
        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        bool statusConnect; // trạng thái kết nối

        public bool StatusConnect
        {
            get { return statusConnect; }
            set { statusConnect = value; }
        }

        public User(string us, Socket s)
        {
            this.userName = us;
            this.socket = s;
            this.inRoom = false;
            this.roomNumber = 0;
            this.statusConnect = true;
            this.isMaster = false;
        }
    }
}
