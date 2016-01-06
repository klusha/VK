using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web;
using System.Web.Mvc;
using VKApp.Models;

namespace VKApp.Controllers
{
    public class TopController : Controller
    {
        [HttpGet]
        public ActionResult Index(String date, int quantity, String URL)
        {
            TopMadel top = new TopMadel(date, quantity, URL);
            return View(top);
        }
    }
}
