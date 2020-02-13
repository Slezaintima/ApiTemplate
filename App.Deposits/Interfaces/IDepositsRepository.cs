using App.Deposits.Models;
using System.Collections.Generic;


namespace App.Deposits.Interfaces
{
    public interface IDepositsRepository
    {
        IEnumerable<Deposit> GetAll();
        Deposit GetById(int id);
        void Add(Deposit deposit);
    }
}
