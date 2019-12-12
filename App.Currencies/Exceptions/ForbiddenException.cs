using System;
using System.Collections.Generic;
using System.Text;

namespace App.Currencies.Exceptions
{
    class ForbiddenException : ClientException
    {
        public ForbiddenException(string message) : base(message)
        { }
    }
}
