using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using RSMuseum.ClassLibrary;
using RSMuseum.MVC.Models;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace RSMuseum.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Instantiere vores DI container
            var di = new DI();

            DI.Container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>());
            DI.Container.Register<ApplicationUserManager>();
            DI.Container.Register<ApplicationSignInManager>();

            DI.Container.Register<IAuthenticationManager>(() => DI.Container.GetInstance<IOwinContext>().Authentication);

            // DI.Container.Register<IAuthenticationManager, AuthenticationManager>();

            DI.Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            //DI.Container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(DI.Container));
        }
    }
}