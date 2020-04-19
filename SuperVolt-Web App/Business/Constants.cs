using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SuperVolt_Web_App.Business
{
    public class Constants
    {
        public static string URL_API
        {
            get
            {
                return ConfigurationManager.AppSettings["url_ws"];
            }
        }

        public class Url {
            public static string LOGIN => URL_API + "/api/access/login";
            public static string CONTADORES => URL_API + "/api/contadores/contadores";

        }

    }
}