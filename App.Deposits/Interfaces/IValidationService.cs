using System;
using System.Collections.Generic;
using System.Text;
using App.Deposits.Models;
namespace App.Deposits.Interfaces
{
    public interface IValidationService
    {
        void ValidateCalculateDate(Calculation calculation);

        void ValidateAddDeposit(Deposit createdDeposit);
    }

}
