using System;
using System.Net;

namespace ExchangeRate.Infrastructure.Exceptions
{
    public class RestClientException : Exception
    {
        private readonly HttpStatusCode _statusCode;
        private readonly string _exceptionMessage;

        public RestClientException(HttpStatusCode statusCode, string exceptionMessage)
        {
            _statusCode = statusCode;
            _exceptionMessage = exceptionMessage;
        }

        public override string Message => $"REST API https://exchangerate.host returned unexpected status code: {_statusCode}. ExceptionMessage: {_exceptionMessage}";
    }
}
