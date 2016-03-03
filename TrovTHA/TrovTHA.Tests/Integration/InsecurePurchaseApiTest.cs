using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrovTHA.Tests.Integration
{
    [TestClass]
    public class InsecurePurchaseApiTest : BaseApiServerTest
    {
        [TestMethod]
        public async Task TestGetPurchases()
        {
            var response = await server.CreateRequest("api/purchases").GetAsync();
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.AreEqual("Unauthorized", response.ReasonPhrase);
        }

    }
}
