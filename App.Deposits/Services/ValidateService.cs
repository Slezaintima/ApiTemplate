﻿using App.Configuration;
using App.Deposits.Exceptions;
using App.Deposits.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Deposits.Services
{
    public interface IValidateService
    {
        void ValidateCalculateDate(CalculateDTO calculateDTO);

        void ValidateAddDeposit(Deposit createdDeposit);
    }

    public class ValidateService : IValidateService, ITransientDependency
    {
        private bool IsValidDate(CalculateDTO calculateDTO) => calculateDTO.GetDaysAmount() >= 0;

        private bool IsValidInterestRate(Deposit createdDeposit) => createdDeposit.InterestRate >= 0.01m;

        public void ValidateAddDeposit(Deposit createdDeposit)
        {
            if (!IsValidInterestRate(createdDeposit))
            {
                throw new InvalidDataException("Invalid interest rate");
            }
        }

        public void ValidateCalculateDate(CalculateDTO calculateDTO)
        {
            if (!IsValidDate(calculateDTO))
            {
                throw new InvalidDataException("Invalid date");
            }
        }
    }
}
