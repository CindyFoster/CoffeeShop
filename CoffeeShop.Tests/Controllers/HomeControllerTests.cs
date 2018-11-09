using CoffeeShop.Controllers;
using CoffeeShop.Models;
using CoffeeShop.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private MockRepository mockRepository;

        private Mock<RestaurantService> mockRestaurantService;

        private Mock<List<ActionLog>> mockActionLogList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockRestaurantService = this.mockRepository.Create<RestaurantService>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private HomeController CreateHomeController()
        {
            return new HomeController(
                this.mockRestaurantService.Object);
        }

        [TestMethod]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateHomeController();

            // Act
            var result = unitUnderTest.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void About_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateHomeController();

            // Act
            var result = unitUnderTest.About();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.AreEqual("Your application description page.", unitUnderTest.ViewBag.Message);
        }

        [TestMethod]
        public void Contact_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateHomeController();

            // Act
            var result = unitUnderTest.Contact();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.AreEqual("Your contact page.", unitUnderTest.ViewBag.Message);
        }

        [TestMethod]
        public void ActionLog_ReturnsAViewContainingActionLogList()
        {
            // Arrange
            var unitUnderTest = CreateHomeController();
            var actionLogList = new List<ActionLog>();
            mockRestaurantService.Setup(mock => mock.GetAllActionLogs()).Returns(actionLogList);

            // Act
            var result = unitUnderTest.ActionLog();

            // Assert
            mockRestaurantService.Verify(mock => mock.GetAllActionLogs(), Times.Once());
        }

        [TestMethod]
        public void Drinks_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateHomeController();

            // Act
            var result = unitUnderTest.Drinks();

            // Assert
            Assert.Fail();
        }
    }
}
