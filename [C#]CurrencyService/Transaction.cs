using CurrencyService;

public class Transaction<Type> : VariableType<Type> where Type : IComparable, IComparable<Type>, IConvertible, IEquatable<Type>, IFormattable
{
    public string Name { get; private set; }
    public ulong Id { get; set; }
    public Type NewValue { get; set; }
    public Type OldValue { get; set; }
    public Type CurrentValue { get; set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string Region { get; private set; }
    public string PostalCode { get; private set; }
    public DateTime TransactionDate { get; private set; }

    public Transaction(string name, ulong id, string address, string city, string region, string postalcode, Type newValue, Type oldValue, Type currentValue) 
    {
        Name = name;
        Id = id;
        Address = address;
        City = city;
        Region = region;
        PostalCode = postalcode;
        TransactionDate = DateTime.Now;
        NewValue = newValue;
        OldValue = oldValue;
        CurrentValue = currentValue;
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
}
