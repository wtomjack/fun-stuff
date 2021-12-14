using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Weather
{
    public class Coordinates
    {
        [JsonProperty("lon")]
        public string Longitude { get; set; }

        [JsonProperty("lat")]
        public string Latitude { get; set; }
    }
}
