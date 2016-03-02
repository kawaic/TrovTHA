using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Common.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using TrovTHA.Models;

namespace TrovTHA.Tests.Integration
{
    [TestClass]
    public class PurchaseApiTest : BaseApiServerTest
    {
        private string token;

        protected override void RunPostSetup()
        {
            base.RunPostSetup();
            RegisterUser();
            token = GetToken();
        }

        private string GetToken()
        {
            var details = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", "testuser@somewhere.com"),
                new KeyValuePair<string, string>("password", "P@55w0rd")
            };

            var tokenPostData = new FormUrlEncodedContent(details);
            var result = server.HttpClient.PostAsync("/Token", tokenPostData).Result;
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var body = JObject.Parse(result.Content.ReadAsStringAsync().Result);
            var token = (string) body["access_token"];
            return token;
        }

        [TestMethod]
        public async Task TestPostPurchase()
        {
            var model = new Purchase {DateTime = DateTime.Now, ItemId = "1"};

            var objectContent = new ObjectContent(typeof (Purchase), model, new JsonMediaTypeFormatter());

            var response = await server.CreateRequest("/api/purchases")
                .And(req => { req.Content = objectContent; }).AddHeader("Authorization", "Bearer " + token)
                .PostAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [TestMethod]
        public async Task TestGetPurchases()
        {
            await TestPostPurchase();
            var response =
                await server.CreateRequest("api/purchases").AddHeader("Authorization", "Bearer " + token).GetAsync();
            Assert.IsTrue(response.IsSuccessStatusCode);

            var purchases = await response.Content.ReadAsAsync<IEnumerable<Purchase>>();
            Assert.AreEqual(1, purchases.Count());
        }

        private void RegisterUser()
        {
            var model = new RegisterBindingModel
            {
                Email = "testuser@somewhere.com",
                Password = "P@55w0rd",
                ConfirmPassword = "P@55w0rd"
            };
            var objectContent = new ObjectContent(typeof (RegisterBindingModel), model, new JsonMediaTypeFormatter());

            var response = server.CreateRequest("/api/Account/Register")
                .And(req => { req.Content = objectContent; })
                .PostAsync().Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}