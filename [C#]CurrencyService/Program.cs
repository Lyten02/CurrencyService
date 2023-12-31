using CurrencyService.Currency;

namespace Lyten.Currency.Example
{
    public class Example
    {
        private static void Main()
        {
            CurrencyService<decimal> nfCoins = new("NexFixelCoin", 10, 20);
            nfCoins += 10;
            CurrencyService<float> nfCoins1 = new("Donat", 10, 99999);
        }
    }
}
