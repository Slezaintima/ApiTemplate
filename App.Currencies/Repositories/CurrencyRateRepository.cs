using System;
using System.Collections.Generic;
using System.Text;
using App.Models;
using App.Repositories;
using System.Linq;
using App.Currencies.DataBaseLogic;
using App.Configuration;

namespace App.Currencies.Repositories
{
    class CurrencyRateRepository : ICurrencyRateRepository, IDisposable, ITransientDependency
    {
        private readonly CurrencyDbContext _dbContext;

        public CurrencyRateRepository(CurrencyDbContext context)
        {
            _dbContext = context;
        }

        public void AddCurrencyRate(CurrencyRate currencyRate)
        {
            _dbContext.Add(currencyRate);
        }

        public void DeleteCurrency(CurrencyRate currencyRate)
        {
            _dbContext.Remove(currencyRate);
        }

        public CurrencyRate GetCurrencyRate(DateTime date, string currencyName)
        {
            var currencyRate = _dbContext.CurrencyRates
                                  .FirstOrDefault(c => c.Currency.Name == currencyName && c.Date == date);

            return currencyRate;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
