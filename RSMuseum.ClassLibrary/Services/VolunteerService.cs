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

        public VolunteerService(IDbRepository volunteerRepository)
        {
            _dbRepo = volunteerRepository;
        }

        public List<VolunteerViewDTO> GetVolunteersViewDTO()
        {
            var volunteersDTO = new List<VolunteerViewDTO>();
            var allVolunteersAndGuilds = _dbRepo.GetAllVolunteersAndGuilds();

            foreach (var item in allVolunteersAndGuilds)
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