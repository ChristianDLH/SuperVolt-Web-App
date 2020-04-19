using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperVolt_Web_App.Models.WS
{
    public class ListContadoresResponse
    {
        public int IdContador { get; set; }
        public string TipoContador { get; set; }
        public string PropietarioContador { get; set; }
        public string DireccionContador { get; set; }
        public string Observaciones { get; set; }
        public bool Estado { get; set; }
    }
}