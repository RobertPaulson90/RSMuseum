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
                    .RuleFor(o => o.ZipCode, f => f.PickRandom(zipcodes))
                    .RuleFor(o => o.Street, f => f.Address.StreetAddress())
                    .Generate();

                var fakePerson = new Faker<Entities.Person>()
                    .RuleFor(o => o.Address, f => fakeAddress)
                    .RuleFor(o => o.Email, f => f.Internet.Email())
                    .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                    .RuleFor(o => o.LastName, f => f.Name.LastName())
                    .RuleFor(o => o.Phone, f => f.Random.Int(10000000, 99999999).ToString())
                    .Generate();

                var fakeVolunteer = new Faker<Volunteer>()
                    .RuleFor(o => o.Guilds, f => f.PickRandom(guilds, 2).ToList())
                    .RuleFor(o => o.IsActive, f => f.Random.Bool())
                    .RuleFor(o => o.MembershipNumber, f => f.Random.Int(0000, 9999))
                    .RuleFor(o => o.Person, f => fakePerson)
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