using Microsoft.AspNet.Mvc;
using WeatherTest.Bbc.Models;

namespace WeatherTest.Bbc.Controllers
{
    public class WeatherController : Controller
    {
		private System.Random _rng = new System.Random();

		[HttpGet]
		[Route("[controller]/{location}")]
		public WeatherResult Get(string location)
			=> new WeatherResult
			{
				Location = location,
				TemperatureFahrenheit = _rng.Next(32, 100),
				WindSpeedMph = _rng.Next(0, 20)
			};
	}
}
