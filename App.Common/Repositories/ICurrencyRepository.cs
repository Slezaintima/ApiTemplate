using System;
using System.Collections.Generic;
using App.Models;

namespace App.Repositories
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetAllCurrencies(DateTime date);
        Currency GetCurrencyById(int id);
        void AddCurrency(Currency currency);
        void UpdateCurrency(Currency currency);
        void DeleteCurrency(Currency currency);
    }
}
