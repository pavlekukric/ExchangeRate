using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExchangeRate.Application.Requests;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Services
{
    public interface IExchangeRateService
    {
        Task<ExchangeRateInfo> GetExchangeRateInfo(ExchangeRateInfoRequest request);
    }
}
