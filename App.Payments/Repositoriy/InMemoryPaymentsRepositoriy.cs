using App.Configuration;
using App.Models;
using App.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Payments.Repositoriy
{
    public class InMemoryPaymentsRepositoriy : IPaymentsRepository, ITransientDependency
    {
        List<Payment> payments = new List<Payment>
        {
            new Payment(001,"InProcesing"),
            new Payment(002,"Success"),
            new Payment(003,"Success")
        };
        public IEnumerable<Payment> GetPaymentsByStatus(string Status)
        {
           return payments.Where(p => p.Status == Status);
        }
        public List<Payment> CreatePayment(int PaymentNumber, string Status)
        {
            payments.Add(new Payment(PaymentNumber, Status));
            return payments;
        }
        public List<Payment> GetListPayments()
        {
            return payments;
        }
    }
}
