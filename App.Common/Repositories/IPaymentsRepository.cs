using System.Collections.Generic;

namespace App.Repositories
{
    public interface IPaymentsRepository
    {
        List<Payment> Filtration(string Status);
        List<Payment> CreatePayment(int ID, string Status);
        List<Payment> GetListPayments();
    }
}
