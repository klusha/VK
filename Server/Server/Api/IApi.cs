﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Api
{
    public interface IApi
    {
        List<String> FriendsList(String id);
    }
}
