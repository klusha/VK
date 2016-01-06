using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace VKApp.Project
{
    public class HttpMaster
    {
        public String PageData(String apiMetod, String param)
        {
            StringBuilder urlStr = new StringBuilder("https://api.vkontakte.ru/method/");
            urlStr.Append(apiMetod).Append("?").Append(param);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            String result = client.DownloadString(urlStr.ToString()).ToString();
            return result;
        }
    }
}