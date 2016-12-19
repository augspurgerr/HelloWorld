using HelloWorld.API.Controllers;
using HelloWorld.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace HelloWorld.API.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        public ValuesControllerTest()
        {
            string connStr = ConfigurationManager.ConnectionStrings["cnStringSQL"].ConnectionString;
            _dm = new MessageDM(connStr);
        }

        private IMessageDM _dm { get; set; }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController(_dm);

            // Act
            controller.Delete(2);

            // Assert
        }

        [TestMethod]
        public void Get()
        {
            // Arrange
            ValuesController controller = new ValuesController(_dm);

            // Act
            string result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Hello World", result);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController(_dm);

            // Act
            string result = controller.Get(1);

            // Assert
            Assert.AreEqual("Hello World", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController(_dm);

            // Act
            controller.Post("Hello World 2");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController(_dm);

            // Act
            controller.Put(2, "Test Value");

            // Assert
        }
    }
}