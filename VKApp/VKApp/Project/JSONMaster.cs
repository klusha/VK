using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VKApp.Project
{
    public class JSONMaster
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

        public List<String> GetListTop(Dictionary<int, int> dictionaryTops)
        {
            List<String> Tops = new List<String>();
            String html = "";
            JObject jsonObj = new JObject();
            HttpMaster httpMaster = new HttpMaster();
            DBMaster dbMaster = new DBMaster();
            foreach (var elementTop in dictionaryTops)
            {
                String vk_id = dbMaster.FindByIdGroup(elementTop.Key);
                html = httpMaster.PageData("groups.getById", "group_id=" + vk_id);
                jsonObj = JObject.Parse(html);
                foreach (var result in jsonObj["response"])
                {
                    Tops.Add((String)result["name"]);
                }
            }
            return Tops;
        }

        public List<String> GetAccessToken(String response)
        {
            List<String> info = new List<String>();
            JObject jsonObj = new JObject();
            jsonObj = JObject.Parse(response);
            info.Add(jsonObj["access_token"].ToString());
            info.Add(jsonObj["user_id"].ToString());
            return info;
        }
    }
}