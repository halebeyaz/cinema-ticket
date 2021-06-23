using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace web_cinema.Models
{
    public class Weather
    {
        public Object getWeatherForcast()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Bilecik&appid=3d330370f99552daefa2796c3ded8768&units=imperial";
            var client = new WebClient();
            var content = client.DownloadString(url);
            var serializer = new JavaScriptSerializer();
            var jsoncontent = serializer.Deserialize<Object>(content);
            return jsoncontent;

        }
    }
}