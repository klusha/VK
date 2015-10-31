using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK.Entity
{
    public class EntityFriends : Entity
    {
        public int IdFriend;
        public void SetIdFriend(int IdFriend)
        {
            this.IdFriend = IdFriend;
        }
        public int GetIdFriend()
        {
            return this.IdFriend;
        }
    }
}
