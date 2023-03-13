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
using LearnApp.Application;
using Microsoft.Extensions.Options;
using Google.Protobuf.WellKnownTypes;

namespace LearnApp.Infrastructure
{
    public static class ServiceCollectionInfrastructure
    {
        public static IServiceCollection ServiceCollectionServiceExtensions(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<IPriceClient, PriceClient>(
                (provider,config) =>
                {
                    var options = provider.GetService<IOptions<ApplicationConfiguration>>();
                    config.BaseAddress = new Uri(options.Value.PriceServiceAddress);
                }
                ).AddPolicyHandler(GetPolicy());

            serviceCollection.AddRefitClient<IPriceAdvancedClient>()
            .ConfigureHttpClient(
                (provider,c) => {
                    var options = provider.GetService<IOptions<ApplicationConfiguration>>();
                    c.BaseAddress = new Uri(options?.Value.PriceServiceAddress);
                    }
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
