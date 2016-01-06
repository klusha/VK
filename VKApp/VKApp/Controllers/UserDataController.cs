using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using VKApp.Models;
using VKApp.Project;

using System.IO;
using System.Xml;
using System.Text;

namespace VKApp.Controllers
{
    public class UserDataController : Controller
    {
        public TopMadel top = null;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserDataModel model)
        {
            if (model.ComplianceTest())
            {                      
                ViewBag.URL = model.URL;
                ViewBag.date = model.date.ToString("dd.MM.yyyy");
                ViewBag.quantity = model.quantity;
                ViewBag.userData = model;                
            }
            else
            {
                ViewBag.URL = " ";
            }
            return View();
        }

        public RedirectResult CreateUser(String user_id, String token)
        {
            Producer producer = new Producer();
            User user = new User();
            user.vk_id = user_id;
            user.token = token;

            System.Xml.Serialization.XmlSerializer serializer = 
                new System.Xml.Serialization.XmlSerializer(typeof(User));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false); 
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (StringWriter textWriter = new StringWriter()) 
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings)) 
                {
                    serializer.Serialize(xmlWriter, user);
                }
                producer.SendMessage(textWriter.ToString(), "ToCreate");
            }
            return Redirect("http://localhost:61745/UserData");
        }
    }
}
