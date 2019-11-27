using App.Configuration;
using App.Models;
using App.Payments.Database;
using App.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Payments.Repository
{
    public class EfPaymentsRepository : IPaymentsRepository, IDisposable, ITransientDependency
    {
        private readonly PaymentsDbContext _dbContext;
        public EfPaymentsRepository(PaymentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Payment> CreatePayment(int PaymentNumber, string Status)
        {
            _dbContext.payment.Add(new Payment(PaymentNumber, Status));
            return _dbContext.payment.ToList();
        }

        public List<Payment> GetListPayments()
        {
            return _dbContext.payment.ToList();
        }

        public IEnumerable<Payment> GetPaymentsByStatus(string Status)
        {
            var payment = _dbContext.payment.ToList();
            return payment;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
