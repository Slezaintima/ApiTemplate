using System;
using System.Collections.Generic;
using System.Text;

namespace App.Example
{
    public interface IAnotherService
    {
        void DoAnything();
    }

    public class AnotherService : IAnotherService
    {
        public void DoAnything()
        {
            // TODO do nothing
        }
    }
}
