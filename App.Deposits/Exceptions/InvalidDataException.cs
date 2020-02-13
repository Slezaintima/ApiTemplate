using System;
using System.Collections.Generic;
using System.Text;

namespace App.Deposits.Exceptions
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message) : base(message)
        {

        }
    }
}
