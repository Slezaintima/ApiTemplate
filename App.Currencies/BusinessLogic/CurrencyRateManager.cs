using System;
using System.Collections.Generic;
using System.Text;
using App.Models;
using App.Repositories;

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
            return this._currencyRateRepository.GetCurrencyRate(date, currencyName);
        }
    }
}
