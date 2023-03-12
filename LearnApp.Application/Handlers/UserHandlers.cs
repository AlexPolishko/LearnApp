using LearnApp.Application.Contracts;
using LearnApp.Application.Reqeusts;
using LearnApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Application.Handlers
{
    public class UserHandlers : IRequestHandler<GetUserRequest, IReadOnlyList<User>>
    {
        private readonly IUserService _userService;

        public UserHandlers(IUserService userService)
        {
            _userService = userService;
        }

        public Task<IReadOnlyList<User>> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            return _userService.GetUsers();
        }
    }
}
