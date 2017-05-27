using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RSMuseum.Repository.Entities;

namespace RSMuseum.Repository
{
    public class EntityFrameworkRepository : IDbRepository
    {
        private readonly RSMContext _dbCtx;

        public EntityFrameworkRepository(RSMContext dbCtx) //Vi smider vores db repo som contructor så vores DI container kan instanciere den
        {
            _dbCtx = dbCtx;
        }

        public async Task AddTimeRegistration(Registration registration) {
            _dbCtx.Registration.Add(registration);
            await _dbCtx.SaveChangesAsync();
        }

        public async Task<IList<Guild>> GetAllGuildsAsync() {
            var query = await _dbCtx.Guild.ToListAsync();
            return query;
        }

        public async Task<IList<Volunteer>> GetAllVolunteers() {
            return await _dbCtx.Volunteer.ToListAsync();
        }

        public async Task<Volunteer> GetVolunteerById(int volunteerId) {
            return await _dbCtx.Database.SqlQuery<Volunteer>("dbo.sp_Get_Vol_ID @ID ={0}", volunteerId).FirstAsync();
        }

        public async Task<IList<Volunteer>> GetAllVolunteersAndGuilds() {
            return await _dbCtx.Volunteer
                .Include(x => x.Person)
                .Include(x => x.Guilds)
                .ToListAsync();
        }

        public async Task RegistrationSetStatus(int registrationId, bool status) {
            var registration = _dbCtx.Registration.FirstOrDefault(x => x.RegistrationId == registrationId);
            registration.Processed = true;
            registration.Approved = status;
            await _dbCtx.SaveChangesAsync();
        }

        public async Task<int> GetMembershipNumberFromVolunteerIdAsync(int membershipNumber) {
            var query = await _dbCtx.Volunteer.FirstAsync(x => x.MembershipNumber == membershipNumber);
            return query.VolunteerId;
        }

        public async Task<IList<Registration>> GetRegistrationsAsync(bool? processed = null) {
            var query = _dbCtx.Registration
                .Include(x => x.Volunteer)
                .Include(x => x.Volunteer.Person)
                .Include(x => x.Guild);

            if (processed == null) {
                return await query.ToListAsync();
            }
            query = query.Where(x => x.Processed == processed);

            return await query.ToListAsync();
        }

        public async Task<int> GetStatisticsGuildDailyTotalHours(DateTime date, Guild guild) {
            return await _dbCtx.Registration
                            .Where(x => x.Date.Day == date.Date.Day &&
                                x.Date.Month == date.Date.Month &&
                                x.Date.Year == date.Date.Year &&
                                x.GuildId == guild.GuildId)
                            .SumAsync(x => (int?)x.Hours) ?? 0;
        }

        public async Task<int> GetStatisticsGuildDailyUniquePeople(DateTime date, Guild guild) {
            return await _dbCtx.Registration
                .Where(x => x.Date.Day == date.Date.Day &&
                            x.Date.Month == date.Date.Month &&
                            x.Date.Year == date.Date.Year &&
                            x.GuildId == guild.GuildId)
                .GroupBy(x => x.VolunteerId)
                .CountAsync();
        }
    }
}