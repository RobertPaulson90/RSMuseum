using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using RSMuseum.Repository;
using RSMuseum.Services.DTOs;
using AutoMapper;
using RSMuseum.Repository.Entities;

namespace RSMuseum.Services
{
    public class VolunteerService
    {
        private static IDbRepository _dbRepo;
        private readonly IMapper _mapper;

        public VolunteerService(IDbRepository dbRepo, IMapper mapper) {
            _dbRepo = dbRepo;
            _mapper = mapper;
        }

        public async Task<IList<IVolunteerViewDTO>> GetVolunteersDtoAsync() { // Called from the API controller layer
            var allVolunteers = await _dbRepo.GetAllVolunteersAndGuilds(); // Calls down into the repository
            return _mapper.Map<IList<Volunteer>, IList<IVolunteerViewDTO>>(allVolunteers); // Use automapper to perform the mapping
        }

        public async Task<int> GetVolunteerByIdAsync(int id) {
            var volunteer = await _dbRepo.GetMembershipNumberFromVolunteerIdAsync(id);
            return volunteer;
        }
    }
}