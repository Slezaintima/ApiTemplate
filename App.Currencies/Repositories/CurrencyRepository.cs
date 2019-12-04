using System;
using System.Collections.Generic;
using System.Text;
using App.Models;
using App.Repositories;
using System.Linq;

namespace App.Currencies.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        static List<Currency> Values = new List<Currency>
        {
            new Currency{Id=1, Name = "Dollar", ValuePerDollar=1m, Sign='$'},
            new Currency{Id=2, Name="Euro", ValuePerDollar=0.91m, Sign='€', Date=DateTime.Today},
            new Currency{Id=3, Name="Hryvnia", ValuePerDollar=24.50m, Sign='₴', Date=DateTime.Today},
            new Currency{Id=4, Name="Ruble", ValuePerDollar=63.78m, Sign='₽', Date=DateTime.Today}
        };

        public IEnumerable<Currency> GetAllCurrencies(DateTime date)
        {
            return Values.Where(c => c.Date.Value.Day == date.Day);
        }

        public Currency GetCurrencyById(int id)
        {
            return Values.First(i => i.Id == id);
        }

        public void AddCurrency(Currency currency)
        {
            Values.Add(currency);
        }

        public void DeleteCurrency(Currency currency)
        {
            Values.Remove(currency);
        }

        public void UpdateCurrency(Currency currency)
        {
            var index = Values.FindIndex(c => c.Id == currency.Id);
            Values.Insert(index, currency);
        }
    }
}
