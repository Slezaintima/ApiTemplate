using System;
using System.Collections.Generic;
using App.Models;
using App.Repositories;

namespace App.Currencies.BusinessLogic
{
   
    public class CurrenciesManager : ICurrenciesManager
    {
        private readonly ICurrencyRepository currencyRepository;

        public CurrenciesManager(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            return this.currencyRepository.GetAllCurrencies();
        }

        public Currency GetCurrencyById(string name)
        {
            return this.currencyRepository.GetCurrencyByName(name);
        }

        public void AddCurrency(Currency currency)
        {
            this.currencyRepository.AddCurrency(currency);
        }

        public void DeleteCurrency(string name)
        {
            var currency = this.currencyRepository.GetCurrencyByName(name);
            this.currencyRepository.DeleteCurrency(currency);
        }

        public void UpdateCurrency(string name)
        {
            var currency = this.currencyRepository.GetCurrencyByName(name);
            this.currencyRepository.UpdateCurrency(currency);
        }
    }
}
