using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using xNet;

using System.Web;
using System.Web.Mvc;
using VKApp.Models;
using VKApp.Project;

namespace VKApp.Controllers
{
    public class AuthController : Controller
    {
        private String AppID = "5099050";
        private String client_secret = "jykiEzsP5iai8bOUWYBJ";
        private String redirect_uri = "http://localhost:61745/Auth/GetToken";
        private String scope = "groups,offline";


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous] 
        public RedirectResult RedirectToVk() 
        {
            String uri = string.Format(
                        "https://oauth.vk.com/authorize?client_id={0}&redirect_uri={1}&display=page&scope={2}&v=5.42",
                        AppID,
                        redirect_uri,
                        scope);
            return Redirect(uri); 
        }

        [AllowAnonymous]
        public RedirectResult GetToken(string code)
        {
            List<String> userInfo = new List<String>();
            JSONMaster master = new JSONMaster();
            using (var request = new xNet.HttpRequest())
            {
                String uri = string.Format(
                        "https://oauth.vk.com/access_token?client_id={0}&client_secret={1}&redirect_uri={2}&code={3}",
                        AppID,
                        client_secret,
                        redirect_uri,
                        code);
                String data = request.Get(uri).ToString();
                userInfo.AddRange(master.GetAccessToken(data));
            }
            String url = string.Format("http://localhost:61745/UserData/CreateUser?user_id={0}&token={1}", 
                            userInfo.ElementAt(1),
                            userInfo.ElementAt(0));
            return Redirect(url);
        }

        public void Auth()
        {

        }
    }
}
