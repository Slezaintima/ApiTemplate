using System;
using System.Collections.Generic;
using System.Text;
using App.Currencies.Repositories;
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

        public IEnumerable<Currency> GetAllCurrencies(DateTime date)
        {
            return this.currencyRepository.GetAllCurrencies(date);
        }

        public Currency GetConvertExchangeRate(Currency currencyConvertFrom, Currency currencyConvertTo)
        {
            decimal result = (currencyConvertTo.ValuePerDollar / currencyConvertFrom.ValuePerDollar) * currencyConvertFrom.Amount.Value;
            currencyConvertTo.Amount = result;
            return currencyConvertTo;
        }

        public Currency GetCurrencyById(int id)
        {
            return this.currencyRepository.GetCurrencyById(id);
        }

        public void AddCurrency(Currency currency)
        {
            this.currencyRepository.AddCurrency(currency);
        }

        public void DeleteCurrency(int currencyId)
        {
            var currency = this.currencyRepository.GetCurrencyById(currencyId);
            this.currencyRepository.DeleteCurrency(currency);
        }

        public void UpdateCurrency(int currencyId)
        {
            var currency = this.currencyRepository.GetCurrencyById(currencyId);
            this.currencyRepository.UpdateCurrency(currency);
        }
    }
}
