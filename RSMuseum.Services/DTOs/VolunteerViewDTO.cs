using System.Collections.Generic;

namespace RSMuseum.Services.DTOs
{
    public class VolunteerViewDTO : IVolunteerViewDTO
    {
        public virtual string Name { get; set; }
        public virtual int MembershipNumber { get; set; }
        public List<string> GuildName { get; set; }
    }
}