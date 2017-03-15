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
        // Tilgå containeren i andre klasser med DI.Container. Husk using RSMuseum.ClassLibrary;
        public static Container Container { get; set; }

        public DI()
        {
            Container = new Container();

            // Register eksempel
            // Container.Register<IUserRepository, SqlUserRepository>();
            // Container.Register<MyRootType>();

            Container.Verify();
        }
    }

    
}
