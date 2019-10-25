using App.Configuration;
using App.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Payments
{
    public interface IPaymentsManager
    {
        IEnumerable<Payment> GetPaymentsByStatus(string Status);
        List<Payment> CreatePayment(int p_number, string Status);
        List<Payment> GetListPayments();
    }
    public class PaymentsManager: IPaymentsManager, ITransientDependency
    {
        
        readonly IPaymentsRepository _repository;    
        public PaymentsManager(IPaymentsRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Payment> GetPaymentsByStatus(string Status)
        {
            return _repository.GetPaymentsByStatus(Status);
        }
        public List<Payment> CreatePayment(int p_number, string Status)
        {
            return _repository.CreatePayment(p_number, Status);
        }
        public List<Payment> GetListPayments()
        {
            return _repository.GetListPayments();
        }
    }
}
