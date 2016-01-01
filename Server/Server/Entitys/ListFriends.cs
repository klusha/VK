using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Entity
{
    public class ListFriends : EntityFriends
    {
        public int IdUser;

        public ListFriends(int IdUser, String vkIdFriend)
        {
            this.IdUser = IdUser;
            this.SetVkIdFriend(vkIdFriend);
        }

        public ListFriends(int ID, int IdUser, String vkIdFriend)
        {
            this.SetId(ID);
            this.IdUser = IdUser;
            this.SetVkIdFriend(vkIdFriend);
        }

        public void SetIdUser(int vkIdUser)
        {
            this.IdUser = vkIdUser;
        }

        public int GetIdUser()
        {
            return this.IdUser;
        }
    }
}
