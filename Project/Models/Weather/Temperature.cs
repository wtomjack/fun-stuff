using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Weather
{
    public class Temperature
    {
        public double CurrentTemp { get; set; }

        public double FeelsLikeTemp { get; set; }

        public double Minimum { get; set; }

        public double Max { get; set; }

        public double Humidity { get; set; }
    }
}
