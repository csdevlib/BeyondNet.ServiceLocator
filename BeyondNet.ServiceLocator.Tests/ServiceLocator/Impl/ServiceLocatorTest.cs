using BeyondNet.ServiceLocator.Interfaces;
using BeyondNet.Aop.Tests.ServiceLocator.Interface;
using Shouldly;

namespace BeyondNet.Aop.Tests.ServiceLocator.Impl
{
    public class ServiceLocatorTest
    {
        public void ResolveByTypeWithRegisterdObjectShouldBeAssignableToIDoSomething(IServiceLocator sut)
        {
            var instance = sut.Resolve(typeof(IDoSomething));

            instance.ShouldNotBeNull();

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        public void ResolveByTypeWithoutRegisteredObjectShouldThrowException(IServiceLocator sut)
        {
            Should.Throw<Exception>(() => sut.Resolve(typeof(IDoSomething)));
        }

        public void ResolveWithRegisterdObjectShouldBeAssignableToIDoSomething(IServiceLocator sut)
        {
            var instance = sut.Resolve<IDoSomething>();

            instance.ShouldNotBeNull();

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        public void ResolveWithoutRegisteredObjectShouldThrowException(IServiceLocator sut)
        {
            Should.Throw<Exception>(() => sut.Resolve<IDoSomething>());
        }

        public void ResolveByKeyWithRegisterdObjectShouldBeAssignableToIDoSomething(IServiceLocator sut, string key)
        {
            var instance = sut.Resolve<IDoSomething>(key);

            instance.ShouldNotBeNull();

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        public void ResolveByKeyWithoutRegisteredObjectShouldThrowException(IServiceLocator sut, string key)
        {
            Should.Throw<Exception>(() => sut.Resolve<IDoSomething>(key));
        }

        public void ResolveAllWithRegisterdObjectShouldBeAssignableToIDoSomething(IServiceLocator sut)
        {
            var instance = sut.ResolveAll<IDoSomething>();

            instance.ShouldNotBeNull();

            instance.ShouldBeAssignableTo(typeof(IDoSomething[]));
        }

        public void ResolveByTypeAndKeyWithRegisterdObjectShouldBeAssignableToIDoSomething(IServiceLocator sut, string key)
        {
            var instance = sut.Resolve(typeof(IDoSomething), key);

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        public void ResolveByTypeAndKeyWithRegisterdObjectShouldThrowException(IServiceLocator sut, string key)
        {
            Should.Throw<Exception>(() => sut.Resolve(typeof(IDoSomething), key));
        }

        public void BeginScopeReleaseWithRegisterdObjectShouldBeAssignableToIDoSomething(IScopedLocator sut)
        {
            using (sut.BeginScope())
            {
                var instance1 = sut.Resolve<IDoSomething>();

                var instance2 = sut.Resolve<IDoSomething>();

                instance1.ShouldBeAssignableTo(typeof(IDoSomething));

                instance2.ShouldBeAssignableTo(typeof(IDoSomething));

                instance1.ShouldBeSameAs(instance2);
            }
        }
    }
}