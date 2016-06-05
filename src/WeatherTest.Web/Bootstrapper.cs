using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using WeatherTest.DAL;
using WeatherTest.Interfaces;

namespace WeatherTest.Web
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      container.RegisterType<IWeatherTestResult, WeatherTestResult>();    
      //RegisterTypes(container);

      return container;
    }
  }
}