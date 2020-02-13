using App.Configuration;
using App.Deposits.Models;
using System;
using System.Collections.Generic;
using App.Deposits.Interfaces;
using System.Linq;

namespace App.Deposits
{
    public class DepositsManager : IDepositsManager, ITransientDependency
    {
        private readonly IDepositsRepository depositsRepository;

        public DepositsManager(IDepositsRepository depositsRepository)
        {
            this.depositsRepository = depositsRepository;
        }

        public void AddDeposit(Deposit newDeposit)
        {

            var deposit = new Deposit
            {
                Id = newDeposit.Id,
                Name = newDeposit.Name,
                InterestRate = newDeposit.InterestRate,
            };

            depositsRepository.Add(deposit);
        }

        public Deposit GetDepositById(int id)
        {
            var deposit = depositsRepository.GetById(id);
            return deposit;
        }

        public IEnumerable<Deposit> GetAllDeposits()
        {
            return depositsRepository.GetAll();
        }

        public decimal AccrualСalculation(int depositId, Calculation calculation)
        {
            var deposit = depositsRepository.GetById(depositId);

            decimal sum = calculation.StartSum + calculation.StartSum * deposit.InterestRate * calculation.GetDaysAmount() / 365;

            return sum;
        }
    }
}
