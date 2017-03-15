using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;


namespace RSMuseum.ClassLibrary
{
    public class DI
    {
        // Access the container in other classes with DI.Container. Remember: using RSMuseum.ClassLibrary;
        public static Container Container { get; set; }

        public DI()
        {
            Container = new Container();

            var testing = false;

            if (!testing)
            {
                // Register example:
                // Container.Register<IUserRepository, SqlUserRepository>();
                // Container.Register<MyRootType>();
            }
            else if (testing)
            {
                // Register mocked interfaces instead
            }

            Container.Verify();
        }
    }

    
}
