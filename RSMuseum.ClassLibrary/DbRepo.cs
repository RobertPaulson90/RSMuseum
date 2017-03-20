using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RSMuseum.ClassLibrary.Entities;

namespace RSMuseum.ClassLibrary
{
    public class DbRepo
    {
        public class RSMContext : DbContext
        {
            public DbSet<Address> Address { get; set; }
            public DbSet<Guild> Guild { get; set; }
            public DbSet<Person> Person { get; set; }
            public DbSet<ZipCodeTable> ZipCodeTable { get; set; }
            public DbSet<ProjectManager> ProjectManager { get; set; }
            public DbSet<Volunteer> Volunteer { get; set; }
            public DbSet<Registration> Registration { get; set; }

            public RSMContext() : base("name = RSMConnectionString")
            {
            }

            public static RSMContext Create()
            {
                return new RSMContext();
            }
        }
    }
}