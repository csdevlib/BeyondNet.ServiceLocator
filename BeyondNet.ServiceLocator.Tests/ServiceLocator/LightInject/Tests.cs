using LightInject;
using BeyondNet.ServiceLocator.Interfaces;
using BeyondNet.Aop.Tests.ServiceLocator.Impl;
using BeyondNet.Aop.Tests.ServiceLocator.Interface;
using BeyondNet.ServiceLocator.Installer;

namespace BeyondNet.ServiceLocator.Tests.LightInject
{
    [TestClass]
    public class Tests
    {
        private ServiceContainer container;

        private IServiceLocator sut;

        private ServiceLocatorTest test;

        [TestInitialize]
        public void Setup()
        {
            container = new ServiceContainer();

            container.AddServiceLocator();

            sut = container.GetServiceLocator();

            test = new ServiceLocatorTest();
        }

        [TestMethod]
        public void ResolveByTypeWithRegisterdObjectShouldBeAssignableToIDoSomething()
        {
            container.Register<IDoSomething, DoSomething>();

            test.ResolveByTypeWithRegisterdObjectShouldBeAssignableToIDoSomething(sut);
        }

        [TestMethod]
        public void ResolveByTypeWithoutRegisteredObjectShouldThrowException()
        {
            test.ResolveByTypeWithoutRegisteredObjectShouldThrowException(sut);
        }

        [TestMethod]
        public void ResolveWithRegisterdObjectShouldBeAssignableToIDoSomething()
        {

            container.Register<IDoSomething, DoSomething>();

            test.ResolveWithRegisterdObjectShouldBeAssignableToIDoSomething(sut);
        }

        [TestMethod]
        public void ResolveWithoutRegisteredObjectShouldThrowException()
        {
            test.ResolveWithoutRegisteredObjectShouldThrowException(sut);
        }

        [TestMethod]
        public void ResolveByKeyWithRegisterdObjectShouldBeAssignableToIDoSomething()
        {
            container.Register<IDoSomething, DoSomething>("key");

            test.ResolveByKeyWithRegisterdObjectShouldBeAssignableToIDoSomething(sut,"key");
        }

        [TestMethod]
        public void ResolveByKeyWithoutRegisteredObjectShouldThrowException()
        {
            test.ResolveByKeyWithoutRegisteredObjectShouldThrowException(sut, "key");
        }

        [TestMethod]
        public void ResolveAllWithRegisterdObjectShouldBeAssignableToIDoSomething()
        {
            container.Register<IDoSomething, DoSomething>();

            test.ResolveAllWithRegisterdObjectShouldBeAssignableToIDoSomething(sut);
        }

        [TestMethod]
        public void BeginScopeReleaseWithRegisterdObjectShouldBeAssignableToIDoSomething()
        {
            container.Register<IDoSomething, DoSomething>(new PerContainerLifetime());

            var sut = container.GetInstance<IScopedLocator>();

            test.BeginScopeReleaseWithRegisterdObjectShouldBeAssignableToIDoSomething(sut);
        }

        [TestMethod]
        public void ResolveByTypeAndKeyWithRegisteredObjectShouldBeAssignableToIDoSomething()
        {
            container.Register<IDoSomething, DoSomething>("key");

            test.ResolveByTypeAndKeyWithRegisterdObjectShouldBeAssignableToIDoSomething(sut, "key");
        }

        [TestMethod]
        public void ResolveByTypeAndKeyWithRegisterdObjectShouldThrowException()
        {
            test.ResolveByTypeAndKeyWithRegisterdObjectShouldThrowException(sut, "key");
        }
    }
}
