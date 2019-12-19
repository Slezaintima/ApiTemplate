using System;
using System.Collections.Generic;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using App.Repositories;
using App.Currencies.Repositories;
using App.Currencies.BusinessLogic;
using App.Configuration;
using App.Currencies.DataBaseLogic;
using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Currencies
{
    public class Module : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            container.Register(Component.For<ICurrencyRepository>().ImplementedBy<CurrencyRepository>().LifestyleTransient());
            container.Register(Component.For<ICurrenciesManager>().ImplementedBy<CurrenciesManager>().LifestyleTransient());
            container.Register(Component.For<ICurrencyRateRepository>().ImplementedBy<CurrencyRateRepository>().LifestyleTransient());
            container.Register(Component.For<ICurrencyRateManager>().ImplementedBy<CurrencyRateManager>().LifestyleTransient());

            RegisterDbContext(container);


        }

        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<CurrencyDbContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<CurrencyDbContext>();
                // for test purpose we are using InMemory database
                builder.UseInMemoryDatabase("CurrencyDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<CurrencyDbContext>().LifestyleTransient());

            InitializeDbContext(container);
        }

        private void InitializeDbContext(IWindsorContainer container)
        {
            // DbContext object is Disposable, so it is needed to use "using" constraction
            using (var context = container.Resolve<CurrencyDbContext>())
            {
                // add values to the context (without saving)
                context.Currencies.AddRange(new[]
                {
                    new Currency { CurrencyId = 1, Name = "Dollar", Sign = '$' },
                    new Currency { CurrencyId = 2, Name = "Euro", Sign = '€' },
                    new Currency { CurrencyId = 3, Name = "Hryvnia", Sign = '₴' },
                    new Currency { CurrencyId = 4, Name = "Ruble", Sign = '₽' }
                });

                context.CurrencyRates.AddRange(new[]{
                    new CurrencyRate { CurrencyRateId = 1, Date = DateTime.Today, ValuePerDollar = 23.90m, CurrencyId = 3 },
                    new CurrencyRate { CurrencyRateId = 2, Date = DateTime.Today, ValuePerDollar = 0.9m, CurrencyId = 2 },
                    new CurrencyRate { CurrencyRateId = 3, Date = DateTime.Today, ValuePerDollar = 62m, CurrencyId = 4 }
                });

                // save changes in the context
                context.SaveChanges();
            }
        }
    }
}
