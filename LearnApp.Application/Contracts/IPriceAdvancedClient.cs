using LearnApp.Domain;
using Refit;

namespace LearnApp.Application.Contracts
{
    public interface IPriceAdvancedClient
    {
        [Get("/Price?resulttype=0")]    //TODO: remove implementation details from application layer
        public Task<Price> GetPrice();

        [Get("/api/{priceId}/auto")]
        public Task<Price> GetSelectedPriceAsync([AliasAs("priceId")] int id);

        [Post("/Price")]
        public Task UpdatePrice(Price price);
    }
}
