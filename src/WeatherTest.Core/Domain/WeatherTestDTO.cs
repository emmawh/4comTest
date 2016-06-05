using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.Core.Domain
{
    public class WeatherTestDTO
    {
        public string Location { get; set; }
        public double? TemperatureFahrenheit { get; set; }
        public double? TemperatureCelsius { get; set; }
        public double? WindSpeedMph { get; set; }
        public double? WindSpeedKph { get;  set;}
    }
}
