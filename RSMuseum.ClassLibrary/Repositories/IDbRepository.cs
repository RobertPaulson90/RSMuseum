using RSMuseum.ClassLibrary.Entities;
using System.Collections.Generic;

namespace RSMuseum.ClassLibrary.Repositories
{
    public interface IDbRepository // Vores main repository, alle andre repositories skal nedarve denne
    {
        IList<object> GetAllNotConfirmedRegistrations();

        IList<Volunteer> GetAllVolunteers();

        void AddTimeRegistration(Registration registration);
    }
}