using System.Collections.Generic;
using System.Linq;
using Common.Domain;
using Common.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TrovTHA.Controllers;

namespace TrovTHA.Tests.Controllers
{
    [TestClass]
    public class InventoryControllerTest
    {
        [TestMethod]
        public void Get()
        {
            var mockRepository = MockRepository.GenerateMock<IInventoryRepository>();
            mockRepository.Stub(repository => repository.FindAll())
                .Return(new List<Inventory> {new Inventory {Item = new Item {Name = "Hello"} }, new Inventory {Item = new Item {Name = "World"} }});
            var apiController = new InventoryController(mockRepository);
            IEnumerable<Inventory> result = apiController.Get().ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Hello", result.ElementAt(0).Item.Name);
            Assert.AreEqual("World", result.ElementAt(1).Item.Name);
        }

    }
}