using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using RSMuseum.ClassLibrary.Entities;
using RSMuseum.ClassLibrary.Repositories;
using RSMuseum.ClassLibrary.Tests.TestHelpers;
using Xunit;

namespace RSMuseum.ClassLibrary.Tests.Repositories
{
    public class VolunteerRepositoryTests
    {
        [Fact]
        public void GetAllVolunteersMethodWorks() // SUT er repository-metoden, som afhænger af entity framework som vi er nødsaget til at mock så godt som muligt
        {
            // Arrange
            var fakeVolunteer = new Volunteer { Id = 0 }; // her opretter vi en "falsk" volunteer (uden brug af Moq)
            var expectedData = new List<Volunteer>(new Volunteer[] { fakeVolunteer }); // smider vores falsk volunteer i en ny liste

            var mockedDbCtxVolunteer = new Mock<DbSet<Volunteer>>(); // Så mocker vi vores <DbSet<Volunteer>>
            mockedDbCtxVolunteer.As<IQueryable<Volunteer>>().Setup(m => m.GetEnumerator()).Returns(expectedData.GetEnumerator());
            // Ovenstående linje er det essentielle, da vi snyder .ToList() på entiteten

            var mockedCtx = new Mock<DbRepo.RSMContext>(); // Mock hele RSMContext, da det jo selvfølgelig er en dependency til EntityFrameworkRepository
            mockedCtx.Setup(m => m.Volunteer).Returns(mockedDbCtxVolunteer.Object); // Og så skal mockedCtx.Volunteer være tilknyttet til mockedCtx før vi går videre

            // Act
            var volunteerRepo = new EntityFrameworkRepository(mockedCtx.Object);
            var result = volunteerRepo.GetAllVolunteers();

            // Assert
            Assert.Equal(expectedData, result);
        }
    }
}