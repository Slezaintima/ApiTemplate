using App.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace App.Example
{
    public class ExampleModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            // example of manually registered componentS
            container.Register(Component.For<IAnotherService>().ImplementedBy<AnotherService>().LifestyleTransient());
        }
    }
}
