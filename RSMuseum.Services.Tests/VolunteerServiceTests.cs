using System.Collections.Generic;
using System.Linq;
using Moq;
using RSMuseum.Repository;
using RSMuseum.Repository.Entities;
using RSMuseum.Services.DTOs;
using Xunit;

namespace RSMuseum.Services.Tests

{
    public class VolunteerServiceTests
    {
        [Fact]
        public void GetVolunteersViewDTO_MethodWorks()
        {
            //// Arrange
            ////var guildMocked = new Mock<Guild>();
            //var personFake = new Person { FirstName = "Firstname", LastName = "Lastname" };
            //var volunteerFake = new Volunteer { Person = personFake, Guilds = new List<Guild>() };
            //var fakeVolunteerList = new List<Volunteer> { volunteerFake };

            //var expected = new List<IVolunteerViewDTO>() { new VolunteerViewDTO { FirstName = volunteerFake.Person.FirstName + " " + volunteerFake.Person.LastName, GuildName = new List<string>() } };

            //var fakeVRepo = new Mock<IDbRepository>();
            //fakeVRepo.Setup(m => m.GetAllVolunteersAndGuilds()).Returns(fakeVolunteerList);

            //// Act
            ////var volunteerService = new VolunteerService(fakeVRepo.Object);
            //var result = volunteerService.GetVolunteersViewDTO();

            //// Assert
            //Assert.Equal(expected.First().FirstName, result.First().FirstName);
        }
    }
}