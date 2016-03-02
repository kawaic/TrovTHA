using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using TrovTHA.Models;

namespace TrovTHA.Tests.Integration
{
    public abstract class BaseAuthenticatedApiServerTest : BaseApiServerTest
    {
        private string token;

        public string Token => token;

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
            var token = (string)body["access_token"];
            return token;
        }

        private void RegisterUser()
        {
            var model = new RegisterBindingModel
            {
                Email = "testuser@somewhere.com",
                Password = "P@55w0rd",
                ConfirmPassword = "P@55w0rd"
            };
            var objectContent = new ObjectContent(typeof(RegisterBindingModel), model, new JsonMediaTypeFormatter());

            var response = server.CreateRequest("/api/Account/Register")
                .And(req => { req.Content = objectContent; })
                .PostAsync().Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
