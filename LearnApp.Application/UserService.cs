using LearnApp.Application.Contracts;
using LearnApp.Domain;
using System.Collections.ObjectModel;
using System.Linq;

namespace LearnApp.Application;
public class UserService : IUserService
{
    private readonly IOrderClient orderClient;
    private readonly IPriceClient priceClient;
    private readonly IPriceAdvancedClient advancedPriceClient;

    public UserService (IOrderClient orderClient, IPriceClient priceClients, IPriceAdvancedClient priceAdvancedClient)
    {
        this.orderClient = orderClient;
        this.priceClient = priceClients;
        this.advancedPriceClient = priceAdvancedClient;
    }

    public async Task<IReadOnlyList<User>> GetUsers()
    {
        var orderTask = orderClient.GetOrder();
        var priceTask = priceClient.GetPrice();
        var concurentPriceTask = advancedPriceClient.GetPrice();

        var price1 = await priceTask;
        var price2 = await concurentPriceTask;

        var client = new Client
        {
            LastName = "Jack",
            DoB = DateTime.Now,
            Order = await orderTask,
            Price = price1?.Amount > price2?.Amount ? price1 : price2
        };

        var selectedPrice = await advancedPriceClient.GetSelectedPriceAsync(42);
        await advancedPriceClient.UpdatePrice(selectedPrice);

        return new List<User>() { 
            client
        };
    }

    public async Task<IReadOnlyList<Order>> GetOrders(int userId)
    {
        var order = await orderClient.GetOrder();
        var list = new List<Order>() { order };
        return list.AsReadOnly(); 
    }

    public Task<IReadOnlyList<User>> GetUser(int userId)
    {
        throw new NotImplementedException();
    }
}
