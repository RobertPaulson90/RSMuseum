using RSMuseum.ClassLibrary.Models;
using SimpleInjector;
using static RSMuseum.ClassLibrary.DbRepo;
using Moq;

namespace RSMuseum.ClassLibrary
{
    public class DI
    {
        // Access the container in other classes with DI.Container. Remember: using RSMuseum.ClassLibrary;
        public static Container Container { get; set; }

        public DI(bool testing = false)
        {
            Container = new Container();

            if (!testing)
            {
                Container.Register<RSMContext>(Lifestyle.Singleton);
                // Register example:
                // Container.Register<IUserRepository, SqlUserRepository>();
                // Container.Register<MyRootType>();
            }
            else if (testing)
            {
                //var mockContext = new Mock<RSMContext>();
                //Container.Register<RSMContext>(Lifestyle.Singleton);

                //DI.Container.Register<ITestModel, TestModel>();
                //DI.Container.Register<IDummyModel, DummyModel>();
                // Register mocked interfaces instead
            }

            Container.Verify();
            var dbContext = Container.GetInstance<RSMContext>();
        }
    }
}