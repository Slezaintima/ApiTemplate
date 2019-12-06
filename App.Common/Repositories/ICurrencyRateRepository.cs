using System;
using System.Collections.Generic;
using System.Text;
using App.Models;

namespace App.Repositories
{
    public interface ICurrencyRateRepository
    {
        CurrencyRate GetCurrencyRate(DateTime date, string CurrencyName);
        void AddCurrencyRate(CurrencyRate currencyRate);
        void DeleteCurrency(CurrencyRate currencyRate);
    }
}
