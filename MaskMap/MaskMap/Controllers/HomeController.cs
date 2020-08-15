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
            return View();
        }

        [HttpPost]
        public ActionResult GetPharmacy()
        {
            MaskService service = new MaskService();
            FeatureCollection col = service.useHttpWebRequest_Get();
            List<pharmacy> pharmacy = new List<pharmacy>();

            for (int i = 0; i < col.features.Count(); i++)
            {
                pharmacy.Add(new pharmacy()
                {
                    name = col.features[i].properties.name,
                    las = col.features[i].geometry.coordinates[0],
                    lng = col.features[i].geometry.coordinates[1]
                });
            }

            return Json(pharmacy);
        }
    }
}
