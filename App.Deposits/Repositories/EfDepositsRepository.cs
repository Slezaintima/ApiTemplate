using App.Configuration;
using App.Deposits.DataBase;
using App.Deposits.Models;
using App.Deposits.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Deposits.Repositories
{
    public class EfDepositsRepository : IDepositsRepository, IDisposable, ITransientDependency
    {
        private readonly DepositsDbContext dbContext;

        public EfDepositsRepository(DepositsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Deposit deposit)
        {
            dbContext.Deposits.Add(deposit);

            dbContext.SaveChanges();
        }

        public IEnumerable<Deposit> GetAll() => dbContext.Deposits;

        public Deposit GetById(int id)
        {
            var deposit = dbContext.Deposits.Where(x => x.Id == id).FirstOrDefault();

            return deposit;
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }

    }
}
