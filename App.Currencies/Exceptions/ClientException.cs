using System;
using System.Collections.Generic;
using System.Text;

namespace App.Currencies.Exceptions
{
    class ClientException : Exception
    {
        public ClientException(string message) : base(message)
        { }
    }
}
