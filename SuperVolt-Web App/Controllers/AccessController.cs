using SuperVolt_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SuperVolt_Web_App.Business;
using SuperVolt_Web_App.Models.WS;
using SuperVolt_Web_App.Utils;
using Newtonsoft.Json;

namespace SuperVolt_Web_App.Controllers
{
    public class AccessController : BaseController
    {
        static HttpClient client = new HttpClient();

        [HttpGet]
        public ActionResult Index()
        {
            this.GetSession();

            List<ListContadoresResponse> list = new List<ListContadoresResponse>();
            SecurityRequest oSecurityRequest = new SecurityRequest();
            oSecurityRequest.Token = oUserSession.accessToken;

            RequestUtil oRequestUtil = new RequestUtil();
            Reply oR = oRequestUtil.Execute<SecurityRequest>(Constants.Url.CONTADORES, "post", oSecurityRequest);

            list = JsonConvert.DeserializeObject<List<ListContadoresResponse>>(JsonConvert.SerializeObject(oR.data));


            return View(list);
        }

        public ActionResult Logout()
        {
            Session.Remove("User");
            return RedirectToAction("login","Home");
        }

        public ActionResult Autherize()
        {
            return View();
        }
    }
}
