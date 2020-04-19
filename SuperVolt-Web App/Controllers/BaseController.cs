using SuperVolt_Web_App.Models.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperVolt_Web_App.Controllers
{
    public class BaseController : Controller
    {
        public UserResponse oUserSession = new UserResponse();

        protected void GetSession()
        {
            oUserSession = (UserResponse)Session["User"];
        }
    }
}