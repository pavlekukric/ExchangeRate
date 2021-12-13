using System;
using System.Collections.Generic;
using ExchangeRate.Application.Requests;

namespace ExchangeRate.IntegrationTest.Helpers
{
    public static class RequestBuilder
    {
        public static ExchangeRateInfoRequest BuildRequestForNumberOfDays(int numOfDays)
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime initialDate = new DateTime(2018, 5, 30);
            for (var i = 0; i < numOfDays; i++)
            {
                dates.Add(initialDate.AddDays(i));
            }

            return new ExchangeRateInfoRequest
            {
                BaseCurrency = "SEK",
                TargetCurrency = "NOK",
                Dates = dates
            };
        }

        public static ExchangeRateInfoRequest BuildInvalidRequestForNumberOfDays(int numOfDays)
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime initialDate = new DateTime(2012, 5, 30);
            for (var i = 0; i < numOfDays; i++)
            {
                dates.Add(initialDate.AddDays(i));
            }

            return new ExchangeRateInfoRequest
            {
                BaseCurrency = "",
                TargetCurrency = "NOK",
                Dates = dates
            };
        }


    }
}
