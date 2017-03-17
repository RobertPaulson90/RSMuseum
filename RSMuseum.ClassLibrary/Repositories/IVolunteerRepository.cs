using RSMuseum.ClassLibrary.Entities;
using System.Collections.Generic;

namespace RSMuseum.ClassLibrary.Repositories
{
    public interface IVolunteerRepository
    {
        List<object> GetAllNotConfirmedRegistrations();

        ICollection<Volunteer> GetAllVolunteers();

        void AddTimeRegistration(Registration registration);
    }
}