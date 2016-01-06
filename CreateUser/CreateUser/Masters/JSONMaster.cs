using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CreateUser
{
    class JSONMaster
    {
        private JObject jsonObj = new JObject();

        public String GetIDofJSON(String json)
        {
            String id = "";
            jsonObj = JObject.Parse(json);
            foreach (var result in jsonObj["response"])
            {
                id = (String)result["uid"];
            }
            return id;
        }

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

        public List<String> GetGroupsListOfJSON(String json)
        {
            List<String> ListGroups = new List<String>();
            jsonObj = JObject.Parse(json);
            try
            {
                foreach (var result in jsonObj["response"].Last)
                {
                    for (int i = 0; i < result.Count(); i++)
                    {
                        ListGroups.Add(result.ElementAt(i).ToString());
                    }
                }
            }
            catch (NullReferenceException ex)
            { // обработка того что у пользователя нет групп или они скрыты 
            }
            return ListGroups;
        }


        public String GetNameGroupOfJSON(String json)
        {
            String nameGroup = "";
            jsonObj = JObject.Parse(json);
            foreach (var result in jsonObj["response"])
            {
                nameGroup = (String)result["name"];
            }
            return nameGroup;
        }

        public List<String> GetNameOfJSON(String json)
        {
            List<String> name = new List<String>();
            jsonObj = JObject.Parse(json);
            foreach (var result in jsonObj["response"])
            {
                String last_name = (String)result["last_name"];
                String first_name = (String)result["first_name"];
                name.Add(last_name);
                name.Add(first_name);
            }
            return name;
        }
    }
}
