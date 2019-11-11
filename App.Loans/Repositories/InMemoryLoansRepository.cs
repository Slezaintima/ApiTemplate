using System.Collections.Generic;
using App.Configuration;
using App.Loans.Interfaces;
using App.Loans.Models;

namespace App.Loans.Repositories
{
    public class InMemoryLoansRepository : ILoansRepository, ISingletoneDependency
    {
        private string[] str = new string[3];
        private Loan[] loans =
        {
            new Loan(10000, 10, 24),
            new Loan(28860, 3, 6),
            new Loan(5000, 0.01, 3)
        };

        public InMemoryLoansRepository()
        {
            str[0] = loans[0].ToString();
            str[1] = loans[1].ToString();
            str[2] = loans[2].ToString();
        }

        public IEnumerable<string> GetActiveLoansList() => str;

        public Loan GetLoanById(int id) => loans[id];
        
    }
}
