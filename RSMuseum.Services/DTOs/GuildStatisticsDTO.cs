using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.Services.DTOs
{
    public class GuildStatisticsDto // 1 GuildStatisticsDTO per. guild
    {
        public string GuildName { get; set; }
        public int GuildId { get; set; }
        public List<StatDTO> Stats { get; set; }
    }

    public class StatDTO
    {
        public DateTime Date { get; set; }
        public int TotalHours { get; set; }
        public int TotalPeople { get; set; }
    }
}