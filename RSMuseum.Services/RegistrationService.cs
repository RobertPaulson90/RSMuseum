using RSMuseum.Repository;
using RSMuseum.Repository.Entities;
using RSMuseum.Services.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;

namespace RSMuseum.Services
{
    public class RegistrationService
    {
        private static IDbRepository _dbRepo;
        private IMapper _mapper;

        public RegistrationService(IDbRepository dbRepo, IMapper mapper) //Vi smider vores db repo som contructor så vores DI container kan instanciere den
        {
            _dbRepo = dbRepo;
            _mapper = mapper;
        }

        public bool AddRegistration(Registration registration)
        {
            try
            {
                registration.DateTimeRegistered = DateTime.Now;

                registration.VolunteerId = _dbRepo.GetMembershippnrFromVoluneerID(registration.VolunteerId);

                _dbRepo.AddTimeRegistration(registration);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<RegistrationDTO> GetRegistrations(bool unprocessedOnly, DateTime dateFrom, DateTime? dateTo)
        {
            var registrations = new List<RegistrationDTO>();
            //if (dateTo)


                return registrations;
        }

        public IList<IRegistrationDTO> GetAllRegistrationsUnprocessed()
        {
            var allRegistrationsUnprocessed = _dbRepo.GetAllRegistrationsUnprocessed(); //Går ned i vores DAL for at hente vores frivillige

            // Broken for now... Until fixed, we do manual mapping.
            // var registrationsDTO = _mapper.Map<IList<Registration>, IList<IRegistrationDTO>>(allRegistrationsUnprocessed);

            var registrationsDTO = new List<IRegistrationDTO>(); //Instancisere en liste med de volunteer properties som vores View har brug for.

            foreach (var item in allRegistrationsUnprocessed) //Smider data i vores VolunteerListe.
            {
                var volunteer = item.Volunteer;
                var registrationDTO = new RegistrationDTO()
                {
                    Approved = item.Approved,
                    Date = item.Date,
                    DateTimeRegistered = item.DateTimeRegistered,
                    Guild = new GuildDTO
                    {
                        GuildName = item.Guild.GuildName,
                        GuildId = item.Guild.GuildId,
                    },
                    Hours = item.Hours,
                    Processed = item.Processed,
                    RegistrationId = item.RegistrationId,
                    Volunteer = new VolunteerViewDTO
                    {
                        FirstName = item.Volunteer.Person.FirstName,
                        LastName = item.Volunteer.Person.LastName,
                        MembershipNumber = item.Volunteer.MembershipNumber
                    }
                };
                registrationsDTO.Add(registrationDTO);
            }
            return registrationsDTO;
        }

        public bool ChangeRegistrationStatus(int registrationId, bool status)
        {
            try
            {
                _dbRepo.ChangeRegistrationStatus(registrationId, status);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}