using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Http.Results;
using Common.Domain;
using Common.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TrovTHA.Controllers;

namespace TrovTHA.Tests.Controllers
{
    [TestClass]
    public class PurchaseControllerTest : BaseAuthenticatedControllerTest
    {

        [TestMethod]
        public void Get()
        {
            var mockRepository = MockRepository.GenerateMock<IPurchaseRepository>();
            var dateTime = DateTime.Now;
            mockRepository.Stub(repository => repository.FindByUserId("1"))
                .Return(new List<Purchase>
                {
                    new Purchase {DateTime = dateTime, ItemId = "3"},
                    new Purchase {DateTime = dateTime, ItemId = "2"}
                });
            var apiController = new PurchaseController(mockRepository);
            SetupUserIdInController(apiController);

            IEnumerable<Purchase> result = apiController.Get().ToList();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("3", result.ElementAt(0).ItemId);
            Assert.AreEqual("2", result.ElementAt(1).ItemId);
        }

        [TestMethod]
        public void Post()
        {
            var mockRepository = MockRepository.GenerateMock<IPurchaseRepository>();
            var purchase = new Purchase { DateTime = DateTime.Now, ItemId = "2" };
            var apiController = new PurchaseController(mockRepository);
            mockRepository.Expect(repository => repository.Save(purchase));
            SetupUserIdInController(apiController);

            var result = apiController.Post(purchase);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}