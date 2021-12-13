namespace ExchangeRate.Infrastructure.ExchangeRateHostClient.Response
{
    public class Query
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Amount { get; set; }
    }
}