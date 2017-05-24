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
        private RSM_EF_DbCtx.RSMContext dbctx;

        public EntityFrameworkRepository(RSM_EF_DbCtx.RSMContext dbctx) //Vi smider vores db repo som contructor så vores DI container kan instanciere den
        {
            this.dbctx = dbctx;
        }

        public void AddTimeRegistration(Registration registration)
        {
            dbctx.Registration.Add(registration);
            dbctx.SaveChanges();
        }

        public IList<Guild> GetAllGuilds()
        {
            var query = dbctx.Guild.ToList();
            return query;
        }

        public IList<object> GetAllNotConfirmedRegistrations()
        {
            throw new NotImplementedException();
        }

        public IList<Volunteer> GetAllVolunteers()
        {
            return dbctx.Volunteer.ToList();
        }

        public Volunteer GetVolunteerById(int volunteerId)
        {
            //return dbctx.Database.ExecuteSqlCommand("exec dbo.sp_Get_Vol_ID @ID", volunteerId);
            return dbctx.Database.SqlQuery<Volunteer>("dbo.sp_Get_Vol_ID @ID ={0}", volunteerId).First();
        }

        public IList<Volunteer> GetAllVolunteersAndGuilds()
        {
            //dbctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            //dbctx.Configuration.ProxyCreationEnabled = false;
            //dbctx.Configuration.LazyLoadingEnabled = false;

            var query = dbctx.Volunteer
                .Include(x => x.Person)
                .Include(x => x.Guilds)
                .ToList();

            return query;
        }

        public IList<Registration> GetAllRegistrationsUnprocessed()
        {
            var query = dbctx.Registration
            .Include(x => x.Volunteer)
            .Include(x => x.Volunteer.Person)
            .Include(x => x.Guild)
            .Where(x => x.Processed == false)
            .ToList();

            return query;
        }

        public void ChangeRegistrationStatus(int registrationId, bool status)
        {
            var registration = dbctx.Registration
           .Where(x => x.RegistrationId == registrationId).FirstOrDefault();

            registration.Processed = true;
            registration.Approved = status;
            dbctx.SaveChanges();
        }

        public int GetMembershippnrFromVoluneerID(int membershipNumber)
        {
            var volunteer = dbctx.Volunteer.Where(x => x.MembershipNumber == membershipNumber).FirstOrDefault();

            return volunteer.VolunteerId;
        }

        public IList<Registration> GetRegistrations(bool unprocessedOnly, DateTime dateFrom, DateTime dateTo)
        {
            var query = dbctx.Registration
            .Include(x => x.Volunteer)
            .Include(x => x.Volunteer.Person)
            .Include(x => x.Guild)
            .Where(x => x.Date >= dateFrom && x.Date <= dateTo && x.Processed == !unprocessedOnly)
            .ToList();

            return query;
        }

        public IList<int> GetDailyStatistics(DateTime dateFrom, DateTime dateTo, Guild guild)
        {
            foreach (DateTime day in EachDay(dateFrom, dateTo))
            {
                var list = new List<int>();

                var dailyResults = dbctx.Registration
                    .Include(x => x.Guild)
                    .Where(x => x.Date == day && x.Processed && x.Guild == guild);
                foreach (var result in dailyResults)
                {
                    list.Add(result.Hours);
                }
            }

            return list;
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}