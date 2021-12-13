using System;
using System.Collections.Generic;
using System.Text;
using ExchangeRate.Domain.Entities;
using ExchangeRate.Infrastructure.ExchangeRateHostClient.Response;

namespace ExchangeRate.Infrastructure.Extensions
{
    public static class ExchangeRateExtension
    {
        public static ExchangeRatePerDay ToDomain(this HistoricalExchangeRate historicalExchangeRate)
        {
            return new ExchangeRatePerDay
            {
                FromCurrency = historicalExchangeRate.Query.From,
                ToCurrency = historicalExchangeRate.Query.To,
                Date = historicalExchangeRate.Date,
                Rate = historicalExchangeRate.Result
            };
        }
    }
}
