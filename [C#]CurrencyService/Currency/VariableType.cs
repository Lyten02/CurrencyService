namespace CurrencyService.Currency
{
    public interface VariableType<T> where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable { }
}
