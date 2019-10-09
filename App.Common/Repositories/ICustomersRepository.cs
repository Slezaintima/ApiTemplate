using System.Collections.Generic;

namespace App.Repositories
{
    public interface ICustomersRepository
    {
        int Size { get; }
        IEnumerable<string> GetCustomers();
        string GetCustomer(int id);
        void Add(string customers);
        void Update(int i, string newCustomer);
    }
}
