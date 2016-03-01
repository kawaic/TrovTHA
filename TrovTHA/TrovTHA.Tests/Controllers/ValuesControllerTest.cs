using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrovTHA;
using TrovTHA.Controllers;

namespace TrovTHA.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ItemController apiController = new ItemController();

            // Act
            IEnumerable<string> result = apiController.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ItemController apiController = new ItemController();

            // Act
            string result = apiController.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ItemController apiController = new ItemController();

            // Act
            apiController.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ItemController apiController = new ItemController();

            // Act
            apiController.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ItemController apiController = new ItemController();

            // Act
            apiController.Delete(5);

            // Assert
        }
    }
}
