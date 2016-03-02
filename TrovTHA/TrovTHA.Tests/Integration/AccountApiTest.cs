using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public async Task CanGetUserInfo()
        {
            
        }
    }
}
