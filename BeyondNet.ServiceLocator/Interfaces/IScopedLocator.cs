
namespace BeyondNet.ServiceLocator.Interfaces
{
    public interface IScopedLocator : IServiceLocator
    {
        IDisposable BeginScope();
    }
}
