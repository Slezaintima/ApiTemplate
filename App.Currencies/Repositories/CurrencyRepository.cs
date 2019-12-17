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
    class CurrencyRepository : ICurrencyRepository, IDisposable, ITransientDependency
    {
        private readonly CurrencyDbContext _dbContext;

        public CurrencyRepository(CurrencyDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            return _dbContext.Currencies.ToList();
        }

        public Currency GetCurrencyByName(string name)
        {
            return _dbContext.Currencies.First(i => i.Name == name);
        }

        public void AddCurrency(Currency currency)
        {
            _dbContext.Currencies.Add(currency);
        }

        public void DeleteCurrency(Currency currency)
        {
            _dbContext.Currencies.Remove(currency);
        }

        public void UpdateCurrency(Currency currency)
        {
            _dbContext.Currencies.Update(currency);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
