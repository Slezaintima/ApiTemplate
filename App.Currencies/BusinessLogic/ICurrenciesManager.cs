using System;
using System.Collections.Generic;
using App.Models;

namespace App.Currencies.BusinessLogic
{
    public interface ICurrenciesManager
    {
        IEnumerable<Currency> GetAllCurrencies(DateTime date);
        Currency GetConvertExchangeRate(Currency currencyConverFrom, Currency currencyConvertTo);
        Currency GetCurrencyById(int id);
        void AddCurrency(Currency currency);
        void UpdateCurrency(int currencyId);
        void DeleteCurrency(int currencyId);
    }
}
