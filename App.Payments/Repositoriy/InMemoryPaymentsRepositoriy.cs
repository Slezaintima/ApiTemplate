using App.Configuration;
using App.Repositories;
using System;
using System.Collections.Generic;
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
        public List<Payment> Filtration(string Status)
        {
            List<Payment> FiltrPayments = new List<Payment>();
            for(int i=1; i<payments.Count; i++)
            {
                if (payments[i].Status == Status)
                {
                    FiltrPayments.Add(payments[i]);
                }
            }
            return FiltrPayments;
        }
        public List<Payment> CreatePayment(int ID, string Status)
        {
            payments.Add(new Payment(ID, Status));
            return payments;
        }
        public List<Payment> GetListPayments()
        {
            return payments;
        }
    }
}
