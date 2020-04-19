using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperVolt_Web_App.Models.Request
{
    public class User
    {
        public string mail { get; set; }
        public string password { get; set; }
    }
}