using LearnApp.Domain;
using MediatR;

namespace LearnApp.Application.Reqeusts
{
    public class GetOrderRequest : IRequest<IReadOnlyList<Order>>
    {
        public int Id { get; set; }
    }
}
