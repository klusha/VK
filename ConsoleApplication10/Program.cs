using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

using VK; 

namespace VK
{
    class VKProg
    {
        static void Main(string[] args)
        {
            VK.VKClient.Top("https://vk.com/id25293291", 8);
            Console.ReadKey();
        }
    }
}