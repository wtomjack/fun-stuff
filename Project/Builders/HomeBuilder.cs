using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Builders
{
    using Project.Services;

    public class HomeBuilder
    {
        public Home Build()
        {
            var weatherService = new WeatherService();
            var weather = weatherService.GetInitialWeather("22201");

            var homeModel = new Home { Weather = weather.Result };
            this.AddImageIconPath(homeModel.Weather);
            this.SetHourly(homeModel.Weather);
            return homeModel;
        }

        public void SetHourly(Weather weather)
        {
            foreach (var item in weather.Hours)
            {
                item.Hour = item.DateTime.ToString("h tt");
            }
        }

        public void AddImageIconPath(Weather weather)
        {
            foreach (var item in weather.Hours)
            {
                if (item.WeatherIcon < 6)
                {
                    item.IconImage = "Resources/WeatherComponent/WeatherIcons/Sun.png";
                }
                else if (item.WeatherIcon < 12)
                {
                    item.IconImage = "Resources/WeatherComponent/WeatherIcons/Cloudy.png";
                }
                else if (item.WeatherIcon < 19)
                {
                    item.IconImage = "Resources/WeatherComponent/WeatherIcons/Rain.png";
                }
                else if (item.WeatherIcon < 29)
                {
                    item.IconImage = "Resources/WeatherComponent/WeatherIcons/Snow.png";
                }
                else
                {
                    item.IconImage = "Resources/WeatherComponent/WeatherIcons/Night.png";
                }
            }
        }
    }
}