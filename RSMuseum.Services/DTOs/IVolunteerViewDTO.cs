using System.Collections.Generic;

namespace RSMuseum.Services.DTOs
{
    public interface IVolunteerViewDTO
    {
        int MembershipNumber { get; set; }
        string Name { get; set; }
        List<string> GuildName { get; set; }
    }
}