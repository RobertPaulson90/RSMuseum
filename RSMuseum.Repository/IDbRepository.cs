using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RSMuseum.Repository.Entities;

namespace RSMuseum.Repository
{
    public interface IDbRepository // Vores main repository, alle andre repositories skal nedarve denne
    {
        Task<IList<Volunteer>> GetAllVolunteers();

        Task<IList<Volunteer>> GetAllVolunteersAndGuilds();

        Task<IList<Guild>> GetAllGuildsAsync();

        Task<Volunteer> GetVolunteerById(int volunteerId);

        Task AddTimeRegistration(Registration registration);

        Task RegistrationSetStatus(int registrationId, bool status);

        Task<IList<Registration>> GetRegistrationsAsync(bool? processed = null);

        Task<int> GetMembershipNumberFromVolunteerIdAsync(int membershipNumber);

        Task<int> GetStatisticsGuildDailyTotalHours(DateTime date, Guild guild);

        Task<int> GetStatisticsGuildDailyUniquePeople(DateTime date, Guild guild);
    }
}