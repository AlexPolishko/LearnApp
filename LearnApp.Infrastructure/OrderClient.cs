using Grpc.Net.Client;
using LearnApp.Application;
using LearnApp.Application.Contracts;
using LearnApp.Domain;
using LearnApp.OrderService;
using Microsoft.Extensions.Options;

namespace LearnApp.Infrastructure
{
    public class OrderClient : IOrderClient
    {
        private readonly ApplicationConfiguration _configuration;

        public OrderClient(IOptions<ApplicationConfiguration> options)
        {
           _configuration = options.Value;
        }

        public async Task<Order> GetOrder()
        {
            var channel = GrpcChannel.ForAddress(_configuration.OrderServiceAddress);
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