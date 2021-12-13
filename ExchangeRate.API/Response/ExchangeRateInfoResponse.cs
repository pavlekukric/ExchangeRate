using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRate.API.Response
{
    public class ExchangeRateInfoResponse : BaseResponse
    {
        public ExchangeRateInfoResponse() : base()
        {
        }

        public string Result { get; set; }
    }
}
