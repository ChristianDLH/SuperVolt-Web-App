using SuperVolt_Web_App.Models;
using SuperVolt_Web_App.Models.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SuperVolt_Web_App.Api
{
    public class Api_contadores : Controller
    {
        static HttpClient client = new HttpClient();

        public Api_contadores()
        {

        }

        public async Task<Reply> getContadores()
        {
            object token = Session["access_token"];
            Reply oR = null;

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44375/api/access", token);
                oR = await response.Content.ReadAsAsync<Reply>();
                
                string resultado = oR.result.ToString();


            }
            catch (Exception)
            {

            }
            return oR;
        }
        
    }
}