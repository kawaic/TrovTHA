using Microsoft.Practices.Unity;
using System.Web.Http;
using Common.Repository;
using TrovTHA.Repository;
using Unity.WebApi;

namespace TrovTHA
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            container.RegisterType<IItemRepository, ItemRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IPurchaseRepository, PurchaseRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new ContainerControlledLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}