using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using RSMuseum.Services;
using System.Web.Http;
using RSMuseum.MVC.App_Start;

namespace RSMuseum.MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(UnityServicesSetup.container);

        }
    }
}
