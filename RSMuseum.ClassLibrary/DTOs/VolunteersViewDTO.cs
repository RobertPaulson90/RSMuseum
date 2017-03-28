using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSMuseum.ClassLibrary.Entities;

namespace RSMuseum.ClassLibrary.DTOs
{
    public class VolunteerViewDTO 
    {
        public string Name { get; set; }
        public int MembershipNumber { get; set; }
        public List<string> GuildName = new List<string>();

    }
}
