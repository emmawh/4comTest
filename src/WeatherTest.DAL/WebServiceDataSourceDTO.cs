using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.DAL
{
    public class WebServiceDataSourceDTO
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public ResponseDataType ResponseDataType { get; set; }
        public WeatherTestProperties ParamMapping { get; set; }
    }

    public enum ResponseDataType
    {
        JSON,
        XML,
        OTHER
    }

    public struct WeatherTestProperties
    {
        public void SetDefaults()
        {
            TemperatureFahrenheit = "TemperatureFahrenheit";
            TemperatureCelsius = "TemperatureCelsius";
            WindSpeedMph = "WindSpeedMph";
            WindSpeedKph = "WindSpeedKph";
        }

        public string Location { get; set; }
        public string TemperatureFahrenheit { get; set; }
        public string TemperatureCelsius { get; set; }
        public string WindSpeedMph { get; set; }
        public string WindSpeedKph { get; set; }
    }

}
