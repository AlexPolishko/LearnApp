using LearnApp.Application.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LearnApp.Application
{
    public static class ServiceCollectionApplication
    {
        public static IServiceCollection AddApplicationDependency(this IServiceCollection collection)
        {
            collection.AddMediatR(Assembly.GetExecutingAssembly());
            collection.AddScoped<IUserService, UserService>();

            return collection;
        }
    }
}
