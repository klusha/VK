using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace VK
{
    class JSONMaster
    {
        private static JObject jsonObj = new JObject();

        public static String GetID_Of_JSON(String html)
        {
            String id = "";
            jsonObj = JObject.Parse(html);
            foreach (var result in jsonObj["response"])
            {
                id = (String)result["uid"];
            }
            return id;
        }

        public static List<String> GetFriendsList_Of_JSON(String html)
        {
            List<String> ListFR = new List<String>();
            jsonObj = JObject.Parse(html);
            foreach (var result in jsonObj["response"])
            {
                ListFR.Add(result.ToString());
            }
            return ListFR;
        }
        
        public static List<String> GetGroupsList_Of_JSON(String html)
        {
            List<String> ListGR = new List<String>();
            jsonObj = JObject.Parse(html);
            try
            {
                foreach (var result in jsonObj["response"].Last)
                {
                    for (int i = 0; i < result.Count(); i++)
                    {
                        ListGR.Add(result.ElementAt(i).ToString());
                    }
                }
            }
            catch (NullReferenceException ex) { // обработка того что у пользователя нет групп или они скрыты 
            }
            return ListGR;
        }


        public static String GetNameGroup_Of_JSON(String html)
        {
            String nameGroup = "";
            jsonObj = JObject.Parse(html);
            foreach (var result in jsonObj["response"])
            {
                nameGroup = (String)result["name"];
            }
            return nameGroup;
        }


    }
}
