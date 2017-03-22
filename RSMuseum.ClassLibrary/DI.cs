using SimpleInjector;
using static RSMuseum.ClassLibrary.DbRepo;
using RSMuseum.ClassLibrary.Repositories;
using RSMuseum.ClassLibrary.Services;
using SimpleInjector.Integration.Web;

namespace RSMuseum.ClassLibrary
{
    public class DI
    {
        // Access the container in other classes with DI.Container. Remember: using RSMuseum.ClassLibrary;
        public static Container Container { get; set; }

        public DI()
        {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            Container.Register<RSMContext>(Lifestyle.Scoped);
            Container.Register<IDbRepository, EntityFrameworkRepository>();
            Container.Register<VolunteerService>();

            Container.Verify();
        }
    }
}