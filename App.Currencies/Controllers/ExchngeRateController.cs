using Microsoft.AspNetCore.Mvc;
using System;
using App.Currencies.BusinessLogic;
using App.Models;
using App.Currencies.Exceptions;
using System.Linq;
using Microsoft.Extensions.Logging;
using App.Currencies.Filters;

namespace App.Currencies.Controllers
{
    [Route("api/exchangerate")]
    [ApiController]
    [TypeFilter(typeof(CurrencyExceptionFilter), Arguments = new object[] { nameof(CurrenciesController) })]
    public class ExchgeRateController : ControllerBase
    {
        private readonly ILogger<CurrenciesController> _logger;
        private readonly ICurrenciesManager currenciesManager;
        private readonly ICurrencyRateManager _currencyRateManager;

        public ExchgeRateController(ICurrenciesManager currenciesManager, ICurrencyRateManager currencyRateManager, ILogger<CurrenciesController> logger)
        {
            this._logger = logger;
            this._currencyRateManager = currencyRateManager;
            this.currenciesManager = currenciesManager;
        }


        [HttpPost]
        [Route("GetExchangeRate")]
        public ActionResult<CurrencyRate> GetCurrencyRate(DateTime date, string name)
        {
            _logger.LogInformation("Call GetCurrencyRate method");
            return this._currencyRateManager.GetCurrencyRate(date, name);
        }
    }
}
