using System;
using System.Collections.Generic;
using System.Text;
using App.Models;

namespace App.Currencies.BusinessLogic
{
    public interface ICurrencyRateManager
    {
        void AddCurrencyRate(CurrencyRate currencyRate);
        CurrencyRate GetCurrencyRate(DateTime date, string CurrencyName);
    }
}
