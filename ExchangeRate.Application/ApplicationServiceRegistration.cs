using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ExchangeRate.Application.Ports;
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
