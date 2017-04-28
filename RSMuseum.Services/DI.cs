using System.Linq;
using AutoMapper;
using RSMuseum.Repository;
using RSMuseum.Repository.Entities;
using RSMuseum.Services.DTOs;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace RSMuseum.Services
{
    public class DI
    {
        // Access the container in other classes with DI.Container.
        public static Container Container { get; set; }

        public DI()
        {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            Container.Register<RSM_EF_DbCtx.RSMContext>(Lifestyle.Scoped);
            Container.Register<IDbRepository, EntityFrameworkRepository>();
            Container.Register<VolunteerService>();
            Container.Register<GuildService>();
            Container.Register<RegistrationService>();

            Container.RegisterSingleton(() => GetMapper(Container));

            Container.Verify();
        }

        private IMapper GetMapper(Container container)
        {
            var mp = container.GetInstance<MapperProvider>();
            return mp.GetMapper();
        }
    }
}