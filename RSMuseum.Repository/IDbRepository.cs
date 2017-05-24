using System;
using System.Collections.Generic;
using RSMuseum.Repository.Entities;

namespace RSMuseum.Repository
{
    public interface IDbRepository // Vores main repository, alle andre repositories skal nedarve denne
    {
        IList<object> GetAllNotConfirmedRegistrations();

        IList<Volunteer> GetAllVolunteers();

        IList<Volunteer> GetAllVolunteersAndGuilds();

        IList<Guild> GetAllGuilds();

        Volunteer GetVolunteerById(int volunteerId);

        IList<Registration> GetAllRegistrationsUnprocessed();

        void AddTimeRegistration(Registration registration);

        void ChangeRegistrationStatus(int registrationId, bool status);
        IList<Registration> GetRegistrations(bool unprocessedOnly, DateTime dateFrom, DateTime dateTo);

        int GetMembershippnrFromVoluneerID(int membershipNumber);

        int GetStatisticsGuildDailyHours(DateTime date, Guild guild);

        int GetStatisticsGuildDailyPeople(DateTime date, Guild guild);



    }
}