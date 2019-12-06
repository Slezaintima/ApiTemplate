using System;
using System.Collections.Generic;
using System.Text;
using App.Models;
using App.Repositories;
using System.Linq;

namespace App.Currencies.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public IEnumerable<Currency> GetAllCurrencies()
        {
            return StaticResources.CurrencyList;
        }

        public Currency GetCurrencyByName(string name)
        {
            return StaticResources.CurrencyList.First(i => i.Name == name);
        }

        public void AddCurrency(Currency currency)
        {
            StaticResources.CurrencyList.Add(currency);
        }

        public void DeleteCurrency(Currency currency)
        {
            StaticResources.CurrencyList.Remove(currency);
        }

        public void UpdateCurrency(Currency currency)
        {
            var index = StaticResources.CurrencyList.FindIndex(c => c.Name == currency.Name);
            StaticResources.CurrencyList.Insert(index, currency);
        }
    }
}
