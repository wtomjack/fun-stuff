using System;
using System.Collections.Generic;
using System.Linq;

using Project.Models;
using Project.Models.Weather;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Project.Mapper
{
    public static class Mapper
    {
        public static void MenuMapper(List<SubItem> subItems, List<MenuItem> menuItems)
        {
            foreach (var item in menuItems){
                item.SubItem.AddRange(subItems.Where(sub => sub.SubItemKey == item.Id));
            }
        }

        public static string NewsMapper(string json)
        {
            var news = "";
            JObject o = JObject.Parse(json);
            var x = o.GetValue("results");
            var objs = ((JArray)JsonConvert.DeserializeObject(x.ToString()));
            foreach (var y in objs)
            { // if 'obj' is a JObject
                news = news + y["title"] + ".   --";
                news.PadRight(30);
            }
            return news;

        }

        public static WeatherObject WeatherMapper(string json)
        {
            var weather = new WeatherObject();
            JObject o = JObject.Parse(json);
            var coordinates = o.GetValue("coord");
            var temperature = o.GetValue("main");
            var x = o.GetValue("weather");
            weather.Coordinates = new Coordinates
            {
                Latitude = (string)coordinates["lat"],
                Longitude = (string)coordinates["lon"]
            };

            weather.Temperature = new Temperature
            {
                CurrentTemp = (double)temperature?["temp"],
                FeelsLikeTemp = (double)temperature?["feels_like"],
                Max = (double)temperature?["temp_max"],
                Minimum = (double)temperature?["temp_min"],
                Humidity = (double)temperature?["humidity"]
            };

            weather.MainWeather = (string)x?[0]["main"];
            weather.Description = (string)x?[0]["description"];

            return weather;
        }       
    }
}