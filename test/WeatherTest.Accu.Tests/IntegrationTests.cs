using Microsoft.AspNet.TestHost;
using System.Net.Http;
using Xunit;

namespace WeatherTest.Accu.Tests
{
	public class IntegrationTests
    {
		[Fact]
		public async void GivenLocationIsLondonWhenCallingWeatherControllerThenReturnWeatherResultInJSON()
		{
			var builder = TestServer.CreateBuilder()
						.UseEnvironment("Development")
						.UseStartup<Startup>();
			var server = new TestServer(builder);
			var client = server.CreateClient();
			var request = new HttpRequestMessage(HttpMethod.Get, "/Weather/London");

			var result = await client.SendAsync(request);
			var body = await result.Content.ReadAsStringAsync();

			Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK);
			Assert.True(body.Contains("\"Location\":\"London\""));
			Assert.True(body.Contains("TemperatureCelsius"));
			Assert.True(body.Contains("WindSpeedKph"));
		}
    }
}
