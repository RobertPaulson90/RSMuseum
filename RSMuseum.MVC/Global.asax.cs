using RSMuseum.Services;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector.Integration.WebApi;

namespace RSMuseum.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HttpConfiguration config = GlobalConfiguration.Configuration;

            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Instantiere vores DI container
            new DependencyInjection();

            // Konfigurerer ASP.NET til at bruge vores container
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(DependencyInjection.Container);

            // Dont uncomment the below! Unless you must generate db-data
            // var generateFakeData = DI.Container.GetInstance<GenerateFakeData>();
        }
    }
}