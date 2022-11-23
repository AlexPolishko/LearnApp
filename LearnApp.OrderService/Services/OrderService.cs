using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace LearnApp.OrderService.Services
{
    public class OrderService : OrderManager.OrderManagerBase
    {
        public override Task<OrderResponse> GetOrders(UserRequest request, ServerCallContext context)
        {
            return Task.FromResult(
                new OrderResponse
                {
                    Message = "42th order",
                    OrderId = "42",
                    Time = Timestamp.FromDateTime(DateTime.UtcNow)
                }
            );
        }

        public override Task<OrderResponse> GetOrderByKey(OrderRequest request, ServerCallContext context)
        {
            return Task.FromResult(
                new OrderResponse
                {
                    Message = "42th order",
                    OrderId = "42",
                    Time = Timestamp.FromDateTime(DateTime.UtcNow)
                }
            );
        }

        public override async Task GetOrdersStream(UserRequest request, IServerStreamWriter<OrderResponse> responseStream, ServerCallContext context)
        {
            for (int i = 0; i < 60; i++)
            {
                if (context.CancellationToken.IsCancellationRequested)
                {
                    break;
                }

                await Task.Delay(1000);
                await responseStream.WriteAsync(
                     new OrderResponse
                     {
                         Message = $"{i}th order",
                         OrderId = i.ToString(),
                         Time = Timestamp.FromDateTime(DateTime.UtcNow)
                     }
                );
            }
        }
    }
}
