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
            public virtual DbSet<Address> Address { get; set; }
            public virtual DbSet<Guild> Guild { get; set; }
            public virtual DbSet<Person> Person { get; set; }
            public virtual DbSet<ZipCodeTable> ZipCodeTable { get; set; }
            public virtual DbSet<ProjectManager> ProjectManager { get; set; }
            public virtual DbSet<Volunteer> Volunteer { get; set; }
            public virtual DbSet<Registration> Registration { get; set; }

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