using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.Core.Domain
{
    public class ConversionFunctions
    {
        private const double CONVERT_KPH_TO_MPH = 0.621371;
        private const double CONVERT_MPH_TO_KPH = 1.60934;
        private const double CONVERT_FAHR_TO_CELSIUS = 0;
        private const double CONVERT_CELSIUS_TO_FAHR = 0;

        public double ConvertCelsiusToFahrenheit(double temp)
        {
            return 0.0;
        }
        public double ConvertFahrenheitToCelsius(double temp)
        {
            return 0.0;
        }
        public double ConvertKphToMph(double speed)
        {
            return 0.0;
        }
        public double ConvertMphToKph(double speed)
        {
            return 0.0;
        }
    }
}
