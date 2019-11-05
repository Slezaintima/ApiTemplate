using App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Customers.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public Customer Customer { get; private set; }
        public CustomerNotFoundException(Customer customer)
        {
            Customer = customer;
        }
    }
}
