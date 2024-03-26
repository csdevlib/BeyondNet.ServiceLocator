using BeyondNet.ServiceLocator.Interfaces;
using LightInject;

namespace BeyondNet.ServiceLocator.Installer
{
    public class ServiceLocatorCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            if (serviceRegistry.AvailableServices.All(x => x.ServiceType != typeof(IScopedLocator)))
            {
                serviceRegistry.Register<IScopedLocator>(f => new ServiceLocator(f), new PerContainerLifetime());
            }
            if (serviceRegistry.AvailableServices.All(x => x.ServiceType != typeof(IServiceLocator)))
            {
                serviceRegistry.Register<IServiceLocator>(f => f.GetInstance<IScopedLocator>());
            }
        }
    }
}
