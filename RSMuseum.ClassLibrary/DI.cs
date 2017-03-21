using SimpleInjector;
using static RSMuseum.ClassLibrary.DbRepo;
using Moq;
using RSMuseum.ClassLibrary.Repositories;
using RSMuseum.ClassLibrary.Services;
using SimpleInjector.Integration.Web;

namespace RSMuseum.ClassLibrary
{
    public class DI
    {
        // Access the container in other classes with DI.Container. Remember: using RSMuseum.ClassLibrary;
        public static Container Container { get; set; }

        public DI(bool testing = false)
        {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            if (!testing)
            {
                Container.Register<RSMContext>(Lifestyle.Scoped);
                Container.Register<IVolunteerRepository, VolunteerRepository>();
                Container.Register<VolunteerService>();
            }
            else if (testing)
            {
                //var mockContext = new Mock<RSMContext>();
                //Container.Register<RSMContext>(Lifestyle.Singleton);

                //DI.Container.Register<ITestModel, TestModel>();
                //DI.Container.Register<IDummyModel, DummyModel>();
                // Register mocked interfaces instead
            }

            // Container.Verify();
        }
    }
}