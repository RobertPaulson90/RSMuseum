using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RSMuseum.ClassLibrary.Entities;
using RSMuseum.ClassLibrary.Repositories;
using RSMuseum.ClassLibrary.Services;
using Xunit;

namespace RSMuseum.ClassLibrary.Tests.Services
{
    public class VolunteerServiceTests
    {
        //[Fact]
        //public void GetAllVolunteersMethodWorks()
        //{
        //    // Arrange
        //    var fakeVolunteer = new Volunteer { VolunteerId = 0 };
        //    var expectedData = new List<Volunteer>(new Volunteer[] { fakeVolunteer });

        //    var fakeVRepo = new Mock<IDbRepository>();
        //    fakeVRepo.Setup(m => m.GetAllVolunteers()).Returns(expectedData);

        //    // Act
        //    var volunteerService = new VolunteerService(fakeVRepo.Object);
        //    var result = volunteerService.GetVolunteersViewDTO();

        //    // Assert
        //    Assert.Equal(expectedData, result);
        //}
    }
}