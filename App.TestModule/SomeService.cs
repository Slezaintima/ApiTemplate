using System;
using System.Collections.Generic;
using System.Text;
using App.Configuration;

namespace App.Example
{
    public interface ISomeService
    {
        void DoSmth();
    }
    public class SomeService : ISomeService, ITransientDependency
    {
        public void DoSmth()
        {
            // AZAZA, do nothing
        }
    }
}
