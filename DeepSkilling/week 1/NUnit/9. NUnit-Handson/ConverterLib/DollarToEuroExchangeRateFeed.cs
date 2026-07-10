namespace ConverterLib
{
    public class DollarToEuroExchangeRateFeed : IDollarToEuroExchangeRateFeed
    {
        public decimal GetExchangeRate()
        {
            return 0.85M;
        }
    }
}