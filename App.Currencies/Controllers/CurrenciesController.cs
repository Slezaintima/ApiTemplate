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
            var result = this.currenciesManager.GetAllCurrencies();
            return result.ToList();
        }

        [HttpPost]
        [Route("GetCurrencyById")]
        public Currency GetCurrency(string name)
        {
            return this.currenciesManager.GetCurrencyById(name);
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public void AddCurrency(Currency currency)
        {
            this.currenciesManager.AddCurrency(currency);
        }

        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public void DeleteCurrency(string name)
        {
            this.currenciesManager.DeleteCurrency(name);
        }
    }
}
