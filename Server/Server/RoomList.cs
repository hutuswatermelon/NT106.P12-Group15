using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmServer
{
    internal class RoomList
    {
        List<Room> listRoom = new List<Room>();

        public List<Room> ListRoom
        {
            get { return listRoom; }
            set { listRoom = value; }
        }

        public RoomList()
        {
            for (int i = 0; i < 10; i++)
            {
                Room r = new Room(i);
                listRoom.Add(r);
            }
        }
    }
}
