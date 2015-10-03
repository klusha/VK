using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;

namespace VK
{
    public class HTTPMaster
    {
        public static String PageData(String apiMetod, String param)
        {
            StringBuilder urlStr = new StringBuilder("https://api.vkontakte.ru/method/");
            urlStr.Append(apiMetod).Append("?").Append(param);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlStr.ToString());
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            return reader.ReadToEnd();
        }
    }
}
