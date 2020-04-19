using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperVolt_Web_App.Models.WS
{
    public class Reply
    {
        public int result { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}