using System;

namespace ExchangeRate.Infrastructure.ExchangeRateHostClient.Response
{
    public class HistoricalExchangeRate
    {
        public Query Query { get; set; }
        public bool Historical { get; set; }
        public DateTime Date { get; set; }
        public double Result { get; set; }
        public bool Success { get; set; }
    }
}
