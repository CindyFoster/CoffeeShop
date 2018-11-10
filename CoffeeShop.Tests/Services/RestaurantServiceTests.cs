using CoffeeShop.DAL;
using CoffeeShop.Models;
using CoffeeShop.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace CoffeeShop.Tests.Services
{
    [TestClass]
    public class RestaurantServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IActionLogDAL> mockActionLogDAL;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockActionLogDAL = this.mockRepository.Create<IActionLogDAL>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private RestaurantService CreateService()
        {
            return new RestaurantService(
                this.mockActionLogDAL.Object);
        }

        [TestMethod]
        public void GetAllActionLogs_Success_ShouldReturnAnActionLogList()
        {
            // Arrange
            var unitUnderTest = CreateService();
            mockActionLogDAL.Setup(x => x.GetDataTable("GetActionLogs")).Returns(new System.Data.DataTable());

            // Act
            var result = unitUnderTest.GetAllActionLogs();

            // Assert
            Assert.AreEqual(typeof(List<ActionLog>), result.GetType());
        }

        [TestMethod]
        public void GetAllDrinks_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateService();
            mockActionLogDAL.Setup(x => x.GetDataTable("GetAllDrinks")).Returns(new System.Data.DataTable());

            // Act
            var result = unitUnderTest.GetAllDrinks();

            // Assert
            Assert.AreEqual(typeof(Drinks), result.GetType());
        }

        [TestMethod]
        public void GetDrinkList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateService();
            mockActionLogDAL.Setup(x => x.GetDataTable("GetAllDrinks")).Returns(new System.Data.DataTable());

            // Act
            var result = unitUnderTest.GetDrinkList();

            // Assert
            Assert.AreEqual(typeof(List<Drink>), result.GetType());
        }
    }
}
