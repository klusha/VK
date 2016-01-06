using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using xNet;

using System.Web;
using System.Web.Mvc;

namespace VKApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public RedirectResult RedirectToAuth()
        {
            return Redirect("http://localhost:61745/Auth/Index");
        }

        [AllowAnonymous]
        public RedirectResult RedirectToUserData()
        {
            return Redirect("http://localhost:61745/UserData");
        }
    }
}
