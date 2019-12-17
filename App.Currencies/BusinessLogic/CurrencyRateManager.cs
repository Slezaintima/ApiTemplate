using System;
using System.Collections.Generic;
using System.Text;
using App.Models;
using App.Repositories;
using App.Currencies.Exceptions;

namespace App.Currencies.BusinessLogic
{
    public class CurrencyRateManager : ICurrencyRateManager
    {
        private readonly ICurrencyRateRepository _currencyRateRepository;

        public CurrencyRateManager(ICurrencyRateRepository repo)
        {
            this._currencyRateRepository = repo;
        }

        public void AddCurrencyRate(CurrencyRate currencyRate)
        {
            this._currencyRateRepository.AddCurrencyRate(currencyRate);
        }

        public CurrencyRate GetCurrencyRate(DateTime date, string currencyName)
        {
            var result = this._currencyRateRepository.GetCurrencyRate(date, currencyName);
            if (result == null)
                throw new NotFoundException("No such currency or exchange rate data for given date");
            return result;
        }
    }
}
