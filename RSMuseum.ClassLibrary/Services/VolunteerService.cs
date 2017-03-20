using System.Collections.Generic;
using RSMuseum.ClassLibrary.Entities;
using RSMuseum.ClassLibrary.Repositories;

namespace RSMuseum.ClassLibrary.Services
{
    public class VolunteerService
    {
        private static IVolunteerRepository _vRepo;

        public VolunteerService(IVolunteerRepository volunteerRepository)
        {
            _vRepo = volunteerRepository;
        }

        public IList<Volunteer> GetAllVolunteers()
        {
            return _vRepo.GetAllVolunteers();
        }
    }
}