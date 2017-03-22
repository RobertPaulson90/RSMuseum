//using RSMuseum.ClassLibrary.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace RSMuseum.ClassLibrary.Tests
//{
//    public class EntityFrameworkTests
//    {
//        [Fact]
//        public void CreateFakeData()
//        {
//            var context = new DbRepo.RSMContext();

//            context.ZipCodeTable.Add(new ZipCodeTable { City = "Vejle", ZipCode = 7100 });
//            context.ZipCodeTable.Add(new ZipCodeTable { City = "Koding", ZipCode = 6100 });
//            context.Guild.Add(
//                  new Guild { GuildName = "Laug 1" },
//                  new Guild { GuildName = "Laug 2" },
//                  new Guild { GuildName = "Laug 3" }
//                );

//            var volunteer1 = new Volunteer { IsActive = false, };
//            volunteer1.Guilds = context.Guild.ToList();
//            volunteer1.Person.Address.Street = "Skovvej 1";
//            volunteer1.Person.Address.ZipCode = context.ZipCodeTable.First(x => x.ZipCode == 7100);
//            volunteer1.Person.Email = "test@email.com";
//            volunteer1.Person.FirstName = "Ole";
//            volunteer1.Person.LastName = "Jakup";
//            volunteer1.Person.Phone = "12345678";

//            var volunteer2 = new Volunteer { IsActive = false };
//            volunteer2.Guilds.Add(context.Guild.First(x => x.GuildName == "Laug 1"));

//            volunteer2.Person.Address.Street = "ZTestvej 33";
//            volunteer2.Person.Address.ZipCode = context.ZipCodeTable.First(x => x.ZipCode == 6100);
//            volunteer2.Person.Email = "hej@gmail.com";
//            volunteer2.Person.FirstName = "Per";
//            volunteer2.Person.LastName = "Lotte";
//            volunteer2.Person.Phone = "87654321";

//            var volunteer3 = new Volunteer { IsActive = true, };
//            volunteer3.Guilds.Add(context.Guild.First(x => x.GuildName == "Laug 3"));
//            volunteer3.Person.Address.Street = "AHHHH 3";
//            volunteer3.Person.Address.ZipCode = context.ZipCodeTable.First(x => x.ZipCode == 6100);
//            volunteer3.Person.Email = "president@whitehouse.gov";
//            volunteer3.Person.FirstName = "Donald";
//            volunteer3.Person.LastName = "Trump";
//            volunteer3.Person.Phone = "55554444";

//            context.Volunteer.AddOrUpdate(volunteer1, volunteer2, volunteer3);
//        }
//    }
//}
