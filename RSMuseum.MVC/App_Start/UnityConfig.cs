using Microsoft.Practices.Unity;
using RSMuseum.Services;
using System.Web.Http;
using Unity.WebApi;
using System.Web.Mvc;

namespace RSMuseum.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            UnityServicesSetup.container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default
                );
            DependencyResolver.SetResolver(new UnityDependencyResolver(RSMuseum.Services.UnityServicesSetup.container));
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(UnityServicesSetup.container);
        }
    }
}