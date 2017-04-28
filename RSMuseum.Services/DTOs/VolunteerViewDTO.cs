using System.Collections.Generic;

namespace RSMuseum.Services.DTOs
{
    public class VolunteerViewDTO : IVolunteerViewDTO
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual int MembershipNumber { get; set; }
        public List<string> GuildName { get; set; }
    }
}