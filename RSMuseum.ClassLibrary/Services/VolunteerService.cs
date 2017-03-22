using System.Collections.Generic;
using RSMuseum.ClassLibrary.Entities;
using RSMuseum.ClassLibrary.Repositories;

namespace RSMuseum.ClassLibrary.Services
{
    public class VolunteerService
    {
        private static IDbRepository _vRepo;

        public VolunteerService(IDbRepository volunteerRepository)
        {
            _vRepo = volunteerRepository;
        }

        public IList<Volunteer> GetAllVolunteers()
        {
            return _vRepo.GetAllVolunteers();
        }
    }
}