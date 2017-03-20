using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using RSMuseum.ClassLibrary.Entities;
using RSMuseum.ClassLibrary.Repositories;
using Xunit;

namespace RSMuseum.ClassLibrary.Tests.Repositories
{
    public class VolunteerRepositoryTests
    {
        [Fact]
        public void GetAllVolunteersMethodWorks()
        {
            // Arrange
            var fakeVolunteer = new Volunteer { Id = 0 };
            var expectedData = new List<Volunteer>(new Volunteer[] { fakeVolunteer }).AsQueryable();

            var mockedDbCtxVolunteer = new Mock<DbSet<Volunteer>>();
            mockedDbCtxVolunteer.As<IQueryable<Volunteer>>().Setup(m => m.GetEnumerator()).Returns(expectedData.GetEnumerator());

            var mockedCtx = new Mock<DbRepo.RSMContext>();
            mockedCtx.Setup(m => m.Volunteer).Returns(mockedDbCtxVolunteer.Object);

            // Act
            var volunteerRepo = new VolunteerRepository(mockedCtx.Object);
            var result = volunteerRepo.GetAllVolunteers();

            // Assert
            Assert.Equal(expectedData, result);
        }
    }
}