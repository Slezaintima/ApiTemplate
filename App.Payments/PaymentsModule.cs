using App.Configuration;
using App.Models;
using App.Payments.Database;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Payments
{
    public class PaymentsModule : IModule
    {
        /// <param name="container"></param>
        public void Initialize(IWindsorContainer container)
        {
            RegisterDbContext(container);
        }

        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<PaymentsDbContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<PaymentsDbContext>();
                // for test purpose we are using InMemory database
                builder.UseInMemoryDatabase("PaymentsDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<PaymentsDbContext>().LifestyleTransient());

            InitializeDbContext(container);
        }

        private void InitializeDbContext(IWindsorContainer container)
        {
            // DbContext object is Disposable, so it is needed to use "using" constraction
            using (var context = container.Resolve<PaymentsDbContext>())
            {
                // add values to the context (without saving)
                context.payment.AddRange(new[]
                {
                    new Payment(001,"InProcesing"),
                    new Payment(002,"Success"),
                    new Payment(003,"Success")
                });

                // save changes in the context
                context.SaveChanges();
            }
        }
    }
}
