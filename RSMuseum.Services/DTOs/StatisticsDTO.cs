using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.Services.DTOs
{
    public class StatisticsDTO
    {
        public string GuildName { get; set; }
        public int GuildId { get; set; }
        public List<GuildStatDTO> Data { get; set; }
    }

    public class GuildStatDTO
    {
        public DateTime Date { get; set; }
        public int TotalHours { get; set; }
    }
}