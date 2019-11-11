using System.Collections.Generic;
using App.Configuration;
using App.Loans.Models;
using App.Loans.Interfaces;

namespace App.Loans.Services
{
    public class LoansManager : ILoansManager, ITransientDependency
    {
        readonly ILoansRepository _repository;

        public Loan GetItem(int id) => _repository.GetLoanById(id);

        public LoansManager(ILoansRepository repository) =>  _repository = repository;

        public double GetMoneyLeft(int id) => _repository.GetLoanById(id).moneyLeft;

        public IEnumerable<string> GetListActiveLoans() => _repository.GetActiveLoansList();
    }
}
