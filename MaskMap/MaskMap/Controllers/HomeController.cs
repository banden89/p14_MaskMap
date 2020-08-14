using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaskMap.Models;
using MaskMap.Service;
using Newtonsoft.Json;

namespace MaskMap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://raw.githubusercontent.com/kiang/pharmacies/master/json/points.json");
            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "application/json";
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        var temp = reader.ReadToEnd();
                        FeatureCollection cart = JsonConvert.DeserializeObject<FeatureCollection>(temp);
                    }
                }
                else
                {
                    return null;
                }
            }




            return View();
        }
    }
}
