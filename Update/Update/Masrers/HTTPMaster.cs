using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;

namespace Update
{
    public class HTTPMaster
    {
        public String PageData(String apiMetod, String param)
        {
            StringBuilder urlStr = new StringBuilder("https://api.vkontakte.ru/method/");
            urlStr.Append(apiMetod).Append("?").Append(param);
            String result = "";
            WebClient client = new WebClient();
            try
            {
                client.Encoding = System.Text.Encoding.UTF8;
                result = client.DownloadString(urlStr.ToString()).ToString();                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
