using System;
using System.Collections.Generic;
using System.Text;
using App.Loans.Models;

namespace App.Loans.Interfaces
{
    public interface ILoansRepository
    {
        IEnumerable<string> GetActiveLoansList();

        Loan GetLoanById(int id);
    }
}
