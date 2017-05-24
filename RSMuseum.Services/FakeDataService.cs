using System;
using System.Linq;
using Bogus;
using RSMuseum.Repository.Entities;

namespace RSMuseum.Services

{
    public class GenerateFakeData
    {
        private RSMContext _dbCtx;

        // This class should rarely be used. Customize constructor before running via. DI-container
        // Acts as a type of "Seed" for generating random believable fake data for testing environment

        public GenerateFakeData(RSMContext dbCtx)
        {
            _dbCtx = dbCtx;

            //var amountOfFakeVolunteersToAdd = 250;
            //var amountOfFakeRegistrationsToAdd = 100;

            //AddFakeVolunteersToDb(amountOfFakeVolunteersToAdd);
            //AddFakeRegistrationsToDb(amountOfFakeRegistrationsToAdd);
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

                var fakePerson = new Faker<Repository.Entities.Person>()
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
            var guilds = _dbCtx.Guild.ToList();
            var volunteers = _dbCtx.Volunteer.ToList();

            for (int i = 0; i < count; i++)
            {
                var fakeRegistration = new Faker<Registration>()
                    .RuleFor(x => x.Hours, y => y.Random.Int(0000, 0012))
                    .RuleFor(x => x.Date, y => y.Date.Recent())
                    .RuleFor(x => x.Approved, y => y.Random.Bool())
                    .RuleFor(x => x.GuildId, y => y.PickRandom(guilds).GuildId)
                    .RuleFor(x => x.VolunteerId, y => y.PickRandom(volunteers).VolunteerId)
                    .RuleFor(x => x.DateTimeRegistered, y => y.Date.Recent())
                    .Generate();

                _dbCtx.Registration.Add(fakeRegistration);
                _dbCtx.SaveChanges();
            }
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