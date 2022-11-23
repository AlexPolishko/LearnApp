using LearnApp.Domain;

namespace LearnApp.Application;
public class UserService : IUserService
{
    public IReadOnlyList<User> GetUsers()
    {
        return new List<User>() { new Client { LastName = "Jack", DoB = DateTime.Now } };
    }

    public IReadOnlyList<Order> GetOrders(string clientName)
    {
        return new List<Order>(); 
    }

    public class Order
    { }
}
