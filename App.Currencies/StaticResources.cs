using System;
using System.Collections.Generic;
using System.Text;
using App.Models;
using System.Linq;

namespace App.Currencies
{
    public static class StaticResources
    {

        static Currency dollar = new Currency { Name = "Dollar", Sign = '$' };
        static Currency euro = new Currency { Name = "Euro", Sign = '€' };
        static Currency hryvnia = new Currency { Name = "Hryvnia", Sign = '₴' };
        static Currency ruble = new Currency { Name = "Ruble", Sign = '₽' };

        public static List<Currency> CurrencyList = new List<Currency>
        {
            dollar,
            euro,
            hryvnia,
            ruble
        };

        public static List<CurrencyRate> CurrencyRateList = new List<CurrencyRate>
        {
            new CurrencyRate{Currency = hryvnia, Date = DateTime.Today, ValuePerDollar = 23.90m},
            new CurrencyRate{Currency = euro, Date = DateTime.Today, ValuePerDollar = 0.9m},
            new CurrencyRate{Currency = ruble, Date = DateTime.Today, ValuePerDollar = 62m},
        };
    }
}
