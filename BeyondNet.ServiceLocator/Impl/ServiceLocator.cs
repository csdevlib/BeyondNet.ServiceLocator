
using BeyondNet.ServiceLocator.Interfaces;
using BeyondNet.ServiceLocator.Models;


namespace BeyondNet.ServiceLocator.Impl
{
    public class ServiceLocator : IServiceLocator
    {
        public static IServiceLocator? Current;

        private readonly IList<Record> _records;

        public void Register(Type component, object instance)
        {
            ArgumentNullException.ThrowIfNull(component, nameof(component));    
            ArgumentException.ThrowIfNullOrEmpty(component.FullName, nameof(component.FullName));

            _records.Add(new Record(component, instance, component.FullName));
        }

        public void Register(Type component, object instance, string name)
        {
            _records.Add(new Record(component, instance, name));
        }

        public ServiceLocator()
        {
            _records = new List<Record>();
        }


        public TSource Resolve<TSource>() where TSource : class
        {
            foreach (var o in _records.Where(o => o.Component == typeof(TSource)))
            {
                return (TSource)o.Implementation;
                
            }
            throw new ArgumentException($"It is not posible to get a instance of {typeof(TSource).Name}");
        }

        public TSource Resolve<TSource>(string name) where TSource : class
        {
            foreach (var o in _records.Where(o => o.Component == typeof(TSource) && o.Name == name))
            {
                return (TSource)o.Implementation;
            }

            throw new ArgumentException($"It is not posible to get a instance of {typeof(TSource).Name}");
        }

        public TSource[] ResolveAll<TSource>() where TSource : class
        {
            return _records.Where(o => o.Component == typeof(TSource)).Select(x => (TSource)x.Implementation).ToArray();
        }

        public object Resolve(Type service)
        {
            ArgumentNullException.ThrowIfNull(service, nameof(service));

            foreach (var o in _records.Where(o => o.Component == service))
            {
                return o.Implementation;
            }
            throw new ArgumentException($"It is not posible to get a instance of {service.Name}");
        }

        public object Resolve(Type service, string name)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));
            ArgumentNullException.ThrowIfNull(service, nameof(service));

            foreach (var o in _records.Where(o => o.Component == service && o.Name == name))
            {
                return o.Implementation;
            }
            throw new ArgumentException($"It is not posible to get a instance of {service.Name}");
        }
    }
}
