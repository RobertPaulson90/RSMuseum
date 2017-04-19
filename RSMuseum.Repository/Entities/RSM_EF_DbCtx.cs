using System.Data.Entity;
using RSMuseum.Repository.Entities;

namespace RSMuseum.Repository.Entities
{
    public class RSM_EF_DbCtx
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
                this.Configuration.LazyLoadingEnabled = false;
                this.Configuration.ProxyCreationEnabled = false;

            }

            public static RSMContext Create()
            {
                return new RSMContext();
            }
        }
    }
}