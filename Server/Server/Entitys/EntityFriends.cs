using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Entity
{
    public class EntityFriends : Entity
    {
        protected String vkIdFriend;
        public void SetVkIdFriend(String vkIdFriend)
        {
            this.vkIdFriend = vkIdFriend;
        }
        public String GetVkIdFriend()
        {
            return this.vkIdFriend;
        }
    }
}
