using System.Collections.Generic;
using System.Diagnostics;
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

        public IList<IVolunteerViewDTO> GetVolunteersDTO() //Bliver kaldt fra vores RESTful API
        {
            var allVolunteers = _dbRepo.GetAllVolunteersAndGuilds(); //Går ned i vores DAL for at hente vores frivillige
            return _mapper.Map<IList<Volunteer>, IList<IVolunteerViewDTO>>(allVolunteers);
        }

        public int GetVolunteerByID(int id) {
            //var Volunteer = _dbRepo.GetVolunteerById(id);
            var Volunteer = _dbRepo.GetMembershipNumberFromVolunteerId(id);

            //var volunteersDTO = _mapper.Map<IList<Volunteer>, IList<IVolunteerViewDTO>>(Volunteer);

            return Volunteer;
        }
    }
}