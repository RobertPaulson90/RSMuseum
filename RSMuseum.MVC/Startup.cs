using System.Reflection;
using Microsoft.Owin;
using Owin;
using RSMuseum.ClassLibrary;
using SimpleInjector;

[assembly: OwinStartupAttribute(typeof(RSMuseum.MVC.Startup))]

namespace RSMuseum.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}