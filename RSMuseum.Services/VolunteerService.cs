using System.Collections.Generic;
using System.Diagnostics;
using RSMuseum.Repository;
using RSMuseum.Services.DTOs;

namespace RSMuseum.Services
{
    public class VolunteerService
    {
        private static IDbRepository _dbRepo;

        public VolunteerService(IDbRepository dbRepo) //Vi smider vores db repo som contructor så vores DI container kan instanciere den
        {
            _dbRepo = dbRepo;
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
    }
}