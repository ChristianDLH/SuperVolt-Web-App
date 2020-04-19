using Newtonsoft.Json;
using SuperVolt_Web_App.Models.WS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace SuperVolt_Web_App.Utils
{
    public class RequestUtil
    {
        public Reply response { get; set; }

        public RequestUtil()
        {
            response = new Reply();
        }

        public Reply Execute<T>(string url, string method, T objectRequest)
        {
            response.result = 0;
            string result = "";

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = JsonConvert.SerializeObject(objectRequest);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.PreAuthenticate = false;
                request.Accept = "application/json";
                request.MediaType = "application/json";
                request.ContentType = "application/json; charset=utf-8";
                request.Timeout = 60000;


                using (var oStreamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    oStreamWriter.Write(json);
                    oStreamWriter.Flush();
                }

                HttpWebResponse oHttpResponse = (HttpWebResponse)request.GetResponse();

                using (var oStreamReader = new StreamReader(oHttpResponse.GetResponseStream()))
                {
                    result = oStreamReader.ReadToEnd();
                }

                response = JsonConvert.DeserializeObject<Reply>(result);
            }
            catch (TimeoutException)
            {
                response.message = "Tiempo de espera agotado";
            }
            catch (Exception e)
            {
                //response.message = "Ha ocurrido un error";
                response.message = e.ToString();

                throw;
            }

            return response;
        }
    }
}