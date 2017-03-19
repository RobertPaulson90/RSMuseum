using RSMuseum.ClassLibrary.Entities;
using System.Collections.Generic;

namespace RSMuseum.ClassLibrary.Repositories
{
    public interface IVolunteerRepository
    {
        IList<object> GetAllNotConfirmedRegistrations();

        IList<Volunteer> GetAllVolunteers();

        void AddTimeRegistration(Registration registration);
    }
}