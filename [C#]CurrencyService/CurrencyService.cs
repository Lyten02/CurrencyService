using CurrencyService;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Lyten.Currency
{
    public class CurrencyService<Type> : VariableType<Type> where Type : IComparable, IComparable<Type>, IConvertible, IEquatable<Type>, IFormattable
    {
        public string? NameCurrency { get; private set; }
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

        public Type MaxValue { get; private set; }
        public Type MinValue { get; private set; }
        public EventHandler<CurrencyServiceEventArgs<Type>> OnChangedCurrency = delegate { };
        public List<Transaction<Type>> Transactions = new List<Transaction<Type>>();

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
            using WebClient client = new WebClient();
            string locationInfoJson = client.DownloadString("http://ipinfo.io/json");

            JObject jsonResponse = JObject.Parse(locationInfoJson);
            string city = jsonResponse["city"].ToString();
            string region = jsonResponse["region"].ToString();
            string postal = jsonResponse["postal"].ToString();

            Transactions.Add(new Transaction<Type>(
                NameCurrency, 
                Transactions[Transactions.Count-1].Id+1, 
                $"{Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString()}", 
                city, 
                region, 
                postal,
                e.NewValue,
                e.OldValue,
                CurrentValue));
            Console.WriteLine(Transactions[Transactions.Count - 1]);
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
