using RSMuseum.ClassLibrary.Entities;
using SimpleInjector;
using Xunit;
using Moq;
using static RSMuseum.ClassLibrary.DbRepo;
using System.Data.Entity;
using RSMuseum.ClassLibrary.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RSMuseum.ClassLibrary.Tests
{
    public class VolunteerRepositoryTests
    {
        private RSMContext mockedctx;
        private Mock<RSMContext> realctx;

        public VolunteerRepositoryTests()
        {
            // mockedctx = new Mock<RSMContext>();
            new DI(true);
        }

        [Fact]
        public void GetAllVolunteersMethodWorks()
        {
            // Arrange
            //var fakeVolunteer = new Volunteer { };
            var expected = new List<Volunteer>(new Volunteer[]
                    { new Volunteer { Id = 0 } });

            var fakeVolunteerRepo = new Mock<IVolunteerRepository>();
            fakeVolunteerRepo.Setup(vo => vo.GetAllVolunteers()).Returns(expected);

            var mockedvolunteer = new Mock<DbSet<Volunteer>>();
            mockedvolunteer.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => expected.Add(s));

            mockedvolunteer.Setup(m => m.Add(expected[0]));
            //mockedvolunteer.Object.Add(expected[0]);
            var mockedctx = new Mock<RSMContext>();
            mockedctx.Setup(m => m.Volunteer).Returns(mockedvolunteer.Object);

            // Act
            var volunteerRepo = new VolunteerRepository(mockedctx.Object);

            // Assert
            Assert.Equal(expected, volunteerRepo.GetAllVolunteers());
        }
    }
}