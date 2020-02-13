using App.Configuration;
using App.Deposits.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using App.Deposits.Interfaces;
using App.Deposits.Exceptions;
using System.Linq;

namespace App.Deposits
{
    public class DepositsManager : IDepositsManager, ITransientDependency
    {
        private readonly IDepositsRepository depositsRepository;
        private readonly IValidationService validationService;
        private readonly ILogger<DepositsManager> logger;

        public DepositsManager(IDepositsRepository depositsRepository, IValidationService validationService, ILogger<DepositsManager> logger)
        {
            this.depositsRepository = depositsRepository;
            this.logger = logger;
            this.validationService = validationService;
        }

        public void AddDeposit(Deposit newDeposit)
        {
            logger.LogInformation($"Call AddDeposit");

            validationService.ValidateAddDeposit(newDeposit);

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
            logger.LogInformation($"Call GetDepositById");

            var deposit = depositsRepository.GetById(id);

            if (deposit == null)
            {
                throw new EntityNotFoundException(typeof(Deposit), id);
            }

            return deposit;
        }

        public IEnumerable<Deposit> GetAllDeposits()
        {
            logger.LogInformation($"Call GetAllDeposit");

            return depositsRepository.GetAll();
        }

        public decimal AccrualСalculation(int depositId, Calculation calculation)
        {
            logger.LogInformation($"Call AccrualСalculation");

            var deposit = depositsRepository.GetById(depositId);

            validationService.ValidateCalculateDate(calculation);

            decimal sum = calculation.StartSum + calculation.StartSum * deposit.InterestRate * calculation.GetDaysAmount() / 365;

            return sum;
        }
    }
}
