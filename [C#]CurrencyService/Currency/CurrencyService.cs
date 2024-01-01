using System;
using System.Numerics;

namespace CurrencyService.Currency
{
    public class CurrencyService<T> : VariableType<T> where T : INumber<T>
    {
        public EventHandler<CurrencyServiceEventArgs<T>> OnChangedCurrency = delegate { };
        public string? NameCurrency { get; private set; }
        public T? MaxValue { get; private set; }
        public T? MinValue { get; private set; }
        private T? _currentValue;
        public T? CurrentValue
        {
            get => _currentValue;
            set
            {
                T? oldValue = CurrentValue;
                _currentValue = value ?? throw new ArgumentNullException(nameof(value));
                if (!Equals(CurrentValue, oldValue))
                {
                    Clamp();

                    var args = new CurrencyServiceEventArgs<T>(this, oldValue ?? throw new ArgumentNullException(nameof(oldValue)), _currentValue ?? throw new ArgumentNullException(nameof(CurrentValue)));
                    OnChangedCurrency?.Invoke(this, args);
                }
            }
        }

        // Transactions

        public List<Transaction<T>> Transactions = new()
        {
            new Transaction<T>("Create Currency", 0, "Null", "Null", "Null", "Null", default, default, default),
        };

        public CurrencyService(T currentValue, T maxValue)
        {
            NameCurrency = null;

            // Ensure non-negative MaxValue for floating-point types
            if (typeof(T) == typeof(float) || typeof(T) == typeof(double))
            {
                MaxValue = (Comparer<T>.Default.Compare(maxValue, default) < 0) ? (T)Convert.ChangeType(double.PositiveInfinity, typeof(T)) : maxValue;
            }
            else
            {
                // Ensure non-negative MaxValue for other types
                MaxValue = (Comparer<T>.Default.Compare(maxValue, default) < 0) ? default : maxValue;
            }

            CurrentValue = currentValue;
            Subscribe();
        }


        public CurrencyService(string nameCurrency, T currentValue, T maxValue)
        {
            NameCurrency = nameCurrency;
            MaxValue = maxValue;
            CurrentValue = currentValue;
            Subscribe();
        }

        private void Subscribe()
        {
            OnChangedCurrency += OnChangedMoney;
        }

        private void OnChangedMoney(object? sender, CurrencyServiceEventArgs<T> e)
        {
            Transaction<T>.OnChangedMoney(this, sender, e);
        }

        private void Clamp()
        {
            if (_currentValue?.CompareTo(MaxValue) > 0)
                _currentValue = MaxValue;

            if (_currentValue?.CompareTo(default) < 0)
                _currentValue = MinValue;
        }

        #region Operators
        public static CurrencyService<T> operator +(CurrencyService<T> currencyService, T value)
        {
            currencyService.Add(value);
            return currencyService;
        }
        public static CurrencyService<T> operator -(CurrencyService<T> currencyService, T value)
        {
            currencyService.Subtract(value);
            return currencyService;
        }
        public static CurrencyService<T> operator /(CurrencyService<T> currencyService, T value)
        {
            currencyService.Divide(value);
            return currencyService;
        }
        public static CurrencyService<T> operator *(CurrencyService<T> currencyService, T value)
        {
            currencyService.Multiply(value);
            return currencyService;
        }
        public static CurrencyService<T> operator ++(CurrencyService<T> currencyService)
        {
            currencyService.Add((dynamic)1);
            return currencyService;
        }
        public static CurrencyService<T> operator --(CurrencyService<T> currencyService)
        {
            currencyService.Subtract((dynamic)1);
            return currencyService;
        }
        public static bool operator >(CurrencyService<T> currencyService, T value)
        {
            return currencyService?.CurrentValue?.CompareTo(value) > 0;
        }
        public static bool operator <(CurrencyService<T> currencyService, T value)
        {
            return currencyService?.CurrentValue?.CompareTo(value) < 0;
        }
        private T Add(T value)
        {
            CurrentValue += (dynamic)value;
            return CurrentValue;
        }
        public T Subtract(T value)
        {
            CurrentValue = CurrentValue - (dynamic)value;
            return CurrentValue;
        }
        public T Divide(T value)
        {
            CurrentValue = CurrentValue / (dynamic)value;
            return CurrentValue;
        }
        public T Multiply(T value)
        {
            CurrentValue = CurrentValue * (dynamic)value;
            return CurrentValue;
        }
        #endregion
    }
}
