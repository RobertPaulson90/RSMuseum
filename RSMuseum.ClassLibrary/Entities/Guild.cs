using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.ClassLibrary.Entities
{
    public class Guild
    {
        public int GuildId { get; set; }

        [Required]
        public string GuildName { get; set; }
    }
}
