using Unity;
using System.Web.Http;
using Unity.AspNet.Mvc;
using GenericResolver;
namespace HealthCare
{
    public static class Loader
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //register dependency resolver for ContactManager
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            ComponentLoader.LoadContainer(container, ".\\bin", "BusinessLogic.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "DataAccess.dll");
        }
    }
}