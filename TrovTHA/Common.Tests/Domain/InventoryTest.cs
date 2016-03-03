using Common.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests.Domain
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void ShouldReturnTrueIfEnoughStockForPurchase()
        {
            var inventory = new Inventory { NumberInStock = 5 };
            var purchase = new Purchase { Quantity = 1 };
            var result = inventory.HasEnoughStockFor(purchase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotEnoughStock()
        {
            var inventory = new Inventory { NumberInStock = 5 };
            var purchase = new Purchase { Quantity = 10 };
            var result = inventory.HasEnoughStockFor(purchase);
            Assert.IsFalse(result);

        }
    }
}
