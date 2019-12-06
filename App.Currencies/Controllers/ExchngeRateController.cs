using Microsoft.AspNetCore.Mvc;
using System;
using App.Currencies.BusinessLogic;
using App.Models;

namespace App.Currencies.Controllers
{
    [Route("api/exchangerate")]
    [ApiController]
    public class ExchgeRateController : ControllerBase
    {
        private readonly ICurrenciesManager currenciesManager;
        private readonly ICurrencyRateManager _currencyRateManager;

        public ExchgeRateController(ICurrenciesManager currenciesManager, ICurrencyRateManager currencyRateManager)
        {
            this._currencyRateManager = currencyRateManager;
            this.currenciesManager = currenciesManager;
        }


        [HttpPost]
        [Route("GetExchangeRate")]
        public ActionResult<CurrencyRate> GetCurrency(DateTime date, string name)
        {
            return this._currencyRateManager.GetCurrencyRate(date, name);
        }
    }
}
