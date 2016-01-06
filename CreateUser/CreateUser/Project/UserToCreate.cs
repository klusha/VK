using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xstream.Core;

namespace CreateUser.Project
{
    [XmlRoot("VkWeb.Project.User")]
    [Serializable()]
    public class UserToCreate
    {
        [XmlElement("vk_id")]
        public String vk_id { set; get; }
        [XmlElement("token")]
        public String token { set; get; }
    }
}
