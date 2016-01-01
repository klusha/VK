using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top.Entity
{
    public class ListFriends : EntityFriends
    {
        public int IdUser;

        public ListFriends(int IdUser, int IdFriend)
        {
            this.IdUser = IdUser;
            this.SetIdFriend(IdFriend);
        }

        public ListFriends(int ID, int IdUser, int IdFriend)
        {
            this.SetId(ID);
            this.IdUser = IdUser;
            this.SetIdFriend(IdFriend);
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
