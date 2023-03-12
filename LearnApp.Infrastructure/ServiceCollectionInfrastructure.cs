using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using LearnApp.Application.Contracts;

namespace LearnApp.Infrastructure
{
    public static class ServiceCollectionInfrastructure
    {
        public static IServiceCollection ServiceCollectionServiceExtensions(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<IPriceClient, PriceClient>(
                config =>
                {
                    config.BaseAddress = new Uri("https://localhost:58384");
                }
                ).AddPolicyHandler(GetPolicy());

            serviceCollection.AddRefitClient<IPriceAdvancedClient>()
            .ConfigureHttpClient(
                c => c.BaseAddress = new Uri("https://localhost:58384")
                )
            .AddPolicyHandler(GetPolicy());

            return serviceCollection;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetPolicy()
        {
            return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .RetryAsync(10, onRetry: (exception, retryCount, context) =>
            {
                // Add logic to be executed before each retry, such as logging
                Console.WriteLine($"Retry {retryCount} {exception?.Exception} {exception?.Exception?.Message}");
            });
        }
    }
}
