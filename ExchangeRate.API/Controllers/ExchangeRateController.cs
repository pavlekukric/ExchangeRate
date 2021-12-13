using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ExchangeRate.API.Response;
using ExchangeRate.Application.Requests;
using ExchangeRate.Application.Services;
using ExchangeRate.Domain.Entities;
using ExchangeRate.Infrastructure.Extensions;

namespace ExchangeRate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        [HttpPost(Name = "GetExchangeRate")]
        public async Task<ExchangeRateInfoResponse> GetExchangeRate([FromBody] ExchangeRateInfoRequest request)
        {
            var exchangeRateInfo = await _exchangeRateService.GetExchangeRateInfo(request);

            var response = BuildResponse(exchangeRateInfo);

            return response;
        }

        private static ExchangeRateInfoResponse BuildResponse(ExchangeRateInfo exchangeRateInfo)
        {
            var response = new ExchangeRateInfoResponse
            {
                Result = $"A min rate of {exchangeRateInfo.MinRate} on {exchangeRateInfo.MinRateDate.ConvertToValidDateFormat()}.  " +
                          $"A max rate of {exchangeRateInfo.MaxRate} on {exchangeRateInfo.MaxRateDate.ConvertToValidDateFormat()}.  " +
                          $"An average rate of {exchangeRateInfo.AverageRate}.  "
            };
            return response;
        }
    }
}
