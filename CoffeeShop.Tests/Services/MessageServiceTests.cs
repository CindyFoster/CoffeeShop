using CoffeeShop.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CoffeeShop.Tests.Services
{
    [TestClass]
    public class MessageServiceTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private MessageService CreateService()
        {
            return new MessageService();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var unitUnderTest = CreateService();

            // Act

            // Assert
            Assert.Fail();
        }

    }
}
