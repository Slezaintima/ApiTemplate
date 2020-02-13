using App.Configuration;
using App.Deposits.Exceptions;
using App.Deposits.Models;
using App.Deposits.Interfaces;

namespace App.Deposits.Services
{
   
    public class ValidationService : IValidationService, ITransientDependency
    {
        private bool IsValidDate(Calculation calculation) => calculation.GetDaysAmount() >= 0;

        private bool IsValidInterestRate(Deposit createdDeposit) => createdDeposit.InterestRate >= 0.01m;

        public void ValidateAddDeposit(Deposit createdDeposit)
        {
            if (!IsValidInterestRate(createdDeposit))
            {
                throw new InvalidDataException("Invalid interest rate");
            }
        }

        public void ValidateCalculateDate(Calculation calculation)
        {
            if (!IsValidDate(calculation))
            {
                throw new InvalidDataException("Invalid date");
            }
        }
    }
}
