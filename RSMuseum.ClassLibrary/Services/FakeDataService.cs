using System;
using System.Linq;
using RSMuseum.ClassLibrary.Entities;
using Bogus;

namespace RSMuseum.ClassLibrary.Tests.Services

{
    public class GenerateFakeData
    {
        private DbRepo.RSMContext _dbCtx;

        // This class should rarely be used. Customize constructor before running via. DI-container
        // Acts as a type of "Seed" for generating random believable fake data for testing environment

        public GenerateFakeData(DbRepo.RSMContext dbCtx)
        {
            _dbCtx = dbCtx;

            var amountOfFakeVolunteersToAdd = 50;
            var amountOfFakeRegistrationsToAdd = 200;

            AddFakeVolunteersToDb(amountOfFakeVolunteersToAdd);
            AddFakeRegistrationsToDb(amountOfFakeRegistrationsToAdd);
        }

        public void AddFakeVolunteersToDb(int count)
        {
            var guilds = _dbCtx.Guild.ToList();

            for (int i = 0; i < count; i++)
            {
                var zipcodes = _dbCtx.ZipCodeTable.ToList();
                var fakeAddress = new Faker<Address>()
                    .RuleFor(x => x.ZipCode, y => y.PickRandom(zipcodes))
                    .RuleFor(x => x.Street, y => y.Address.StreetAddress())
                    .Generate();

                var fakePerson = new Faker<Entities.Person>()
                    .RuleFor(x => x.Address, y => fakeAddress)
                    .RuleFor(x => x.Email, y => y.Internet.Email())
                    .RuleFor(x => x.FirstName, y => y.Name.FirstName())
                    .RuleFor(x => x.LastName, y => y.Name.LastName())
                    .RuleFor(x => x.Phone, y => y.Random.Int(10000000, 99999999).ToString())
                    .Generate();

                var fakeVolunteer = new Faker<Volunteer>()
                    .RuleFor(x => x.Guilds, y => y.PickRandom(guilds, 2).ToList())
                    .RuleFor(x => x.IsActive, y => y.Random.Bool())
                    .RuleFor(x => x.MembershipNumber, y => y.Random.Int(0000, 9999))
                    .RuleFor(x => x.Person, y => fakePerson)
                    .Generate();

                _dbCtx.Volunteer.Add(fakeVolunteer);
                _dbCtx.SaveChanges();
            }
        }

        public void AddFakeRegistrationsToDb(int count)
        {
            throw new NotImplementedException();
        }
    }
}

/* WIPE DB SQL SCRIPT (DO NOT RUN)

-- disable referential integrity
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
GO

EXEC sp_MSForEachTable 'DELETE FROM ?'
GO

-- enable referential integrity again
EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'
GO
*/