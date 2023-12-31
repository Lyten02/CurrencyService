using Newtonsoft.Json.Linq;
using System.Net;

namespace CurrencyService.Currency
{
    public class Transaction<T> : VariableType<T> where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        public string? Name { get; private set; }
        public ulong Id { get; private set; }
        public T? NewValue { get; private set; }
        public T? OldValue { get; private set; }
        public T? CurrentValue { get; private set; }
        public string? Address { get; private set; }
        public string? City { get; private set; }
        public string? Region { get; private set; }
        public string? PostalCode { get; private set; }
        public DateTime? TransactionDate { get; private set; }

        public Transaction(string name, ulong id, string address, string city, string region, string postalcode, T? newValue, T? oldValue, T? currentValue)
        {
            Name = name;
            Id = id;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalcode;
            TransactionDate = DateTime.Now;
            NewValue = newValue ?? throw new ArgumentNullException(nameof(newValue));
            OldValue = oldValue ?? throw new ArgumentNullException(nameof(newValue));
            CurrentValue = currentValue ?? throw new ArgumentNullException(nameof(newValue));
        }
        public Transaction(string name, ulong id, string address, string city, string region, string postalcode)
        {
            Name = name;
            Id = id;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalcode;
            TransactionDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"\tTransaction #{Id}\n" +
                $"Name: {Name}\n" +
                $"Id: {Id}\n" +
                $"Address: {Address}\n" +
                $"City: {City}\n" +
                $"Region: {Region}\n" +
                $"PostalCode: {PostalCode}\n" +
                $"TransactionDate: {TransactionDate}\n" +
                $"\tValues:\n" +
                $"New: {NewValue}\n" +
                $"Old: {OldValue}\n" +
                $"Current: {CurrentValue}";
        }

        private static bool TryGetString(JObject keyValues, string key, out string value)
        {
            if (!string.IsNullOrEmpty(key))
            {
                if (keyValues.TryGetValue(key, StringComparison.CurrentCulture, out JToken? token))
                {
                    value = token.ToString();
                    return true;
                }
                else
                {
                    value = string.Empty;
                    return false;
                }
            }
            else
            {
                throw new Exception("No valid key.");
            }
        }

        public static void OnChangedMoney(CurrencyService<T> currencyService, object? sender, CurrencyServiceEventArgs<T> e)
        {
            using (WebClient webClient = new())
            {
                JObject jsonResponse = JObject.Parse(webClient.DownloadString("http://ipinfo.io/json"));

                TryGetString(jsonResponse, "city", out string city);
                TryGetString(jsonResponse, "region", out string region);
                TryGetString(jsonResponse, "postal", out string postal);

                if (!string.IsNullOrEmpty(currencyService.NameCurrency))
                {
                    currencyService.Transactions.Add(new Transaction<T>(
                        currencyService.NameCurrency,
                        currencyService.Transactions[currencyService.Transactions.Count - 1].Id + 1,
                        $"{Dns.GetHostEntry(Dns.GetHostName()).AddressList[0]}",
                        city,
                        region,
                        postal,
                        e.NewValue,
                        e.OldValue,
                        currencyService.CurrentValue ?? throw new ArgumentNullException(nameof(CurrentValue))));
                    Console.WriteLine(currencyService.Transactions[currencyService.Transactions.Count - 1]);
                }
            }
        }
    }
}
