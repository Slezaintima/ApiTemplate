using System;
using System.Collections.Generic;
using System.Text;
using App.Models;
using App.Repositories;
using System.Linq;

namespace App.Currencies.Repositories
{
    class CurrencyRateRepository : ICurrencyRateRepository
    {
        
        public void AddCurrencyRate(CurrencyRate currencyRate)
        {
            StaticResources.CurrencyRateList.Add(currencyRate);
        }

        public void DeleteCurrency(CurrencyRate currencyRate)
        {
            StaticResources.CurrencyRateList.Remove(currencyRate);
        }

        public CurrencyRate GetCurrencyRate(DateTime date, string currencyName)
        {
            var currencyRate = StaticResources.CurrencyRateList
                                  .First(c => c.Currency.Name == currencyName && c.Date == date);

            return currencyRate;
        }
    }
}
