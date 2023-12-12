namespace CurrencyService.Currency
{
    internal interface VariableType<Type> where Type : IComparable, IComparable<Type>, IConvertible, IEquatable<Type>, IFormattable { }
}
