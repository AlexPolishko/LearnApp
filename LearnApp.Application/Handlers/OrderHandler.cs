using LearnApp.Application.Contracts;
using LearnApp.Application.Reqeusts;
using LearnApp.Domain;
using MediatR;

namespace LearnApp.Application.Handlers
{
    public class OrderHandlers : IRequestHandler<GetOrderRequest, IReadOnlyList<Order>>
    {
        private readonly IUserService _userService;

        public OrderHandlers(IUserService userService)
        {
            _userService = userService;
        }

        public Task<IReadOnlyList<Order>> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            return _userService.GetOrders(request.Id);
        }
    }
}
