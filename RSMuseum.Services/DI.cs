using AutoMapper;
using RSMuseum.ClassLibrary;
using RSMuseum.ClassLibrary.Entities;
using RSMuseum.Repository;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace RSMuseum.Services
{
    public class DI
    {
        // Access the container in other classes with DI.Container. Remember: using RSMuseum.ClassLibrary;
        public static Container Container { get; set; }
        public Mapper AutoMapper { get; set; }

        public DI()
        {
            AutoMapper = Mapper.Configuration.CreateMapper();
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            Container.Register<RSM_EF_DbCtx.RSMContext>(Lifestyle.Scoped);
            Container.Register<IDbRepository, EntityFrameworkRepository>();
            Container.Register<VolunteerService>();

            Container.Verify();
        }
    }
}