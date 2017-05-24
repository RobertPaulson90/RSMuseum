using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RSMuseum.Repository.Entities;
using RSMuseum.Repository;

namespace RSMuseum.Repository
{
    public class EntityFrameworkRepository : IDbRepository
    {
        private readonly RSMContext _dbCtx;

        public EntityFrameworkRepository(RSMContext dbCtx) //Vi smider vores db repo som contructor så vores DI container kan instanciere den
        {
            _dbCtx = dbCtx;
        }

        public void AddTimeRegistration(Registration registration) {
            _dbCtx.Registration.Add(registration);
            _dbCtx.SaveChanges();
        }

        public IList<Guild> GetAllGuilds() {
            var query = _dbCtx.Guild.ToList();
            return query;
        }

        public IList<Volunteer> GetAllVolunteers() {
            return _dbCtx.Volunteer.ToList();
        }

        public Volunteer GetVolunteerById(int volunteerId) {
            return _dbCtx.Database.SqlQuery<Volunteer>("dbo.sp_Get_Vol_ID @ID ={0}", volunteerId).First();
        }

        public IList<Volunteer> GetAllVolunteersAndGuilds() {
            return _dbCtx.Volunteer
                .Include(x => x.Person)
                .Include(x => x.Guilds)
                .ToList();
        }

        public void ChangeRegistrationStatus(int registrationId, bool status) {
            var registration = _dbCtx.Registration.FirstOrDefault(x => x.RegistrationId == registrationId);
            registration.Processed = true;
            registration.Approved = status;
            _dbCtx.SaveChanges();
        }

        public int GetMembershipNumberFromVolunteerId(int membershipNumber) {
            return _dbCtx.Volunteer.FirstOrDefault(x => x.MembershipNumber == membershipNumber).VolunteerId;
        }

        public IList<Registration> GetRegistrations(bool? processed = null) {
            var query = _dbCtx.Registration
                .Include(x => x.Volunteer)
                .Include(x => x.Volunteer.Person)
                .Include(x => x.Guild);

            if (processed == null) {
                return query.ToList();
            }
            else {
                query = query.Where(x => x.Processed == processed);
            }
            return query.ToList();
        }

        public int GetStatisticsGuildDailyTotalHours(DateTime date, Guild guild) {
            return _dbCtx.Registration
                             .Where(x => x.Date.Day == date.Date.Day &&
                                x.Date.Month == date.Date.Month &&
                                x.Date.Year == date.Date.Year &&
                                x.GuildId == guild.GuildId)
                             .Sum(x => (int?)x.Hours) ?? 0;
        }

        public int GetStatisticsGuildDailyUniquePeople(DateTime date, Guild guild) {
            return _dbCtx.Registration
                .Include(x => x.Guild)
                .Where(x => x.Guild == guild)
                .GroupBy(x => x.VolunteerId)
                .Count();
        }
    }
}