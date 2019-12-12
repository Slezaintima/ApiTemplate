using System;
using System.Collections.Generic;
using App.Models;

namespace App.Currencies.BusinessLogic
{
    public interface ICurrenciesManager
    {
        IEnumerable<Currency> GetAllCurrencies();
        Currency GetCurrencyById(string name);
        void AddCurrency(Currency currency);
        void UpdateCurrency(string name);
        void DeleteCurrency(string name);
    }
}
