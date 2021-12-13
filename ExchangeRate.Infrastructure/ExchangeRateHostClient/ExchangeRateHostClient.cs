using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ExchangeRate.Application.Requests;
using ExchangeRate.Domain.Entities;
using ExchangeRate.Infrastructure.Exceptions;
using ExchangeRate.Infrastructure.Extensions;
using RestSharp;

namespace ExchangeRate.Infrastructure.ExchangeRateHostClient
{
    public class ExchangeRateHostClient : IExchangeRateHostClient
    {
        private readonly IRestClient _restClient;

        public ExchangeRateHostClient()
        {
            //TODO read base Url from config file
            _restClient = new RestClient("https://api.exchangerate.host/");
        }

        public async Task<ExchangeRatePerDay>  GetExchangeRateForDate(string from, string to, DateTime date)
        {
            var restRequest = new RestRequest($"convert?from={from}&to={to}", Method.GET)
                .AddQueryParameter("date", $"{date.ConvertToValidDateFormat()}")
                .AddQueryParameter("source", "ecb");
            var response = await _restClient.ExecuteAsync<Response.HistoricalExchangeRate>(restRequest);
            
            if (UnexpectedStatusCode(response.StatusCode))
                throw RestExceptionFrom(response);

            return response.StatusCode == HttpStatusCode.OK && response.Data != null
                ? response.Data.ToDomain()
                : null;
        }

        private static bool UnexpectedStatusCode(HttpStatusCode statusCode)
        {
            return statusCode != HttpStatusCode.OK;
        }

        private static RestClientException RestExceptionFrom(IRestResponse response)
        {
            return new RestClientException(response.StatusCode);
        }
    }
}