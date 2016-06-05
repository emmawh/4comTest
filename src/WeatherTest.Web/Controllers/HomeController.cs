using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherTest.DAL;
using WeatherTest.Interfaces;
using WeatherTest.Web.Models;

namespace WeatherTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private IWeatherTestResult _weatherTestResult;
        public HomeController(IWeatherTestResult weatherTestResult)
        {
            _weatherTestResult = new WeatherTestResult();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTemperature(WeatherResultVM model)
        {
            WeatherTestDTO result = _weatherTestResult.GetWeather(model.Location);

            //not ideal to have the following logic in the controller... needs factoring out of here
            model.Temperature = model.TemperatureUoM == TemperatureUoM.CELSIUS ?
                (double)result.TemperatureCelsius :
                (double)result.TemperatureFahrenheit;

            model.WindSpeed = model.WindSpeedUoM == WindSpeedUoM.KPH ?
                (double)result.WindSpeedKph :
                (double)result.WindSpeedMph;

            return View("Index", model);
        }
    }
}