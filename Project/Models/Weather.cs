using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Weather
    {
        private List<WeatherHour> _hours; 
        public List<WeatherHour> Hours {
            get
            {
                return this._hours ?? (this._hours = new List<WeatherHour>());
            }
            set
            {
                this._hours = value;
            }
        }
    }

    public class WeatherHour
    {
        public DateTime DateTime { get; set; }

        public string Hour { get; set; }

        public string EpochDateTime { get; set; }

        public int WeatherIcon { get; set; }

        public string IconImage { get; set; }

        public string IconPhrase { get; set; }

        public bool HasPrecipitation { get; set; }

        public bool IsDaylight { get; set; }

        public Temperature Temperature { get; set; }

        public int PrecipitationProbability { get; set; }

        public string MobileLink { get; set; }

        public string Link { get; set; }
    }

    public class Temperature
    {
        public double Value { get; set; }

        public string Unit { get; set; }

        public int UnitType { get; set; }
    }
}