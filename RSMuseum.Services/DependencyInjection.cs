using System.Linq;
using AutoMapper;
using RSMuseum.Repository;
using RSMuseum.Repository.Entities;
using RSMuseum.Services.DTOs;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace RSMuseum.Services
{
    public class DependencyInjection
    {
        public static Container Container { get; private set; }

        public DependencyInjection() {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

            Container.Register<RSMContext>(Lifestyle.Scoped);
            Container.Register<IDbRepository, EntityFrameworkRepository>();
            Container.Register<VolunteerService>();
            Container.Register<GuildService>();
            Container.Register<RegistrationService>();

            Container.RegisterSingleton(() => GetAutoMapper(Container));

            Container.Verify();
        }

        private static IMapper GetAutoMapper(Container container) {
            var mp = container.GetInstance<MapperProvider>();
            return mp.GetMapper();
        }
    }
}