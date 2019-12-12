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
        [ApiExplorerSettings(IgnoreApi = true)]
        public IEnumerable<Currency> Get()
        {
            var result = this.currenciesManager.GetAllCurrencies();
            return result.ToList();
        }

        [HttpPost]
        [Route("GetCurrencyById")]
        public ActionResult<Currency> GetCurrency(string name)
        {
            throw new ForbiddenException("you don't have permission for such action");
            //return this.currenciesManager.GetCurrencyById(name);
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
