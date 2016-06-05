using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherTest.Core.Domain;

namespace WeatherTest.Core.Interfaces
{
    public interface IWeatherTestResult
    {
        WeatherTestDTO GetWeather(string location);
    }
}
