using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeRate.Application.Exceptions;
using ExchangeRate.Application.Ports;
using ExchangeRate.Application.Requests;
using ExchangeRate.Application.Validators;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IExchangeRateProvider _exchangeRateProvider;

        public ExchangeRateService(IExchangeRateProvider exchangeRateProvider)
        {
            _exchangeRateProvider = exchangeRateProvider;
        }
        
        public async Task<ExchangeRateInfo>  GetExchangeRateInfo(ExchangeRateInfoRequest request)
        {
            var validator = new ExchangeRateInfoRequestValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var exchangeRatePerDays = new List<ExchangeRatePerDay>();

            Task.WaitAll(request.Dates.Select(date => GetExchangeRatePerDay(request.BaseCurrency, request.TargetCurrency, date, exchangeRatePerDays)).ToArray());

            var maxExchangeRatePerDay = GetMaxExchangeRateFrom(exchangeRatePerDays);
            var minExchangeRatePerDay = GetMinExchangeRateFrom(exchangeRatePerDays);
            var averageRate = CalculateAverageRate(maxExchangeRatePerDay.Rate, minExchangeRatePerDay.Rate);

            return new ExchangeRateInfo
            {
                MaxRate = maxExchangeRatePerDay.Rate,
                MaxRateDate = maxExchangeRatePerDay.Date,
                MinRate = minExchangeRatePerDay.Rate,
                MinRateDate = minExchangeRatePerDay.Date,
                AverageRate = averageRate
            };
        }

        private async Task GetExchangeRatePerDay(string baseCurrency,string targetCurrency,DateTime date, ICollection<ExchangeRatePerDay> exchangeRatePerDays)
        {
            var result = await _exchangeRateProvider.GetExchangeRatePerDay(baseCurrency, targetCurrency, date);
            exchangeRatePerDays.Add(result);
        }
        private static ExchangeRatePerDay GetMaxExchangeRateFrom(IEnumerable<ExchangeRatePerDay> exchangeRatePerDays)
        {
            return exchangeRatePerDays.OrderByDescending(x => x.Rate).FirstOrDefault();
        }
        private static ExchangeRatePerDay GetMinExchangeRateFrom(List<ExchangeRatePerDay> exchangeRatePerDays)
        {
            return exchangeRatePerDays.OrderBy(x => x.Rate).FirstOrDefault();
        }
        private static double CalculateAverageRate(double max, double min)
        {
            return (max + min) / 2;
        }
    }
}
