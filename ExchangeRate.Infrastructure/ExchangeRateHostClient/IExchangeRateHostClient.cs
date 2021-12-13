using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExchangeRate.Application.Requests;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Infrastructure.ExchangeRateHostClient
{
    public interface IExchangeRateHostClient
    {
        Task<ExchangeRatePerDay>  GetExchangeRateForDate(string from, string to, DateTime date);
    }
}
