using System;
using System.Collections.Generic;
using System.Text;
using App.Configuration;
using App.Customers;
using App.Repositories;

namespace App.Customers
{
    public interface ICustomersManager
    {
        IEnumerable<string> GetCustomers();
        string GetCustomer(int id);
        void Add(string customers);
        bool Update(string oldCustomer, string newCustomer);
    }
    public class CustomerManager:ICustomersManager//,ITransientDependency
    {
        readonly ICustomersRepository _repository;
        public CustomerManager(ICustomersRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<string> GetCustomers()
        {
            return _repository.GetCustomers();
        }

        public string GetCustomer(int id)
        {
            return _repository.GetCustomer(id);
        }

        public void Add(string  customer)
        {
            _repository.Add(customer);
        }
        public bool Update(string oldCustomer, string newCustomer)
        {
            bool isExsist = false;
            int index = -1;
            for(int i = 0; i< _repository.Size; i++)
            {
                if (_repository.GetCustomer(i) == oldCustomer)
                {
                    isExsist = true;
                    index = i;
                    break;
                }
            }
            if (isExsist)
                _repository.Update(index, newCustomer);
            return isExsist;
        }
    }
}
