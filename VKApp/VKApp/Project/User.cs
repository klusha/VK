using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace VKApp.Project
{
    [XmlRoot("VkWeb.Project.User")]
    [Serializable]
    public class User
    {
        [XmlElement("vk_id")]
        public String vk_id { set; get; }
        [XmlElement("token")]
        public String token { set; get; }
    }
}