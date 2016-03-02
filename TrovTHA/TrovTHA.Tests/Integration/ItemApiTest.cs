using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrovTHA.Tests.Integration
{
    [TestClass]
    public class ItemApiTest : BaseApiServerTest
    {

        [TestMethod]
        public async Task TestGetItems()
        {
            var response = await server.CreateRequest("/api/Item").GetAsync();
            Assert.IsTrue(response.IsSuccessStatusCode);

            var items = await response.Content.ReadAsAsync<IEnumerable<Item>>();
            Assert.AreEqual(4, items.Count());
        }

        [TestMethod]
        public async Task TestGetAnItem()
        {
            var response = await server.CreateRequest("/api/Item/2").GetAsync();
            Assert.IsTrue(response.IsSuccessStatusCode);

            var item = await response.Content.ReadAsAsync<Item>();
            Assert.IsNotNull(item);
        }

    }
}
