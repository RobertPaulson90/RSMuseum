using System.Collections.Generic;
using RSMuseum.ClassLibrary.Entities;
using RSMuseum.ClassLibrary.Repositories;
using RSMuseum.ClassLibrary.DTOs;
using System.Linq;
using System.Data.Entity;

namespace RSMuseum.ClassLibrary.Services
{
    public class VolunteerService
    {
        private static IDbRepository _dbRepo;

        public VolunteerService(IDbRepository volunteerRepository) //Vi smider vores db repo som contructor så vores DI container kan instanciere den
        {
            _dbRepo = volunteerRepository;
        }

        public List<VolunteerViewDTO> GetVolunteersViewDTO() //Bliver kaldt fra vores RESTful API
        {
            var volunteersDTO = new List<VolunteerViewDTO>(); //Instancisere en liste med de volunteer properties som vores View har brug for.
            var allVolunteers = _dbRepo.GetAllVolunteers(); //Går ned i vores DAL for at hente vores frivillige

            foreach (var item in allVolunteers) //Smider data i vores VolunteerListe.
            {
                var volunteerDTO = new VolunteerViewDTO();
                volunteerDTO.Name = item.Person.FirstName + " " + item.Person.LastName;
                volunteerDTO.MembershipNumber = item.MembershipNumber;
                foreach (var guild in item.Guilds)
                {
                    volunteerDTO.GuildName.Add(guild.GuildName);
                }
                volunteersDTO.Add(volunteerDTO);
            }

            return volunteersDTO;
        }
    }
}