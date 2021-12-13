using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ExchangeRate.Infrastructure.Exceptions
{
    public class RestClientException : Exception
    {
        private readonly HttpStatusCode _statusCode;

        public RestClientException(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
        }

        public override string Message => $"REST API https://exchangerate.host returned unexpected status code: {_statusCode}";
    }
}
