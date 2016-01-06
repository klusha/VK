using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Server
{
    class JSONMaster
    {
        private JObject jsonObj = new JObject();

        public List<String> GetFriendsListOfJSON(String json)
        {
            List<String> ListFriends = new List<String>();
            jsonObj = JObject.Parse(json);
            foreach (var result in jsonObj["response"])
            {
                ListFriends.Add(result.ToString());
            }
            return ListFriends;
        }
    }
}
