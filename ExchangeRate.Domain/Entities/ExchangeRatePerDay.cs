using System;

namespace ExchangeRate.Domain.Entities
{
    public class ExchangeRatePerDay
    {
        public double Rate { get; set; }
        public DateTime Date { get; set; }

        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
    }
}
