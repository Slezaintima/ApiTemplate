using System;
using System.Collections.Generic;
using System.Text;
using App.Deposits.Models;

namespace App.Deposits.Interfaces
{
    public interface IDepositsManager
    {
        Deposit GetDepositById(int id);

        void AddDeposit(Deposit deposit);

        IEnumerable<Deposit> GetAllDeposits();

        decimal AccrualСalculation(int depositId, Calculation calculation);
    }
}
