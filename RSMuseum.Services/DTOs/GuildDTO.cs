using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.Services.DTOs
{
    class GuildDTO : IGuildDTO
    {
        public int GuildId { get; set; }
        public string GuildName { get; set; }
    }
}
