using RSMuseum.ClassLibrary.Entities;
using System.Collections.Generic;

namespace RSMuseum.ClassLibrary.Repositories
{
    public interface IDbRepository
    {
        IList<object> GetAllNotConfirmedRegistrations();

        IList<Volunteer> GetAllVolunteers();

        void AddTimeRegistration(Registration registration);
    }
}