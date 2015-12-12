using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK.Api
{
    public interface IApi
    {
        String IDUser(String url);

        String GetId(String url);

        List<String> GetName(String url);

        List<String> FriendsList(String id);

        List<String> GroupsList(String id);

        Dictionary<String, List<String>> GroupsOfFriends(List<String> ListFriends);

        void Top(String url, int quantity);
    }
}
