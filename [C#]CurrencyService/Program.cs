using CurrencyService.Currency;

namespace Lyten.Currency.Example
{
    public class Example
    {
        private static void Main()
        {
            CurrencyService<decimal> nfCoins = new("NexFixelCoin", 10, 99999);
            nfCoins.Add(10);
            CurrencyService<float> nfCoins1 = new("Donat", 10, 99999);
            nfCoins1.Add(10.1f);
            nfCoins.Multiply(10);
            nfCoins1.Add(10.20f);
        }
    }
}
