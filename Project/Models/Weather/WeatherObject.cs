using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Weather
{
    public class WeatherObject
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("main")]
        public string MainWeather { get; set; }

        [JsonProperty("main")]
        public Temperature Temperature { get; set; }

        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }

        public string imageIcon { get; set; }
    }
}
