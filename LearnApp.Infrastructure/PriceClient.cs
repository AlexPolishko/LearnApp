using LearnApp.Application.Contracts;
using LearnApp.Domain;
using System.Net.Http.Json;

namespace LearnApp.Infrastructure
{
    public class PriceClient : IPriceClient
    {
        public readonly HttpClient _httpClientFactory;

        public PriceClient(HttpClient httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Price> GetPrice()
        {
            var client = _httpClientFactory;
            var response = await client.GetAsync("/Price?resulttype=1");
            if (!response.IsSuccessStatusCode)
                return null;

            var price = await response.Content.ReadFromJsonAsync<Price>();
            return price;
        }
    }
}
