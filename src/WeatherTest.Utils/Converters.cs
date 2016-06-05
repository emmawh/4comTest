using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.Utils
{
    public static class Converters
    {

        public static double ConvertCelsiusToFahrenheit(double celcius)
        {
            return (celcius * 1.8) + 32;
        }

        public static double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 0.5556;
        }

        public static double ConvertMphToKph(double Mph)
        {
            return Mph / 1.6;
        }
        public static double ConvertKphToMph(double Kph)
        {
            return Kph * 1.6;
        }
    }
}
