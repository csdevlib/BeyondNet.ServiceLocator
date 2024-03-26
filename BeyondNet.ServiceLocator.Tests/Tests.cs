using Locator = BeyondNet.ServiceLocator.Impl;
using BeyondNet.Aop.Tests.ServiceLocator.Impl;
using BeyondNet.Aop.Tests.ServiceLocator.Interface;

namespace BeyondNet.Aop.Tests.ServiceLocator.Tests
{
    [TestClass]
    public class Tests
    {
        private Locator.ServiceLocator sut;

        private ServiceLocatorTest test;

        [TestInitialize]
        public void Setup()
        {
            sut = new Locator.ServiceLocator();

            test = new ServiceLocatorTest();
        }

        [TestMethod]
        public void ResolveByTypeWithRegisterdObjectShouldBeAssignableToIDoSomething()
        {
            sut.Register(typeof(IDoSomething), new DoSomething());

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
            sut.Register(typeof(IDoSomething), new DoSomething());

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
            sut.Register(typeof(IDoSomething), new DoSomething(), "key");

            test.ResolveByKeyWithRegisterdObjectShouldBeAssignableToIDoSomething(sut, "key");
        }

        [TestMethod]
        public void ResolveByKeyWithoutRegisteredObjectShouldThrowException()
        {
            test.ResolveByKeyWithoutRegisteredObjectShouldThrowException(sut, "key");
        }

        [TestMethod]
        public void ResolveAllWithRegisterdObjectShouldBeAssignableToIDoSomething()
        {
            sut.Register(typeof(IDoSomething), new DoSomething());

            test.ResolveAllWithRegisterdObjectShouldBeAssignableToIDoSomething(sut);
        }

        [TestMethod]
        public void ResolveByTypeAndKeyWithRegisterdObjectShouldBeAssignableToIDoSomething()
        {

            sut.Register(typeof(IDoSomething), new DoSomething(), "key");

            test.ResolveByTypeAndKeyWithRegisterdObjectShouldBeAssignableToIDoSomething(sut, "key");
        }

        [TestMethod]
        public void ResolveByTypeAndKeyWithRegisterdObjectShouldThrowException()
        {
            test.ResolveByTypeAndKeyWithRegisterdObjectShouldThrowException(sut, "key");
        }
    }
}
