using Newtonsoft.Json;
using SuperVolt_Web_App.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperVolt_Web_App.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("Index", "Access");
            }

            return View();
        }

        public ActionResult About()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("Index", "Access");
            }

            return View();
        }

        public ActionResult Contact()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("Index", "Access");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("Index", "Access");
            }

            Models.ViewModels.LoginViewModel model = new Models.ViewModels.LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(Models.ViewModels.LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Utils.EncryptUtil encrypt = new Utils.EncryptUtil();


            Models.Request.User oUser = new Models.Request.User();
            oUser.mail = model.mail;
            oUser.password = encrypt.GeneratePasswordHash(model.password);

            string en = encrypt.GeneratePasswordHash(model.password);

            Utils.RequestUtil oRequestUtil = new Utils.RequestUtil();
            Models.WS.Reply oR = oRequestUtil.Execute<Models.Request.User>(Constants.Url.LOGIN, "post", oUser);

            Models.WS.UserResponse oUserResponse = JsonConvert.DeserializeObject<Models.WS.UserResponse>(JsonConvert.SerializeObject(oR.data));

            if (oR.result == 1)
            {
                //Session["User"] = oR.data;
                Session["User"] = oUserResponse;

                return RedirectToAction("Index","Access");
            }


            ViewBag.Error = "Fallo de inicio de sesión: credenciales incorrectas";

            return View(model);
        }
    }
}