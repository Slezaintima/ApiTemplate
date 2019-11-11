using System.Collections.Generic;
using App.Loans.Models;

namespace App.Loans.Interfaces
{
    public interface ILoansRepository
    {
        IEnumerable<string> GetActiveLoansList();

        Loan GetLoanById(int id);
    }
}
