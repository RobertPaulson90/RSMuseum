using Microsoft.Owin;
using Owin;
using RSMuseum.ClassLibrary;

[assembly: OwinStartupAttribute(typeof(RSMuseum.MVC.Startup))]
namespace RSMuseum.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            new DI(); // Instantiere vores DI container
            //AddDbContext her
            ConfigureAuth(app);
        }
    }
}
