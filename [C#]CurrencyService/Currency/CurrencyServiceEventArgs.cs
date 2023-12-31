﻿using System.Numerics;

namespace CurrencyService.Currency
{
    public class CurrencyServiceEventArgs<T> : EventArgs, VariableType<T> where T : INumber<T>
    {
        public CurrencyService<T> Service { get; private set; }
        public T OldValue { get; private set; }
        public T NewValue { get; private set; }

        public CurrencyServiceEventArgs(CurrencyService<T> service, T oldValue, T newValue)
        {
            Service = service;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
