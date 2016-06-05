using Microsoft.AspNet.Mvc;
using WeatherTest.Accu.Models;

namespace WeatherTest.Accu.Controllers
{
	public class WeatherController : Controller
    {
		private System.Random _rng = new System.Random();

		[HttpGet]
		[Route("[controller]/{location}")]
		public WeatherResult Get(string location)
			=> new WeatherResult {
				Location = location,
				TemperatureCelsius = _rng.Next(0, 38),
				WindSpeedKph = _rng.Next(0, 32) };
    }
}
