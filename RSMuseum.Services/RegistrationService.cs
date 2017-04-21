using RSMuseum.Repository;
using RSMuseum.Repository.Entities;
using RSMuseum.Services.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RSMuseum.Services
{
   public class RegistrationService
    {
        private static IDbRepository _dbRepo;
        public RegistrationService(IDbRepository dbRepo) //Vi smider vores db repo som contructor så vores DI container kan instanciere den
        {
            _dbRepo = dbRepo;
        }

        public bool AddRegistration(Registration registration)
        {

            //JsonConvert.DeserializeObject<Registration>(registration);

            var Registering = (Registration)registration;

            //var guildsDTO = new List<IGuildDTO>(); //Instancisere en liste med de volunteer properties som vores View har brug for.

            //var allGuilds = _dbRepo.GetAllGuilds(); //Går ned i vores DAL for at hente vores frivillige

            //foreach (var item in allGuilds) //Smider data i vores VolunteerListe.
            //{
            //    var guildDTO = new GuildDTO()
            //    {
            //        GuildName = item.GuildName,
            //        GuildId = item.GuildId
            //    };
            //    guildsDTO.Add(guildDTO);
            //}

            return true;
        }

        //_________________________________________________________________--


        public IList<IRegistrationDTO> GetAllRegistrationsUnprocessed()
        {
            var registrationsDTO = new List<IRegistrationDTO>(); //Instancisere en liste med de volunteer properties som vores View har brug for.
            var allRegistrationsUnprocessed = _dbRepo.GetAllRegistrationsUnprocessed(); //Går ned i vores DAL for at hente vores frivillige

            foreach (var item in allRegistrationsUnprocessed) //Smider data i vores VolunteerListe.
            {
                var volunteer = item.Volunteer;
                var registrationDTO = new RegistrationDTO()
                {
                    Approved = item.Approved,
                    Date = item.Date,
                    DateTimeRegistered = item.DateTimeRegistered,
                    Guild = new GuildDTO {
                        GuildName = item.Guild.GuildName,
                        GuildId = item.Guild.GuildId,
                    },
                    Hours = item.Hours,
                    Processed = item.Processed,
                    RegistrationId = item.RegistrationId,
                    Volunteer = new VolunteerViewDTO {
                        Name = item.Volunteer.Person.FirstName + " " + item.Volunteer.Person.LastName,
                        MembershipNumber = item.Volunteer.MembershipNumber }
                };
                registrationsDTO.Add(registrationDTO);
            }
            return registrationsDTO;
        }

    }
}
