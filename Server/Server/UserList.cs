using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmServer
{
    internal class UserList
    {
        List<User> listPlayer = new List<User>();

        public List<User> ListPlayer
        {
            get { return listPlayer; }
            set { listPlayer = value; }
        }

        public bool addPlayer(User us)
        {
            if (listPlayer.Count < 80)
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
