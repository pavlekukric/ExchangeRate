using System;
using System.Collections.Generic;

namespace ExchangeRate.Application.Requests
{
    public class ExchangeRateInfoRequest
    {
        public List<DateTime>  Dates { get; set; }
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
    }
}
