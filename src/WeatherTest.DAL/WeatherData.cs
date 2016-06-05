using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using WeatherTest.Utils;

namespace WeatherTest.DAL
{
    public class WeatherData
    {
        public List<WeatherTestDTO> GetWeather(List<WebServiceDataSourceDTO> collWeatherDataSources, string location)
        {
            var collWeatherResults = new List<WeatherTestDTO>();
            WeatherTestDTO dto = null;

            foreach (WebServiceDataSourceDTO datasource in collWeatherDataSources)
            {
                switch (datasource.ResponseDataType)
                {
                    case ResponseDataType.JSON:
                        dto = GetJSONWeatherFromUrl(datasource.Url + location);
                        break;
                    /*case ResponseDataType.XML:
                        //not yet implemented
                        break;
                    case ResponseDataType.OTHER:
                        //not yet implemented
                        break;*/
                }
                if (dto != null)
                {
                    dto = AddConvertedValues(dto);
                    collWeatherResults.Add(dto);
                }
            }

            return collWeatherResults;
        }

        public WeatherTestDTO AddConvertedValues(WeatherTestDTO dto)
        {
            dto.TemperatureCelsius = dto.TemperatureCelsius == null && dto.TemperatureFahrenheit != null ? 
                Converters.ConvertCelsiusToFahrenheit((double)dto.TemperatureFahrenheit) : 
                dto.TemperatureCelsius;

            dto.TemperatureFahrenheit = dto.TemperatureFahrenheit == null && dto.TemperatureCelsius != null ?
                Converters.ConvertCelsiusToFahrenheit((double)dto.TemperatureCelsius) : 
                dto.TemperatureFahrenheit;

            dto.WindSpeedKph = dto.WindSpeedKph == null && dto.WindSpeedMph != null ?
                Converters.ConvertMphToKph((double)dto.WindSpeedMph) : 
                dto.WindSpeedKph;

            dto.WindSpeedMph = dto.WindSpeedMph == null && dto.WindSpeedKph != null ?
                Converters.ConvertKphToMph((double)dto.WindSpeedKph) : 
                dto.WindSpeedMph;

            return dto;
        }
                
        protected WeatherTestDTO GetJSONWeatherFromUrl(string url)
        {
            WeatherTestDTO weatherTestDTO;

            var request = HttpWebRequest.Create(@url);
            request.ContentType = "application/json";
            request.Method = "GET";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        Console.Out.WriteLine("Response contained empty body...");
                    }
                    else
                    {
                        Console.Out.WriteLine("Response Body: \r\n {0}", content);
                    }
                    weatherTestDTO = JsonConvert.DeserializeObject<WeatherTestDTO>(content);
                }
            }
            return weatherTestDTO;
        }
    }
}
