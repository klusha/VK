﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top.Entity
{
    public class EntityFriends : Entity
    {
        protected int IdFriend;
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
