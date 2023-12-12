using Newtonsoft.Json.Linq;
using System.Net;

namespace CurrencyService.Currency
{
    internal class CurrencyService<Type> : VariableType<Type> where Type : IComparable, IComparable<Type>, IConvertible, IEquatable<Type>, IFormattable
    {
        private Type _currentValue;
        public Type CurrentValue
        {
            get => _currentValue;
            set
            {
                Type oldValue = _currentValue;
                _currentValue = value;
                if (_currentValue.CompareTo((dynamic)oldValue) != 0)
                {
                    if (_currentValue.CompareTo(MaxValue) > 0)
                        _currentValue = MaxValue;

                    if (_currentValue.CompareTo(default) < 0)
                        _currentValue = MinValue;

                    var args = new CurrencyServiceEventArgs<Type>(this, oldValue, _currentValue);
                    OnChangedCurrency?.Invoke(this, args);
                }
            }
        }
        public EventHandler<CurrencyServiceEventArgs<Type>> OnChangedCurrency = delegate { };
        public List<Transaction<Type>> Transactions = new List<Transaction<Type>>();
        public string NameCurrency { get; private set; }
        public Type MaxValue { get; private set; }
        public Type MinValue { get; private set; }

        public CurrencyService(Type currentValue, Type maxValue)
        {
            NameCurrency = null;
            MaxValue = maxValue;
            CurrentValue = currentValue;
            OnChangedCurrency += OnChangedMoney;
        }

        public CurrencyService(string nameCurrency, Type currentValue, Type maxValue)
        {
            NameCurrency = nameCurrency;
            MaxValue = maxValue;
            CurrentValue = currentValue;
            OnChangedCurrency += OnChangedMoney;
            Transactions.Add(new Transaction<Type>("Null", 0, "Null", "Null", "Null", "Null", CurrentValue, CurrentValue, CurrentValue));
        }


        private void OnChangedMoney(object? sender, CurrencyServiceEventArgs<Type> e)
        {
            using (WebClient webClient = new())
            {
                JObject jsonResponse = JObject.Parse(webClient.DownloadString("http://ipinfo.io/json"));

                TryGetString(jsonResponse, "city", out string city);
                TryGetString(jsonResponse, "region", out string region);
                TryGetString(jsonResponse, "postal", out string postal);

                if (!string.IsNullOrEmpty(NameCurrency))
                {
                    Transactions.Add(new Transaction<Type>(NameCurrency,
                                                           Transactions[Transactions.Count - 1].Id + 1,
                                                           $"{Dns.GetHostEntry(Dns.GetHostName()).AddressList[0]}",
                                                           city,
                                                           region,
                                                           postal,
                                                           e.NewValue,
                                                           e.OldValue,
                                                           CurrentValue));
                    Console.WriteLine(Transactions[Transactions.Count - 1]);
                }
            }
        }

        public bool TryGetString(JObject keyValues, string key, out string value)
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

        public Type Set(Type value)
        {
            CurrentValue = value;
            return CurrentValue;
        }

        public Type Add(Type value)
        {
            CurrentValue += (dynamic)value;
            return CurrentValue;
        }

        public Type Subtract(Type value)
        {
            CurrentValue = CurrentValue - (dynamic)value;
            return CurrentValue;
        }

        public Type Divide(Type value)
        {
            CurrentValue = CurrentValue / (dynamic)value;
            return CurrentValue;
        }

        public Type Multiply(Type value)
        {
            CurrentValue = CurrentValue * (dynamic)value;
            return CurrentValue;
        }
    }
}
