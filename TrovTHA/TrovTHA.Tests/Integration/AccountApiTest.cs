using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using TrovTHA.Models;

namespace TrovTHA.Tests.Integration
{
    [TestClass]
    public class AccountApiTest : BaseApiServerTest
    {
        [TestMethod]
        public async Task CanRegisterUser()
        {
            var model = new RegisterBindingModel
            {
                Email = "testuser@somewhere.com",
                Password = "P@55w0rd",
                ConfirmPassword = "P@55w0rd"
            };
            var objectContent = new ObjectContent(typeof(RegisterBindingModel), model, new JsonMediaTypeFormatter());

            var response = await server.CreateRequest("/api/Account/Register")
                .And(req => { req.Content = objectContent;})
                .PostAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task ShouldBlockRegistrationWithWeakPassword()
        {
            var model = new RegisterBindingModel
            {
                Email = "testuser@somewhere.com",
                Password = "Pa55word",
                ConfirmPassword = "Pa55word"
            };
            var objectContent = new ObjectContent(typeof(RegisterBindingModel), model, new JsonMediaTypeFormatter());

            var response = await server.CreateRequest("/api/Account/Register")
                .And(req => { req.Content = objectContent; })
                .PostAsync();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var content = response.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(content.Contains("Passwords must have at least one non letter or digit character"));
        }

        [TestMethod]
        public async Task CanLogin()
        {
            await CanRegisterUser();
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
            var token = (string)body["access_token"];

            Assert.IsNotNull(token);
        }
    }
}
