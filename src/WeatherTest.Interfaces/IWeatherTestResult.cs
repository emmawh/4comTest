using WeatherTest.DAL;

namespace WeatherTest.Interfaces
{
    public interface IWeatherTestResult
    {
        WeatherTestDTO GetWeather(string location);
    }

}
