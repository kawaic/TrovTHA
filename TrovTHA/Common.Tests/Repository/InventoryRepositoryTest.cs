using System.Linq;
using Common.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests.Repository
{
    [TestClass]
    public class InventoryRepositoryTest
    {
        [TestMethod]
        public void TestFindAll()
        {
            IInventoryRepository repository = new InventoryRepository();
            var result = repository.FindAll().ToList();

            Assert.AreEqual(4, result.Count);


            var apple = result.FirstOrDefault(inv => inv.Item.Name == "Apple");
            Assert.IsNotNull(apple);

            var orange = result.FirstOrDefault(inv => inv.Item.Name == "Orange");
            Assert.IsNotNull(orange);

            var iceCream = result.FirstOrDefault(inv => inv.Item.Name == "Ice Cream");
            Assert.IsNotNull(iceCream);

            var eggs = result.FirstOrDefault(inv => inv.Item.Name == "Carton of Eggs");
            Assert.IsNotNull(eggs);

        }

    }
}
