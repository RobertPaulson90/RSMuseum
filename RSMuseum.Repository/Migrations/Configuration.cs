using RSMuseum.ClassLibrary.Entities;

namespace RSMuseum.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entities;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<RSM_EF_DbCtx.RSMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RSM_EF_DbCtx.RSMContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ZipCodeTable.AddOrUpdate(
                  new ZipCodeTable { City = "Vejle", ZipCode = 7100 },
                  new ZipCodeTable { City = "Koding", ZipCode = 6100 }
                );
            context.Guild.AddOrUpdate(
                  new Guild { GuildName = "Laug 1" },
                  new Guild { GuildName = "Laug 2" },
                  new Guild { GuildName = "Laug 3" }
                );
            context.SaveChanges();

            var volunteer1 = new Volunteer { IsActive = false  };
            volunteer1.Person = new Person();
            volunteer1.Person.Address = new Address();
            volunteer1.Guilds = context.Guild.ToList();
            volunteer1.Person.Address.Street = "Skovvej 1";
            volunteer1.Person.Address.ZipCode = context.ZipCodeTable.First(x => x.ZipCode == 7100);
            volunteer1.Person.Email = "test@email.com";
            volunteer1.Person.FirstName = "Ole";
            volunteer1.Person.LastName = "Jakup";
            volunteer1.Person.Phone = "12345678";
            volunteer1.MembershipNumber = 1024;

            var volunteer2 = new Volunteer { IsActive = false };
            volunteer2.Person = new Person();
            volunteer2.Person.Address = new Address();
            volunteer2.Guilds = new List<Guild>();
            volunteer2.Guilds.Add(context.Guild.First(x => x.GuildName == "Laug 1"));
            volunteer2.Person.Address.Street = "ZTestvej 33";
            volunteer2.Person.Address.ZipCode = context.ZipCodeTable.First(x => x.ZipCode == 6100);
            volunteer2.Person.Email = "hej@gmail.com";
            volunteer2.Person.FirstName = "Per";
            volunteer2.Person.LastName = "Lotte";
            volunteer2.Person.Phone = "87654321";
            volunteer2.MembershipNumber = 1424;


            var volunteer3 = new Volunteer { IsActive = true, };
            volunteer3.Person = new Person();
            volunteer3.Person.Address = new Address();
            volunteer3.Guilds = new List<Guild>();
            volunteer3.Guilds.Add(context.Guild.First(x => x.GuildName == "Laug 3"));
            volunteer3.Person.Address.Street = "AHHHH 3";
            volunteer3.Person.Address.ZipCode = context.ZipCodeTable.First(x => x.ZipCode == 6100);
            volunteer3.Person.Email = "president@whitehouse.gov";
            volunteer3.Person.FirstName = "Donald";
            volunteer3.Person.LastName = "Trump";
            volunteer3.Person.Phone = "55554444";
            volunteer3.MembershipNumber = 1124;


            context.Volunteer.AddOrUpdate(volunteer1, volunteer2, volunteer3);
        }
    }
}