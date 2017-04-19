﻿using System.Collections.Generic;
using RSMuseum.Repository.Entities;

namespace RSMuseum.ClassLibrary
{
    public interface IDbRepository // Vores main repository, alle andre repositories skal nedarve denne
    {
        IList<object> GetAllNotConfirmedRegistrations();

        IList<Volunteer> GetAllVolunteers();

        IList<Volunteer> GetAllVolunteersAndGuilds();

        void AddTimeRegistration(Registration registration);
    }
}