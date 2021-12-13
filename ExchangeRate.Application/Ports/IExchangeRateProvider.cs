using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExchangeRate.Application.Requests;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Ports
{
    public interface IExchangeRateProvider
    {
        Task<ExchangeRatePerDay>  GetExchangeRatePerDay(string fromDate, string toDate, DateTime date);
    }
}
