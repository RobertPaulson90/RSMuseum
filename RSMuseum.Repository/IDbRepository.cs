using System;
using System.Collections.Generic;
using RSMuseum.Repository.Entities;

namespace RSMuseum.Repository
{
    public interface IDbRepository // Vores main repository, alle andre repositories skal nedarve denne
    {
        IList<Volunteer> GetAllVolunteers();

        IList<Volunteer> GetAllVolunteersAndGuilds();

        IList<Guild> GetAllGuilds();

        Volunteer GetVolunteerById(int volunteerId);

        void AddTimeRegistration(Registration registration);

        void ChangeRegistrationStatus(int registrationId, bool status);

        IList<Registration> GetRegistrations(bool? processed = null);

        int GetMembershipNumberFromVolunteerId(int membershipNumber);

        int GetStatisticsGuildDailyTotalHours(DateTime date, Guild guild);

        int GetStatisticsGuildDailyUniquePeople(DateTime date, Guild guild);
    }
}