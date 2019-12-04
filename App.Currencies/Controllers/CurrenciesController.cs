using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using App.Currencies.BusinessLogic;
using App.Models;
using System.Linq;

namespace App.Currencies.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrenciesManager currenciesManager;

        public CurrenciesController(ICurrenciesManager currenciesManager)
        {
            this.currenciesManager = currenciesManager;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IEnumerable<Currency> Get(DateTime date)
        {
            var result = this.currenciesManager.GetAllCurrencies(date.Date);
            return result.ToList();
        }

        [HttpGet]
        [Route("GetExchangeRate")]
        public ActionResult<Currency> GetConvertRate(int currencyConvertFromId, decimal amountToConvert, int currencyConvertToId)
        {
            var currencyConvertFrom = this.currenciesManager.GetCurrencyById(currencyConvertFromId);
            currencyConvertFrom.Amount = amountToConvert;
            var currencyConvertTo = this.currenciesManager.GetCurrencyById(currencyConvertToId);

            var result = this.currenciesManager.GetConvertExchangeRate(currencyConvertFrom, currencyConvertTo);
            return result;
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public Currency GetCurrency(int currencyId)
        {
            return this.currenciesManager.GetCurrencyById(currencyId);
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public void AddCurrency(Currency currency)
        {
            this.currenciesManager.AddCurrency(currency);
        }

        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public void DeleteCurrency(int currencyId)
        {
            this.currenciesManager.DeleteCurrency(currencyId);
        }
    }
}
