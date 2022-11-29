using LearnApp.Domain;

namespace LearnApp.Application
{
    public interface IOrderClient
    {
        Task<Order> GetOrder();
    }
}
