using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models.Weather;
namespace Project.Models
{
    public class Home
    {
        public WeatherObject Weather { get; set; }

        public string News { get; set; }
    }
}