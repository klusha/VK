using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using CreateUser.Mappers;

namespace CreateUser.Api
{
    public class VKClient : IApi
    {
        private HTTPMaster httpMaster = new HTTPMaster();
        private JSONMaster jsonMaster = new JSONMaster();
        private String TOKEN = "";
        private String IDUSER = "";
        public String IDUser(String url)
        {
            String str1 = "";
            String str2 = "";
            for (int i = url.Length; i > 0; i--)
            {
                if (url[i - 1] != '/')
                {
                    str1 += url[i - 1];
                }
                else break;
            }
            for (int j = str1.Length; j > 0; j--)
            {
                str2 = str2 + str1[j - 1];
            }
            return str2;
        }

        public String GetId(String url)
        {
            String id = "";
            StringBuilder param = new StringBuilder("uids=");
            param.Append(IDUser(url));
            String json = httpMaster.PageData("getProfiles", param.ToString());
            id = jsonMaster.GetIDofJSON(json);
            this.IDUSER = id;
            return id;
        }

        public List<String> GetName(String url)
        {
            String id = GetId(url);
            List<String> name = new List<String>();
            StringBuilder param = new StringBuilder("user_ids=");
            param.Append(id);
            param.Append("&fields=first_name,last_name");
            String json = httpMaster.PageData("users.get", param.ToString());
            name = jsonMaster.GetNameOfJSON(json);
            return name;
        }

        public List<String> FriendsList(String id)
        {
            List<String> ListFriends = new List<String>();
            StringBuilder param = new StringBuilder("user_id=");
            param.Append(id);
            String json = httpMaster.PageData("friends.get", param.ToString());
            ListFriends = jsonMaster.GetFriendsListOfJSON(json);
            return ListFriends;
        }

        private void getTokenUser()
        {
            TokenMapper tokenMappers = new TokenMapper();
            this.TOKEN = tokenMappers.FindByUserID(this.IDUSER);
        }

        public List<String> GroupsList(String id)
        {
            List<String> ListGroups = new List<String>();
            StringBuilder param = new StringBuilder("user_id=");
            param.Append(id);
            getTokenUser();
            String token = @"&access_token=" + this.TOKEN;
            String json = httpMaster.PageData("groups.get", param.ToString() + token + "&v=5.37");
            ListGroups = jsonMaster.GetGroupsListOfJSON(json);
            return ListGroups;
        }

        public Dictionary<String, List<String>> GroupsOfFriends(List<String> ListFriends)
        {
            Dictionary<String, List<String>> ListGroups = new Dictionary<String, List<String>>();
            for (int i = 0; i < ListFriends.Count(); i++)
            {
                Thread.Sleep(300);
                ListGroups[ListFriends[i]] = GroupsList(ListFriends[i]);
                Console.Write(".");
            }
            Console.WriteLine();
            return ListGroups;
        }
    }
}
