using App.Configuration;
using App.Deposits.Models;
using App.Deposits.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace App.Deposits.Repositories
{
    public class DepositsRepository 
    {
        private static readonly List<Deposit> deposits = Init();

        private static List<Deposit> Init()
        {
            var deposits = new List<Deposit>();

            deposits.Add(new Deposit { Id = 1, Name = "SomeDeposit", InterestRate = 0.15m });
            deposits.Add(new Deposit { Id = 2, Name = "Test", InterestRate = 0.20m });
            deposits.Add(new Deposit { Id = 3, Name = "Test2", InterestRate = 0.25m });

            return deposits;
        }
        public void Add(Deposit deposit)
        {
            deposits.Add(deposit);
        }
        public IEnumerable<Deposit> GetAll()
        {
            return deposits;
        }

        public Deposit GetById(int id)
        {
            var deposit = deposits.Where(x => x.Id == id).FirstOrDefault();

            return deposit;
        }

    }
}
