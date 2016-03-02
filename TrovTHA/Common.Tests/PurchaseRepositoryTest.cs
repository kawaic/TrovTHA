using System;
using System.Linq;
using Common.Domain;
using Common.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass]
    public class PurchaseRepositoryTest
    {
        [TestMethod]
        public void TestShouldFindById()
        {
            IPurchaseRepository repository = new PurchaseRepository();
            var result = repository.FindAll().ToList();

            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void TestFindById()
        {
            IPurchaseRepository repository = new PurchaseRepository();
            var result = repository.FindById(2);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestShouldSave()
        {
            IPurchaseRepository repository = new PurchaseRepository();
            var saved = repository.Save(new Purchase {DateTime = DateTime.Now, ItemId = 3});
            Assert.IsNotNull(saved.Id);
        }
    }
}
