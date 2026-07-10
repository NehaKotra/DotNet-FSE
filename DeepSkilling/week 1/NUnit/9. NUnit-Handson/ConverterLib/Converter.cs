namespace ConverterLib
{
    public class Converter
    {
        private readonly IDollarToEuroExchangeRateFeed _exchangeRateFeed;

        public Converter(IDollarToEuroExchangeRateFeed exchangeRateFeed)
        {
            _exchangeRateFeed = exchangeRateFeed;
        }

        public decimal USDToEuro(decimal dollars)
        {
            decimal rate = _exchangeRateFeed.GetExchangeRate();

            return dollars * rate;
        }
    }
}