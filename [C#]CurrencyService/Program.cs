using CurrencyService.Currency;

namespace Lyten.Currency.Example
{
    public class Example
    {
        private static void Main()
        {
            // Test 
            CurrencyService<decimal> nfCoins = new("Coin", 10, 20);
            nfCoins += 10.0M;
            nfCoins -= 10.1M;
            nfCoins *= 10.2M;
            nfCoins /= 10.3M;
        }
    }
}
