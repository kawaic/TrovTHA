using System;
using System.Linq;
using Common.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass]
    public class ItemRepositoryTest
    {
        [TestMethod]
        public void TestFindAll()
        {
            IItemRepository repository = new ItemRepository();
            var result = repository.FindAll().ToList();

            Assert.AreEqual(4, result.Count);


            var apple = result.FirstOrDefault(item => item.Name == "Apple");
            Assert.IsNotNull(apple);

            var orange = result.FirstOrDefault(item => item.Name == "Orange");
            Assert.IsNotNull(orange);

            var iceCream = result.FirstOrDefault(item => item.Name == "Ice Cream");
            Assert.IsNotNull(iceCream);

            var eggs = result.FirstOrDefault(item => item.Name == "Carton of Eggs");
            Assert.IsNotNull(eggs);

        }

        [TestMethod]
        public void TestFindById()
        {
            IItemRepository repository = new ItemRepository();

            var apple = repository.FindById("1");
            Assert.IsNotNull(apple);
            Assert.AreEqual("Apple", apple.Name);
            Assert.AreEqual("Gala apple.", apple.Description);
            Assert.AreEqual(1, apple.Price);
        }

    }
}
