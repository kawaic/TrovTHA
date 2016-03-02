using System.Web.Http;
using Common.Repository;
using Microsoft.Owin.Testing;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
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
                var container = new UnityContainer();
                container.RegisterType<IItemRepository, ItemRepository>(new ContainerControlledLifetimeManager());
                container.RegisterType<IPurchaseRepository, PurchaseRepository>(new ContainerControlledLifetimeManager());
                config.DependencyResolver = new UnityResolver(container);
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
