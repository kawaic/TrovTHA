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
    public class ItemControllerTest
    {

        [TestMethod]
        public void Get()
        {
            var mockRepository = MockRepository.GenerateMock<IItemRepository>();
            mockRepository.Stub(repository => repository.FindAll()).Return(new List<Item> { new Item {Name = "Hello"}, new Item {Name = "World"} });
            ItemController apiController = new ItemController(mockRepository);
            IEnumerable<Item> result = apiController.Get().ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Hello", result.ElementAt(0).Name);
            Assert.AreEqual("World", result.ElementAt(1).Name);
        }

        [TestMethod]
        public void GetById()
        {
            var mockRepository = MockRepository.GenerateMock<IItemRepository>();
            mockRepository.Stub(repository => repository.FindById("5")).Return(new Item {Name = "I AM 5"});
            ItemController apiController = new ItemController(mockRepository);
            Item result = apiController.Get("5");
            Assert.AreEqual("I AM 5", result.Name);
        }

    }
}
