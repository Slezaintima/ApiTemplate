using App.Configuration;
using App.Deposits.Models;
using App.Deposits.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using App.Deposits.Interfaces;
using System.Linq;
using App.Deposits.Services;
using App.Deposits.Exceptions;
using Microsoft.Extensions.Logging;

namespace App.Deposits
{
    public class DepositsManager : IDepositsManager, ITransientDependency
    {
        private readonly IDepositsRepository depositsRepository;
        private readonly IValidateService validateService;
        private readonly ILogger<DepositsManager> logger;

        public DepositsManager(IDepositsRepository depositsRepository, IValidateService validateService, ILogger<DepositsManager> logger)
        {
            this.depositsRepository = depositsRepository;
            this.validateService = validateService;
            this.logger = logger;
        }

        public void AddDeposit(Deposit newDeposit)
        {
            logger.LogInformation($"Call AddDeposit");

            validateService.ValidateAddDeposit(newDeposit);

            var deposit = new Deposit
            {
                // Delete after adding Entity Framework 
                Id = newDeposit.Id,
                //=================
                Name = newDeposit.Name,
                InterestRate = newDeposit.InterestRate,
            };

            depositsRepository.Add(deposit);
        }
              
        public Deposit GetDepositById(int id)
        {
            logger.LogInformation($"Call GetDepositById");

            var deposit = depositsRepository.GetById(id); // Getting an entity from DataBase

            if (deposit == null) // Check if it exists
            {
                throw new EntityNotExistException(typeof (Deposit), id); 
            }

            return deposit;
        }

        public IEnumerable<Deposit> GetAllDeposits()
        {
            logger.LogInformation($"Call GetAllDeposit");

            return depositsRepository.GetAll();
        }

        public decimal AccrualСalculation(int depositId, CalculateDTO calculateDTO)
        {
            logger.LogInformation($"Call AccrualСalculation");

            var deposit = depositsRepository.GetById(depositId);

            validateService.ValidateCalculateDate(calculateDTO);

            decimal sum = calculateDTO.StartSum + calculateDTO.StartSum * deposit.InterestRate * calculateDTO.GetDaysAmount() / 365;

            return sum;
        }
    }
}
