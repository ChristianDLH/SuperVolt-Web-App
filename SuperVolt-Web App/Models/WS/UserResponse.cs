using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperVolt_Web_App.Models.WS
{
    public class UserResponse
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string accessToken { get; set; }
    }
}