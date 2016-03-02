using System.Web.Http;
using Common.Repository;
using Microsoft.Owin.Testing;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
using TrovTHA.Repository;
using TrovTHA.Utility;

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
                UnityConfig.RegisterComponents();
                var container = new UnityContainer();
                UnityConfig.LoadContainer(container);
                var dependencyResolver = new UnityResolver(container);
                config.DependencyResolver = dependencyResolver;
                GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
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
