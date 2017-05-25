[assembly: WebActivator.PostApplicationStartMethod(typeof(RSMuseum.MVC.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace RSMuseum.MVC.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize() {
            Services.DI.Container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(Services.DI.Container);
        }
    }
}