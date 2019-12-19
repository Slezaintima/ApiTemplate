using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using App.Currencies.BusinessLogic;
using App.Models;
using System.Linq;
using App.Currencies.Exceptions;
using App.Currencies.Filters;

namespace App.Currencies.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    [TypeFilter(typeof(CurrencyExceptionFilter), Arguments = new object[] { nameof(CurrenciesController) })]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrenciesManager currenciesManager;

        public CurrenciesController(ICurrenciesManager currenciesManager)
        {
            this.currenciesManager = currenciesManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Currency>> Get()
        {
            var result = this.currenciesManager.GetAllCurrencies();
            return result.ToList();
        }

        [HttpPost]
        [Route("GetCurrencyById")]
        public ActionResult<Currency> GetCurrency(string name)
        {
            return this.currenciesManager.GetCurrencyById(name);
        }

        [HttpPost]
        public ActionResult AddCurrency(Currency currency)
        {
            this.currenciesManager.AddCurrency(currency);
            return Ok(currency);
        }

        [HttpDelete]
        public ActionResult DeleteCurrency(string name)
        {
            this.currenciesManager.DeleteCurrency(name);
            return Ok();
        }
    }
}
