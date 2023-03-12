using LearnApp.Domain;
using MediatR;

namespace LearnApp.Application.Reqeusts
{
    public class GetUserRequest : IRequest<IReadOnlyList<User>>
    {
        public int Id { get; set; }
    }
}
