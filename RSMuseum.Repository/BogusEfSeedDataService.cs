using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Bogus;
using RSMuseum.Repository.Entities;

namespace RSMuseum.Repository

{
    public class BogusEfSeedDataService
    {
        // This class functions as a seed for generating random believable fake data for testing
        // Consult Paul W. for any questions

        private readonly RSMContext _dbCtx;

        public BogusEfSeedDataService(RSMContext dbCtx) {
            _dbCtx = dbCtx;
        }

        public async Task Initialize() {
            await MaintainBogusGuilds(5);
            await MaintainBogusZipcodes(25);
            await MaintainBogusVolunteers(150);
            await MaintainBogusRegistrationsRecentUnapproved(30);
            await MaintainBogusRegistrationsLongTermApproved(600);
        }

        private async Task MaintainBogusGuilds(int count) {
            var current = await _dbCtx.Guild.CountAsync();
            if (current >= count) {
                return;
            }
            count = count - current;

            for (int i = 0; i < count; i++) {
                _dbCtx.Guild.Add(new Guild { GuildName = $"Laug {i}" });
            }

            await _dbCtx.SaveChangesAsync();
        }

        private async Task MaintainBogusZipcodes(int count) {
            var current = await _dbCtx.ZipCodeTable.CountAsync();
            if (current >= count) {
                return;
            }
            count = count - current;

            for (int i = 0; i < count; i++) {
                var bogusZip = new Faker<ZipCodeTable>()
                    .RuleFor(x => x.City, y => y.Address.City())
                    .RuleFor(x => x.ZipCode, y => y.Random.Int(1000, 9999));
                _dbCtx.ZipCodeTable.Add(bogusZip);
            }

            await _dbCtx.SaveChangesAsync();
        }

        private async Task MaintainBogusVolunteers(int count) {
            var current = await _dbCtx.Volunteer.CountAsync();
            if (current >= count) {
                return;
            }
            count = count - current;

            var guilds = await _dbCtx.Guild.ToListAsync();

            for (var i = 0; i < count; i++) {
                var zipcodes = await _dbCtx.ZipCodeTable.ToListAsync();
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
                    .RuleFor(x => x.Guilds, y => y.PickRandom(guilds, y.Random.Int(1, 3)).ToList())
                    .RuleFor(x => x.IsActive, y => y.Random.Bool())
                    .RuleFor(x => x.MembershipNumber, y => y.Random.Int(1000, 9999))
                    .RuleFor(x => x.Person, y => fakePerson)
                    .Generate();

                _dbCtx.Volunteer.Add(fakeVolunteer);
            }

            await _dbCtx.SaveChangesAsync();
        }

        private async Task MaintainBogusRegistrationsRecentUnapproved(int count) {
            var current = await _dbCtx.Registration.Where(x => !x.Approved).CountAsync();
            if (current >= count) {
                return;
            }
            count = count - current;

            var guilds = await _dbCtx.Guild.ToListAsync();
            var volunteers = await _dbCtx.Volunteer.ToListAsync();

            for (int i = 0; i < count; i++) {
                var fakeDate = new Faker().Date.Recent(30);
                var fakeRegistration = new Faker<Registration>()
                    .RuleFor(x => x.Hours, y => y.Random.Int(1, 6))
                    .RuleFor(x => x.Date, y => fakeDate)
                    .RuleFor(x => x.Approved, y => false)
                    .RuleFor(x => x.GuildId, y => y.PickRandom(guilds).GuildId)
                    .RuleFor(x => x.VolunteerId, y => y.PickRandom(volunteers).VolunteerId)
                    .RuleFor(x => x.DateTimeRegistered, y => fakeDate)
                    .RuleFor(x => x.Processed, y => false)
                    .Generate();

                _dbCtx.Registration.Add(fakeRegistration);
            }

            await _dbCtx.SaveChangesAsync();
        }

        private async Task MaintainBogusRegistrationsLongTermApproved(int count) {
            var current = await _dbCtx.Registration.Where(x => x.Approved).CountAsync();
            if (current >= count) {
                return;
            }
            count = count - current;

            var guildsTask = _dbCtx.Guild.ToListAsync();
            var volunteersTask = _dbCtx.Volunteer.ToListAsync();

            await Task.WhenAll(guildsTask, volunteersTask);

            for (int i = 0; i < count; i++) {
                var fakeDate = new Faker().Date.Between(DateTime.Now, DateTime.Today.AddYears(-1)); // Random day between now and 1 year ago
                var fakeRegistration = new Faker<Registration>()
                    .RuleFor(x => x.Hours, y => y.Random.Int(1, 6))
                    .RuleFor(x => x.Date, y => fakeDate)
                    .RuleFor(x => x.Approved, y => true)
                    .RuleFor(x => x.GuildId, y => y.PickRandom(guildsTask.Result).GuildId)
                    .RuleFor(x => x.VolunteerId, y => y.PickRandom(volunteersTask.Result).VolunteerId)
                    .RuleFor(x => x.DateTimeRegistered, y => fakeDate)
                    .RuleFor(x => x.Processed, y => true)
                    .Generate();

                _dbCtx.Registration.Add(fakeRegistration);
            }

            await _dbCtx.SaveChangesAsync();
        }
    }
}