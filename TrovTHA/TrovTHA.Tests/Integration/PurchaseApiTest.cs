using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Common.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrovTHA.Tests.Integration
{
    [TestClass]
    public class PurchaseApiTest : BaseAuthenticatedApiServerTest
    {

        [TestMethod]
        public async Task TestPostPurchase()
        {
            var model = new Purchase {DateTime = DateTime.Now, ItemId = "1"};

            var objectContent = new ObjectContent(typeof (Purchase), model, new JsonMediaTypeFormatter());

            var response = await server.CreateRequest("/api/purchases")
                .And(req => { req.Content = objectContent; }).AddHeader("Authorization", "Bearer " + Token)
                .PostAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [TestMethod]
        public async Task TestGetPurchases()
        {
            await TestPostPurchase();
            var response =
                await server.CreateRequest("api/purchases").AddHeader("Authorization", "Bearer " + Token).GetAsync();
            Assert.IsTrue(response.IsSuccessStatusCode);

            var purchases = await response.Content.ReadAsAsync<IEnumerable<Purchase>>();
            Assert.AreEqual(1, purchases.Count());
        }

    }
}