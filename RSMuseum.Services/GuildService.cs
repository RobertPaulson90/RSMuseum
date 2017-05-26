using RSMuseum.Repository;
using RSMuseum.Repository.Entities;
using RSMuseum.Services.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.Services
{
    public class GuildService
    {
        private static IDbRepository _dbRepo;

        public GuildService(IDbRepository dbRepo) //Vi smider vores db repo som contructor så vores DI container kan instanciere den
        {
            _dbRepo = dbRepo;
        }

        public async Task<IList<IGuildDTO>> GetGuildsDtoAsync() {
            var guildsDtos = new List<IGuildDTO>(); //Instancisere en liste med de volunteer properties som vores View har brug for.
            var allGuilds = await _dbRepo.GetAllGuildsAsync(); //Går ned i vores DAL for at hente vores frivillige

            foreach (var item in allGuilds) //Smider data i vores VolunteerListe.
            {
                var guildDto = new GuildDto()
                {
                    GuildName = item.GuildName,
                    GuildId = item.GuildId
                };
                guildsDtos.Add(guildDto);
            }

            return guildsDtos;
        }
    }
}