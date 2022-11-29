using LearnApp.Domain;

namespace LearnApp.Application;
public class UserService : IUserService
{
    private readonly IOrderClient orderClient;
    private readonly IPriceClient priceClient;

    public UserService (IOrderClient orderClient, IPriceClient priceClient)
    {
        this.orderClient = orderClient;
        this.priceClient = priceClient;
    }

    public async Task<IReadOnlyList<User>> GetUsers()
    {
        var orderTask = orderClient.GetOrder();
        var priceTask = priceClient.GetPrice();

        var client = new Client
        {
            LastName = "Jack",
            DoB = DateTime.Now,
            Order = await orderTask,
            Price = await priceTask
        };

        return new List<User>() { 
            client
        };
    }

    public IReadOnlyList<Order> GetOrders(string clientName)
    {
        return new List<Order>(); 
    }
}
