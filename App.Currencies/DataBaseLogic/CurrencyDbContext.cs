using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using App.Models;

namespace App.Currencies.DataBaseLogic
{
    class CurrencyDbContext : DbContext
    {

        public CurrencyDbContext(DbContextOptions<CurrencyDbContext> options) : base(options)
        {
        }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Currency>().HasKey(c => c.CurrencyId);
            builder.Entity<Currency>().Property(c => c.CurrencyId).ValueGeneratedOnAdd();
            builder.Entity<Currency>().Property(c => c.Name).HasMaxLength(45);

            //builder.Entity<Currency>().HasData(
            //    new Currency { CurrencyId = 1, Name = "Dollar", Sign = '$' },
            //    new Currency { CurrencyId = 2, Name = "Euro", Sign = '€' },
            //    new Currency { CurrencyId = 3, Name = "Hryvnia", Sign = '₴' },
            //    new Currency { CurrencyId = 4, Name = "Ruble", Sign = '₽' }
            //    );

            builder.Entity<CurrencyRate>().HasKey(cr => cr.CurrencyRateId);
            builder.Entity<CurrencyRate>().Property(c => c.CurrencyRateId).ValueGeneratedOnAdd();

            //builder.Entity<CurrencyRate>().HasData(
            //    new CurrencyRate { CurrencyRateId = 1, Date = DateTime.Today, ValuePerDollar = 23.90m, CurrencyId = 3 },
            //    new CurrencyRate { CurrencyRateId = 2, Date = DateTime.Today, ValuePerDollar = 0.9m, CurrencyId = 2 },
            //    new CurrencyRate { CurrencyRateId = 3, Date = DateTime.Today, ValuePerDollar = 62m, CurrencyId = 4 }
            //    );
        }
    }
}
