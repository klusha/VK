using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace VKApp.Project
{
    public class vkClient
    {
        private HttpMaster httpMaster = new HttpMaster();
        private JSONMaster jsonMaster = new JSONMaster();
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

        public string IDUSER { get; set; }
    }
}