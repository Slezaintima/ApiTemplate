using System;
using System.Collections.Generic;
using System.Text;
using App.Configuration;
using App.Repositories;

namespace App.Customers.Repositories
{
    public class CustomersRepository : ICustomersRepository//, ITransientDependency
    {

        static List<string> customersList = new List<string>();
        public int Size{ get => customersList.Count; }
        public IEnumerable<string> GetCustomers()
        {
            customersList.Add("dasfsds");
            if (Size == 0)
                return null;
            else
            return customersList;
        }

        public string GetCustomer(int id)
        {
            return customersList[id];
        }

        public void Add(string customer)
        {
            customersList.Add(customer);
        }

        public void Update(int i, string newCustomer)
        {
            customersList[i] = newCustomer;
        }
    }
}
