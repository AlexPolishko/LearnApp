using LearnApp.Domain;

namespace LearnApp.Application.Contracts
{
    public interface IOrderClient
    {
        Task<Order> GetOrder();
    }
}
