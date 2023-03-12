using LearnApp.Domain;

namespace LearnApp.Application.Contracts
{
    public interface IPriceClient
    {
        Task<Price> GetPrice();
    }
}
