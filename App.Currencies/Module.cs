using System;
using System.Collections.Generic;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using App.Repositories;
using App.Currencies.Repositories;
using App.Currencies.BusinessLogic;
using App.Configuration;

namespace App.Currencies
{
    public class Module : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            container.Register(Component.For<ICurrencyRepository>().ImplementedBy<CurrencyRepository>().LifestyleTransient());
            container.Register(Component.For<ICurrenciesManager>().ImplementedBy<CurrenciesManager>().LifestyleTransient());
        }
    }
}
