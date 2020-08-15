using MaskMap.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MaskMap.Service
{
    public class MaskService
    {
        public FeatureCollection useHttpWebRequest_Get()
        {
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
                        FeatureCollection col = JsonConvert.DeserializeObject<FeatureCollection>(temp);
                        return col;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
