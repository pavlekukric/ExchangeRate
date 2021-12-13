using System;

namespace ExchangeRate.Domain.Entities
{
    public class ExchangeRateInfo
    {
        public double MinRate { get; set; }
        public DateTime MinRateDate { get; set; }

        public double MaxRate { get; set; }
        public DateTime MaxRateDate { get; set; }

        public double AverageRate { get; set; }
    }
}
