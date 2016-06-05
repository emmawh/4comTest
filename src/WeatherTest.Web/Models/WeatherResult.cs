using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherTest.Web.Models
{
    public class WeatherResultVM
    {
        public string Location { get; set; }
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
        public WindSpeedUoM WindSpeedUoM { get; set; }
        public TemperatureUoM TemperatureUoM { get; set; }
    }

    public enum WindSpeedUoM
    {
        KPH,
        MPH
    }

    public enum TemperatureUoM
    {
        CELSIUS,
        FAHRENHEIT
    }
}