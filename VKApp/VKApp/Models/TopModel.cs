using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.IO;

using MySql.Data.MySqlClient;
using System.Text;
using Newtonsoft.Json.Linq;
using VKApp.Project;



namespace VKApp.Models
{
    public class TopMadel
    {
        public List<String> top { set; get; }

        public TopMadel(String date, int quantity, String URL)
        {
            vkClient vk = new vkClient();
            top = new List<String>();
            String vkID = vk.GetId(URL);
            DBMaster db = new DBMaster();
            int id = db.FindByIDUser(vkID);
            top = GetTopForDate(date, quantity, id);
        }

        public List<String> GetTopForDate(String date, int quantity, int idUser)
        {
            Dictionary<int, int> dictionaryTops = new Dictionary<int, int>();
            List<String> tops = new List<String>();
            DBMaster dbMaster = new DBMaster();
            JSONMaster JSON = new JSONMaster();
            dictionaryTops = dbMaster.FindByDate(date, quantity, idUser);
            tops = JSON.GetListTop(dictionaryTops);
            return tops;
        }
    }
}