using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherTest.Core.Interfaces;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace WeatherTest.Core.Domain
{
    public class WeatherTestSvc : IWeatherTestResult
    {
        public void WeatherTestSVC()
        {
        }

        public WeatherTestDTO GetWeather(string location)
        {
            List<WeatherTestDTO> collWeatherTests = new List<WeatherTestDTO>();
            collWeatherTests.Add(GetAccuWeather(location));
            collWeatherTests.Add(GetBBCWeather(location));

            var weatherTestDTO = new WeatherTestDTO();
            weatherTestDTO.TemperatureCelsius = GetAverageValue(collWeatherTests, nameof(WeatherTestDTO.TemperatureCelsius));
            weatherTestDTO.WindSpeedKph = GetAverageValue(collWeatherTests, nameof(WeatherTestDTO.WindSpeedKph));
            return weatherTestDTO;
        }

        private WeatherTestDTO GetBBCWeather(string location)
        {
            WeatherTestDTO weatherTestDto = GetJSONWeatherFromUrl(string.Format(@"http://localhost:60827/weather/{0}", location));
            return weatherTestDto;

        }

        private WeatherTestDTO GetAccuWeather(string location)
        {
            WeatherTestDTO weatherTestDto = GetJSONWeatherFromUrl(string.Format(@"http://localhost:60827/weather/{0}", location));
            return weatherTestDto;
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

        private WeatherTestDTO GetWeatherFromURL(string url)
        {
            var weatherTestDTO = new WeatherTestDTO();
            using (var webClient = new WebClient())
            {
                string str = webClient.DownloadString(url);
                JObject o = JObject.Parse(str);
                weatherTestDTO.Location = (string)o["Location"];
                weatherTestDTO.TemperatureCelsius = o["TemperatureCelsius"] != null ? (double)o["TemperatureCelsius"] : 0.0;
                weatherTestDTO.TemperatureFahrenheit = o["TemperatureFahrenheit"] != null ? (double)o["TemperatureFahrenheit"] : 0.0;
                Console.WriteLine(o["Location"]);
            }
            return weatherTestDTO;
        }

        private WeatherTestDTO GetJSONWeatherFromUrl(string url)
        {
            WeatherTestDTO weatherTestDTO = null;

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
