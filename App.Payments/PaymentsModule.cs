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
                builder.UseInMemoryDatabase("PaymentsDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<PaymentsDbContext>().LifestyleTransient());

            InitializeDbContext(container);
        }

        private void InitializeDbContext(IWindsorContainer container)
        {
            using (var context = container.Resolve<PaymentsDbContext>())
            { 
                context.payment.AddRange(new[]
                {
                    new Payment(001,"InProcesing"),
                    new Payment(002,"Success"),
                    new Payment(003,"Success")
                });
                context.SaveChanges();
            }
        }
    }
}
