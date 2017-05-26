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

        public VolunteerService(IDbRepository dbRepo, IMapper mapper) //Vi smider vores db repo som contructor så vores DI container kan instanciere den
        {
            _dbRepo = dbRepo;
            _mapper = mapper;
        }

        public async Task<IList<IVolunteerViewDTO>> GetVolunteersDtoAsync() //Bliver kaldt fra vores RESTful API
        {
            var allVolunteers = await _dbRepo.GetAllVolunteersAndGuilds(); //Går ned i vores DAL for at hente vores frivillige
            return _mapper.Map<IList<Volunteer>, IList<IVolunteerViewDTO>>(allVolunteers);
        }

        public async Task<int> GetVolunteerByIdAsync(int id) {
            var volunteer = await _dbRepo.GetMembershipNumberFromVolunteerIdAsync(id);
            return volunteer;
        }
    }
}