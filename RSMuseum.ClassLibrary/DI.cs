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
        public Container Container { get; set; }

        public DI()
        {
            Container = new Container();

            // Register eksempel
            // Container.Register<IUserRepository, SqlUserRepository>();
            // Container.Register<MyRootType>();

            // Tilgå containeren i andre 

            Container.Verify();
        }
    }

    
}
