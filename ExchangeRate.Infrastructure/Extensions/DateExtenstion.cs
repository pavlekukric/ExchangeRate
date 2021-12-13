using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExchangeRate.Infrastructure.Extensions
{
    public static class DateExtenstion
    {
        public static string ConvertToValidDateFormat(this DateTime dateTime)
        {
            return dateTime.Date.ToString("yyyy-MM-dd");
        }
    }
}
