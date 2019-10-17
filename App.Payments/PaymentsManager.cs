using App.Configuration;
using App.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Payments
{
    /// <summary>
    /// Example manager class. Which should process business logic, and call required repository
    /// </summary>
    public interface IPaymentsManager
    {
        List<Payment> Filtration(string Status);
        List<Payment> CreatePayment(int ID, string Status);
        List<Payment> GetListPayments();
    }

    public class PaymentsManager: IPaymentsManager, ITransientDependency
    {
        // propoerty should be readonly, so it could not be changed after initialization
        readonly IPaymentsRepository _repository;
        // resolving repository through constructor dependency
        public PaymentsManager(IPaymentsRepository repository)
        {
            _repository = repository;
        }

        public List<Payment> Filtration(string Status)
        {
            return _repository.Filtration(Status);
        }      

        public List<Payment> CreatePayment(int ID, string Status)
        {
            return _repository.CreatePayment(ID, Status);
        }
        public List<Payment> GetListPayments()
        {
            return _repository.GetListPayments();
        }
    }
}
