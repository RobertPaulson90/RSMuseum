using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using RSMuseum.Repository;
using RSMuseum.Services.DTOs;

namespace RSMuseum.Services
{
    public class StatisticsService
    {
        private readonly IDbRepository _dbRepo;

        public StatisticsService(IDbRepository dbRepo)
        {
            this._dbRepo = dbRepo;
        }

        public List<GuildStatisticsDTO> GetGuildStatisticsDTOs(DateTime dateFrom, DateTime dateTo)
        {
            var guildStatsDTOs = new List<GuildStatisticsDTO>();
            var guilds = _dbRepo.GetAllGuilds();
            foreach (var guild in guilds)
            {
                var guildStatDTO = new GuildStatisticsDTO
                {
                    GuildId = guild.GuildId,
                    GuildName = guild.GuildName,
                    Stats = new List<StatDTO>()
                };

                foreach (var day in EachDay(dateFrom, dateTo))
                {
                    var dailyGuildStat = new StatDTO
                    {
                        Date = day,
                        TotalHours = _dbRepo.GetStatisticsGuildDailyTotalHours(day, guild),
                        // TotalPeople = _dbRepo.GetStatisticsGuildDailyHours(day, guild)
                    };

                    guildStatDTO.Stats.Add(dailyGuildStat);
                }

                guildStatsDTOs.Add(guildStatDTO);
            }

            return guildStatsDTOs;
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
