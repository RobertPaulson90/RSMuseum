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

        public VolunteerService(IDbRepository volunteerRepository) //Vi smider vores db repo som contructor så vores DI container kan instanciere den
        {
            _dbRepo = volunteerRepository;
        }

        public IList<IVolunteerViewDTO> GetVolunteersViewDTO() //Bliver kaldt fra vores RESTful API
        {
            var allVolunteers = _dbRepo.GetAllVolunteersAndGuilds(); //Går ned i vores DAL for at hente vores frivillige

            var volunteersDTO = AutoMapperConfiguration.Mapper.Map<IList<Volunteer>, IList<IVolunteerViewDTO>>(allVolunteers);

            return volunteersDTO;
        }
    }
}