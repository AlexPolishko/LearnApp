using LearnApp.Domain;

namespace LearnApp.Application
{
    public interface IPriceClient
    {
        Task<Price> GetPrice();
    }
}
