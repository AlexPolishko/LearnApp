using LearnApp.Application;
using LearnApp.Domain;
using System.Net.Http.Json;

namespace LearnApp.Infrastructure
{
    public class PriceClient : IPriceClient
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public PriceClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Price> GetPrice()
        {
            var client = _httpClientFactory.CreateClient("price");
            var response = await client.GetAsync("/Price");
            var price = await response.Content.ReadFromJsonAsync<Price>();
            return price;
        }
    }
}
