using RSMuseum.ClassLibrary.Models;
using SimpleInjector;


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
                // Register example:
                // Container.Register<IUserRepository, SqlUserRepository>();
                // Container.Register<MyRootType>();
            }
            else if (testing)
            {
                //DI.Container.Register<ITestModel, TestModel>();
                //DI.Container.Register<IDummyModel, DummyModel>();
                // Register mocked interfaces instead
            }

            Container.Verify();
        }
    }

    
}
