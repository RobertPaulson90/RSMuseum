using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RSMuseum.Repository;
using RSMuseum.Repository.Entities;
using RSMuseum.Services.DTOs;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Lifestyles;

namespace RSMuseum.Services
{
    public class DependencyInjection
    {
        public static Container Container { get; private set; }

        public DependencyInjection() {
            Container = new Container();

            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Container.Register<RSMContext>(Lifestyle.Scoped);
            Container.Register<BogusEfSeedDataService>(Lifestyle.Scoped);
            Container.Register<IDbRepository, EntityFrameworkRepository>();
            Container.Register<VolunteerService>();
            Container.Register<GuildService>();
            Container.Register<RegistrationService>();
            Container.RegisterSingleton(() => GetAutoMapper(Container));
            
            Container.Verify();

#if DEBUG
            // DANGER!!! The below ensures the database always has test data. Comment out for production!
            InitializeBogusEfDataGeneration();
#endif
        }

        private static IMapper GetAutoMapper(Container container) {
            var mp = container.GetInstance<MapperProvider>();
            return mp.GetMapper();
        }

        [Conditional("DEBUG")]
        private static async void InitializeBogusEfDataGeneration() {
            using (AsyncScopedLifestyle.BeginScope(Container)) {
                var bogusData = Container.GetInstance<BogusEfSeedDataService>();
                await bogusData.Initialize();                
            }
        }
    }
}