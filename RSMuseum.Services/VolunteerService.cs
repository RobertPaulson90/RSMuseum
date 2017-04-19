using System.Collections.Generic;
using System.Diagnostics;
using RSMuseum.ClassLibrary;
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
            var volunteersDTO = new List<IVolunteerViewDTO>(); //Instancisere en liste med de volunteer properties som vores View har brug for.

            var allVolunteers = _dbRepo.GetAllVolunteersAndGuilds(); //Går ned i vores DAL for at hente vores frivillige

            foreach (var item in allVolunteers) //Smider data i vores VolunteerListe.
            {
                IVolunteerViewDTO volunteerDTO = new VolunteerViewDTO()
                {
                    Name = item.Person.FirstName + " " + item.Person.LastName,
                    MembershipNumber = item.MembershipNumber
                };
                volunteerDTO.GuildName = new List<string>();
                foreach (var guild in item.Guilds)
                {
                    volunteerDTO.GuildName.Add(guild.GuildName);
                }
                volunteersDTO.Add(volunteerDTO);
            }

            return volunteersDTO;
        }

        public IList<IVolunteerViewDTO> GetVolunteersViewDTOwithAutoMapper() //Bliver kaldt fra vores RESTful API
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<List<Volunteer>, List<VolunteerViewDTO>>());
            var mapper = config.CreateMapper();

            var volunteersDTO = new List<IVolunteerViewDTO>(); //Instancisere en liste med de volunteer properties som vores View har brug for.
            var allVolunteers = _dbRepo.GetAllVolunteersAndGuilds(); //Går ned i vores DAL for at hente vores frivillige

            foreach (var volunteerItem in allVolunteers) //Smider data i vores VolunteerListe.
            {
                VolunteerViewDTO dto = mapper.Map<VolunteerViewDTO>(volunteerItem);



                IVolunteerViewDTO volunteerDTO = new VolunteerViewDTO()
                {
                    Name = volunteerItem.Person.FirstName + " " + volunteerItem.Person.LastName,
                    MembershipNumber = volunteerItem.MembershipNumber
                };
                volunteerDTO.GuildName = new List<string>();
                foreach (var guild in volunteerItem.Guilds)
                {
                    volunteerDTO.GuildName.Add(guild.GuildName);
                }
                volunteersDTO.Add(volunteerDTO);
            }

            return volunteersDTO;
        }
    }
}