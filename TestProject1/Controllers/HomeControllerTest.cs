//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Controllers;

namespace Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            //HomeController controller = new HomeController();

            // Act
           // ViewResult result = (controller.Index()).Result as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
           // Assert.AreEqual("Home Page", result.Model.GetType()== List<MVC.DAL.OrderDto>.);
        }

        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(true);
        }
    }
}
