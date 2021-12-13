using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.Requests
{
    public class ExchangeRateInfoPerDayRequest
    {
        public DateTime Date { get; set; }
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
    }
}
