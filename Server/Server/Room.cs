using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmServer
{
    internal class Room
    {
        int giaTriXNTruoc;

        public int GiaTriXNTruoc
        {
            get { return giaTriXNTruoc; }
            set { giaTriXNTruoc = value; }
        }
        List<User> listPlayer = new List<User>();

        public List<User> ListPlayer
        {
            get { return listPlayer; }
            set { listPlayer = value; }
        }
        int roomNumber;
        public Room(int ma)
        {
            this.roomNumber = ma;
            this.giaTriXNTruoc = 0;
        }
        public bool addPlayer(User us)
        {
            if (listPlayer.Count <= 2)
            {
                listPlayer.Add(us);
                return true;
            }
            return false;
        }
        public int playerCount()
        {
            return listPlayer.Count();
        }
    }
}
