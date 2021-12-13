using ExchangeRate.Application.Ports;
using ExchangeRate.Infrastructure.Adapters;
using ExchangeRate.Infrastructure.ExchangeRateHostClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRate.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IExchangeRateProvider, ExchangeRateAdapter>();
            services.AddTransient<IExchangeRateHostClient, ExchangeRateHostClient.ExchangeRateHostClient>();

            return services;
        }
    }
}
