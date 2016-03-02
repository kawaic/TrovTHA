using System;
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
    public class PurchaseControllerTest
    {
        [TestMethod]
        public void Get()
        {
            var mockRepository = MockRepository.GenerateMock<IPurchaseRepository>();
            var dateTime = DateTime.Now;
            mockRepository.Stub(repository => repository.FindAll())
                .Return(new List<Purchase>
                {
                    new Purchase {DateTime = dateTime, ItemId = 3},
                    new Purchase {DateTime = dateTime, ItemId = 2}
                });
            var apiController = new PurchaseController(mockRepository);

            IEnumerable<Purchase> result = apiController.Get().ToList();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(3, result.ElementAt(0).ItemId);
            Assert.AreEqual(2, result.ElementAt(1).ItemId);
        }

        [TestMethod]
        public void GetById()
        {
            var mockRepository = MockRepository.GenerateMock<IPurchaseRepository>();
            var dateTime = DateTime.Now;
            mockRepository.Stub(repository => repository.FindById("5")).Return(new Purchase { DateTime= dateTime, ItemId = 5});
            var apiController = new PurchaseController(mockRepository);
            Purchase result = apiController.Get("5");
            Assert.AreEqual(5, result.ItemId);
        }

        [TestMethod]
        public void Post()
        {
        }
    }
}