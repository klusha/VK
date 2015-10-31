using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

using VK;
using VK.Entity;
using VK.Mappers;
using VK.Masters; 

namespace VK
{
    class VKProg
    {
        static void Main(string[] args)
        {
            InternetToDataBase idb = new InternetToDataBase("https://vk.com/id25293291");
            idb.InsertToGroup();
            Console.ReadKey();
        }
    }
}
