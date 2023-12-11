using CurrencyService;

namespace Lyten.Currency
{
    public class CurrencyServiceEventArgs<Type> : EventArgs, VariableType<Type> where Type : IComparable, IComparable<Type>, IConvertible, IEquatable<Type>, IFormattable
    {
        public CurrencyService<Type> Service { get; private set; }
        public Type OldValue { get; private set; }
        public Type NewValue { get; private set; }

        public CurrencyServiceEventArgs(CurrencyService<Type> service, Type oldValue, Type newValue)
        {
            Service = service;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
