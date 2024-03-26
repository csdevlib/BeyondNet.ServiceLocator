using BeyondNet.ServiceLocator.Interfaces;
using LightInject;

namespace BeyondNet.ServiceLocator.Installer
{
    public static class ServiceContainerExtension
    {
        public static void AddServiceLocator(this IServiceContainer container)
        {
            container.RegisterFrom<ServiceLocatorCompositionRoot>();
        }

        public static IServiceLocator GetServiceLocator(this IServiceContainer container)
        {
            return container.GetInstance<IServiceLocator>();
        }


    }
}
