using Grpc.Net.Client;
using LearnApp.Application;
using LearnApp.Domain;
using LearnApp.OrderService;

namespace LearnApp.Infrastructure
{
    public class OrderClient : IOrderClient
    {
        public async Task<Order> GetOrder()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5057");
            var client = new OrderManager.OrderManagerClient(channel);

            var request = new UserRequest 
            { 
                Name = "TestUser" 
            };

            var response = await client.GetOrdersAsync(request);

            return new Order 
            { 
                Id = int.Parse(response.OrderId),
                Name = response.Message
            };
        }
    }
}