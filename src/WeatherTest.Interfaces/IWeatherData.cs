using System.Collections.Generic;
using WeatherTest.DAL;

namespace WeatherTest.Interfaces
{
    public interface IWeatherData
        {
            List<WeatherTestDTO> GetWeather(List<WebServiceDataSourceDTO> collWeatherDataSources, string location);

        }
}
