using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.Services
{
    public static class UnityServicesSetup
    {
        public static UnityContainer container;

        public static void RegisterComponents()
        {
            container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default
                );

            container.RegisterType<IGuildService, GuildService>(new HierarchicalLifetimeManager());


        }
    }
}
