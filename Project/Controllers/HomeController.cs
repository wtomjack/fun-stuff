using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Project.Builders;
using Project.Services;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var homeBuilder = new HomeBuilder();
            var model = homeBuilder.Build();

            //var ss = new WeatherService();
            //ss.GetInitialWeather("");

            return this.View(model);
        }
    }
}