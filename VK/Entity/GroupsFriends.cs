using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK.Entity
{
    public class GroupsFriends : EntityFriends
    {
        public int IdGroup;

        public GroupsFriends(int IdFriend, int IdGroup)
        {
            this.SetIdFriend(IdFriend);
            this.SetIdGroup(IdGroup);
        }

        public GroupsFriends(int ID, int IdFriend, int IdGroup)
        {
            this.SetId(ID);
            this.SetIdFriend(IdFriend);
            this.SetIdGroup(IdGroup);
        }

        public int GetIdGroup()
        {
            return this.IdGroup;
        }
        public void SetIdGroup(int IdGroup)
        {
            this.IdGroup = IdGroup;
        }
    }
}
