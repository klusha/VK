using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Server.Api
{
    public class VKClient : IApi
    {
        private HTTPMaster httpMaster = new HTTPMaster();
        private JSONMaster jsonMaster = new JSONMaster();
       
        public List<String> FriendsList(String vkIdUser)
        {
            List<String> ListFriends = new List<String>();
            StringBuilder param = new StringBuilder("user_id=");
            param.Append(vkIdUser);
            String json = httpMaster.PageData("friends.get", param.ToString());
            ListFriends = jsonMaster.GetFriendsListOfJSON(json);
            return ListFriends;
        }
    }
}
