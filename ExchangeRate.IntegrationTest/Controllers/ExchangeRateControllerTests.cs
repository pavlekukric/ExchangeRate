using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExchangeRate.API;
using ExchangeRate.IntegrationTest.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace ExchangeRate.IntegrationTest.Controllers
{
    public class ExchangeRateControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; set; }

        //TODO Add to configuration
        public string ApiUrl => "https://localhost:44358/api/ExchangeRate/";
        //public string ApiUrl => "https://exchangerateapi-pk.azurewebsites.net/api/ExchangeRate/";
        public ExchangeRateControllerTests(WebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient(new WebApplicationFactoryClientOptions());
        }

        [Fact]
        public async Task Returns_Data_With_Valid_Request()
        {
            try
            {
                var request = RequestBuilder.BuildRequestForNumberOfDays(50);

                var httpRequest = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"),
                };

                var httpResponse = await Client.SendAsync(httpRequest);
                var exchangeRateResult = await httpResponse.Content.ReadAsStringAsync();

                Assert.NotEmpty(exchangeRateResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        [Fact]
        public async Task Returns_Data_With_Invalid_Request()
        {
            var request = RequestBuilder.BuildInvalidRequestForNumberOfDays(3);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
            {
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"),
            };

            var httpResponse = await Client.SendAsync(httpRequest);
            var exchangeRateResult = await httpResponse.Content.ReadAsStringAsync();

            Assert.Contains("Currency is required", exchangeRateResult);
        }

        //TODO: Add other missing tests
    }
}
