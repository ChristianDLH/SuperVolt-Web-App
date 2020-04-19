using SuperVolt_Web_App.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperVolt_Web_App.Filter
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                if(HttpContext.Current.Session["User"] == null)
                {
                    if(filterContext.Controller is HomeController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("home/login");
                    }
                }

                if (HttpContext.Current.Session["User"] != null)
                {
                    if (filterContext.Controller is HomeController == true)
                    {
                        filterContext.HttpContext.Response.Redirect("access/index");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}