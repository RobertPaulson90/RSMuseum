using RSMuseum.ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static RSMuseum.ClassLibrary.DbRepo;

namespace RSMuseum.ClassLibrary.Repositories
{
    public class EntityFrameworkRepository : IDbRepository
    {
        private RSMContext dbctx;

        public EntityFrameworkRepository(RSMContext dbctx)
        {
            this.dbctx = dbctx;
        }

        public void AddTimeRegistration(Registration registration)
        {
            throw new NotImplementedException();
        }

        public IList<object> GetAllNotConfirmedRegistrations()
        {
            throw new NotImplementedException();
        }

        public IList<Volunteer> GetAllVolunteers()
        {
            return dbctx.Volunteer.ToList();
        }
        public IList<Volunteer> GetAllVolunteersAndGuilds()
        {
            dbctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            IQueryable<Volunteer> query = dbctx.Volunteer;
            query
                .Include(x => x.Person)
                .Include(x => x.Guilds)
                .ToList();
            return query.ToList();
        }

    }
}