using LearnApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Application.Contracts
{
    public interface IUserService
    {
        public Task<IReadOnlyList<User>> GetUsers();
        public Task<IReadOnlyList<User>> GetUser(int userId);

        public Task<IReadOnlyList<Order>> GetOrders(int userId);
    }
}
