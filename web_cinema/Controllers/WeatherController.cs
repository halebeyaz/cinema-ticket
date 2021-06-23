using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_cinema.Models;

namespace web_cinema.Controllers
{
    public class WeatherController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WeatherorNot()
        {
            return View();
        }

        public JsonResult GetWeather()
        {
            Weather weather = new Weather();

            return Json(weather.getWeatherForcast(), JsonRequestBehavior.AllowGet);
        }
    }
}