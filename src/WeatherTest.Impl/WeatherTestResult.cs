using System;
using System.Collections.Generic;
using WeatherTest.Interfaces;

namespace WeatherTest.DAL
{
    public class WeatherTestResult : IWeatherTestResult
    {
        public WeatherTestDTO GetWeather(string location)
        {
            List<WeatherTestDTO> collWeatherTests = new List<WeatherTestDTO>();
            var webServiceDatasources = new List<WebServiceDataSourceDTO>();

            // ***this code could be improved by loading this data from an xml config file
            var dataSource = new WebServiceDataSourceDTO();
            dataSource.Name = "BBC";
            dataSource.ResponseDataType = ResponseDataType.JSON;
            dataSource.Url = "http://localhost:60827/weather/{0}";
            var dataSourceProps = new WeatherTestProperties();
            dataSourceProps.Location = "Location";
            dataSourceProps.TemperatureCelsius = "TemperatureFahrenheit";
            dataSourceProps.WindSpeedKph = "WindSpeedMph";
            dataSource.ParamMapping = dataSourceProps;
            webServiceDatasources.Add(dataSource);

            dataSource = new WebServiceDataSourceDTO();
            dataSource.Name = "Accu";
            dataSource.ResponseDataType = ResponseDataType.JSON;
            dataSource.Url = "http://localhost:60819/weather/{0}";
            dataSourceProps = new WeatherTestProperties();
            dataSourceProps.Location = "Location";
            dataSourceProps.TemperatureCelsius = "TemperatureCelsius";
            dataSourceProps.WindSpeedKph = "WindSpeedKph";
            dataSource.ParamMapping = dataSourceProps;
            webServiceDatasources.Add(dataSource);

            //****

            WeatherData weatherData = new WeatherData();
            collWeatherTests = weatherData.GetWeather(webServiceDatasources, location);

            var weatherTestDTO = new WeatherTestDTO();
            foreach (WeatherTestDTO dto in collWeatherTests)
            {
                weatherTestDTO.TemperatureCelsius = GetAverageValue(collWeatherTests, nameof(WeatherTestDTO.TemperatureCelsius));
                weatherTestDTO.TemperatureFahrenheit = GetAverageValue(collWeatherTests, nameof(WeatherTestDTO.TemperatureFahrenheit));   
                weatherTestDTO.WindSpeedKph = GetAverageValue(collWeatherTests, nameof(WeatherTestDTO.WindSpeedKph));
                weatherTestDTO.WindSpeedMph = GetAverageValue(collWeatherTests, nameof(WeatherTestDTO.WindSpeedMph));
            }

            return weatherTestDTO;
        }

        private double GetAverageValue(IEnumerable<WeatherTestDTO> collWeatherTests, string propertyName)
        {
            int totalRecords = 0;
            double sumValues = 0;
            foreach (var wdto in collWeatherTests)
            {
                totalRecords += 1;
                sumValues += (double)wdto.GetType().GetProperty(propertyName).GetValue(wdto);
            }

            return sumValues / totalRecords;
        }
        
    }
}
