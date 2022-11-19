using LearnApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Application
{
    public interface IUserService
    {
        public IReadOnlyList<User> GetUsers();
    }
}
