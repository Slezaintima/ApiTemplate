using System;
using System.Collections.Generic;
using System.Text;
using Castle.Windsor;

namespace App.Configuration
{
    // TODO description
    public interface IModule
    {
        void Initialize(IWindsorContainer container);
    }
    // TODO dependent module mechanisms
}
