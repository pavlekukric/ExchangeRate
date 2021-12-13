using Microsoft.Extensions.DependencyInjection;
using ExchangeRate.Application.Services;

namespace ExchangeRate.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IExchangeRateService, ExchangeRateService>();

            return services;
        }
    }
}
