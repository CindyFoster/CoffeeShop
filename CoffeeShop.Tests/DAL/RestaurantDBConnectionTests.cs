using CoffeeShop.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Configuration;
using System.Data.SqlClient;

namespace CoffeeShop.Tests.DAL
{
    [TestClass]
    public class RestaurantDBConnectionTests
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

        private RestaurantDBConnection CreateRestaurantDBConnection()
        {
            return new RestaurantDBConnection();
        }

        [TestMethod]
        public void Connection_Success_ReturnsAnSQLConnection()
        {
            // Arrange
            var unitUnderTest = CreateRestaurantDBConnection();
            //unitUnderTest.ConnectionString = ConfigurationManager.ConnectionStrings["RestaurantDB"].ToString();

            // Act
            var result = unitUnderTest.Connection();

            // Assert
            Assert.IsInstanceOfType(result.GetType(), typeof(SqlConnection));
        }
    }
}
