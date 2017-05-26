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

        public StatisticsService(IDbRepository dbRepo) {
            this._dbRepo = dbRepo;
        }

        public async Task<List<GuildStatisticsDto>> GetGuildsStatisticsDtosAsync(DateTime dateFrom, DateTime dateTo) {
            var guildStatisticsDtos = new List<GuildStatisticsDto>();
            var guilds = await _dbRepo.GetAllGuildsAsync();
            foreach (var guild in guilds) {
                var guildStatDto = new GuildStatisticsDto
                {
                    GuildId = guild.GuildId,
                    GuildName = guild.GuildName,
                    Stats = new List<StatDTO>()
                };

                List<Task<int>> tasks = new List<Task<int>>();
                foreach (var day in EachDay(dateFrom, dateTo)) {
                    tasks.Add(_dbRepo.GetStatisticsGuildDailyTotalHours(day, guild));
                }
                await Task.WhenAll(tasks);

                var days = EachDay(dateFrom, dateTo).ToList();
                for (int i = 0; i < tasks.Count; i++) {
                    var dailyGuildStat = new StatDTO
                    {
                        Date = days[i],
                        TotalHours = tasks[i].Result
                    };
                    guildStatDto.Stats.Add(dailyGuildStat);
                }

                guildStatisticsDtos.Add(guildStatDto);
            }

            return guildStatisticsDtos;
        }

        private static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru) {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}