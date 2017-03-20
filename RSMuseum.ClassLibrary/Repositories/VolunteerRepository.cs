using RSMuseum.ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RSMuseum.ClassLibrary.DbRepo;

namespace RSMuseum.ClassLibrary.Repositories
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private RSMContext dbctx;

        public VolunteerRepository(RSMContext dbctx)
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
    }
}