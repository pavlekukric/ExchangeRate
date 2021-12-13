using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExchangeRate.Application.Ports;
using ExchangeRate.Application.Requests;
using ExchangeRate.Domain.Entities;
using ExchangeRate.Infrastructure.ExchangeRateHostClient;

namespace ExchangeRate.Infrastructure.Adapters
{
    public class ExchangeRateAdapter : IExchangeRateProvider
    {
        private readonly IExchangeRateHostClient _exchangeRateHostClient;

        public ExchangeRateAdapter(IExchangeRateHostClient exchangeRateHostClient)
        {
            _exchangeRateHostClient = exchangeRateHostClient;
        }
        
        public async Task<ExchangeRatePerDay>  GetExchangeRatePerDay(string fromDate, string toDate, DateTime date)
        {
            return await _exchangeRateHostClient.GetExchangeRateForDate(fromDate,toDate,date);
        }
    }
}
