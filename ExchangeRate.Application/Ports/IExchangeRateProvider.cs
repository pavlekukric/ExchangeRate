using System;
using System.Threading.Tasks;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Ports
{
    public interface IExchangeRateProvider
    {
        Task<ExchangeRatePerDay>  GetExchangeRatePerDay(string fromDate, string toDate, DateTime date);
    }
}
