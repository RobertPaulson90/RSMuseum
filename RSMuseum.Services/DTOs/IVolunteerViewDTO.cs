using System.Collections.Generic;

namespace RSMuseum.Services.DTOs
{
    public interface IVolunteerViewDTO
    {
        int MembershipNumber { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        List<string> GuildName { get; set; }
    }
}