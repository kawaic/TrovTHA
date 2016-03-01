using System.Web.Http;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;

namespace TrovTHA.Tests.Integration
{
    public abstract class BaseApiServerTest
    {
        protected TestServer server;

        [TestInitialize]
        public void Setup()
        {
            server = TestServer.Create(app =>
            {
                var startup = new Startup();
                startup.ConfigureAuth(app);

                var config = new HttpConfiguration();
                WebApiConfig.Register(config);

                app.UseWebApi(config);
            });
        }

        [TestCleanup]
        public void Teardown()
        {
            server?.Dispose();
        }

    }
}
