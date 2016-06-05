using Microsoft.AspNet.TestHost;
using System.Net.Http;
using Xunit;

namespace WeatherTest.Bbc.Tests
{
	public class IntegrationTests
    {
		[Fact]
		public async void GivenLocationIsParisWhenCallingWeatherControllerThenReturnWeatherResultInJSON()
		{
			var builder = TestServer.CreateBuilder()
						.UseEnvironment("Development")
						.UseStartup<Startup>();
			var server = new TestServer(builder);
			var client = server.CreateClient();
			var request = new HttpRequestMessage(HttpMethod.Get, "/Weather/Paris");

			var result = await client.SendAsync(request);
			var body = await result.Content.ReadAsStringAsync();

			Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK);
			Assert.True(body.Contains("\"Location\":\"Paris\""));
			Assert.True(body.Contains("TemperatureFahrenheit"));
			Assert.True(body.Contains("WindSpeedMph"));
		}
	}
}
