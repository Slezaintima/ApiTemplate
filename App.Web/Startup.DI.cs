using System;
using System.Reflection;
using App.Configuration;
using App.Example.Filters;
using Castle.Facilities.AspNetCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace App.Web
{
    // TODO add description
    public partial class Startup
    {
        static readonly WindsorContainer Container = new WindsorContainer();

        // TODO add description
        IServiceProvider GetServiceProvider(IServiceCollection services)
        {
            var container = Container;

            Container.AddFacility<AspNetCoreFacility>(f => f.CrossWiresInto(services));

            RegisterComponents(container);

            InitializeModules(container);

            Container.Register(Component.For<ExampleAsyncExceptionFilter>().ImplementedBy<ExampleAsyncExceptionFilter>().LifestyleTransient().CrossWired());

            var windsorServiceProvider = services.AddWindsor(container);

            var filter = Container.Resolve<ExampleAsyncExceptionFilter>();

            return windsorServiceProvider;
        }

        void RegisterComponents(WindsorContainer container)
        {
            RegisterTransientServices(container);

            RegisterSingletoneServices(container);

            RegisterModules(container);
        }

        void RegisterTransientServices(WindsorContainer container)
        {
            container.Register(GetFromAssemblyDescriptor()
                .BasedOn<ITransientDependency>()
                .WithService.Self()
                .WithService.AllInterfaces()
                .LifestyleTransient());
        }

        void RegisterSingletoneServices(WindsorContainer container)
        {
            container.Register(GetFromAssemblyDescriptor()
                .BasedOn<ISingletoneDependency>()
                .WithService.Self()
                .WithService.AllInterfaces()
                .LifestyleSingleton());
        }

        void RegisterModules(WindsorContainer container)
        {
            container.Register(GetFromAssemblyDescriptor()
                .BasedOn<IModule>()
                .WithService.Self()
                .WithService.FromInterface(typeof(IModule))
                .LifestyleSingleton());
        }

        FromAssemblyDescriptor GetFromAssemblyDescriptor() => Classes.FromAssemblyInThisApplication(Assembly.GetEntryAssembly());

        // TODO add logging
        void InitializeModules(WindsorContainer container)
        {
            var modules = container.ResolveAll<IModule>();

            foreach(var module in modules)
            {
                module.Initialize(container);
            }
        }
    }
}
