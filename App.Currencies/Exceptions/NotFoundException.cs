using System;
using System.Collections.Generic;
using System.Text;

namespace App.Currencies.Exceptions
{
    class NotFoundException : ClientException 
    {
        public NotFoundException(string message) : base(message)
        { }
    }
}
