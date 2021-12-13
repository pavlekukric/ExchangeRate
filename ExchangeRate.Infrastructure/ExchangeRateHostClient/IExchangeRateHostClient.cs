using System;
using System.Threading.Tasks;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Infrastructure.ExchangeRateHostClient
{
    public interface IExchangeRateHostClient
    {
        Task<ExchangeRatePerDay>  GetExchangeRateForDate(string from, string to, DateTime date);
    }
}
