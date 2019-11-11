using System.Collections.Generic;
using App.Loans.Models;

namespace App.Loans.Interfaces
{
    public interface ILoansManager
    {
        Loan GetItem(int id);

        IEnumerable<string> GetListActiveLoans();
        double GetMoneyLeft(int id);
    }
}
