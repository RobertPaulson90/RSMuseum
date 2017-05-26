using RSMuseum.Repository;
using RSMuseum.Repository.Entities;
using RSMuseum.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

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

        public async Task Add(Registration registration) {
            registration.DateTimeRegistered = DateTime.Now;
            registration.VolunteerId = await _dbRepo.GetMembershipNumberFromVolunteerIdAsync(registration.VolunteerId);
            await _dbRepo.AddTimeRegistration(registration);
        }

        public async Task<IList<IRegistrationDto>> GetRegistrationsDtoAsync(bool? processed = null) {
            IList<Registration> allRegistrationsUnprocessed;
            if (processed == null) {
                allRegistrationsUnprocessed = await _dbRepo.GetRegistrationsAsync(); //Går ned i vores DAL for at hente vores frivillige
            }
            else {
                allRegistrationsUnprocessed = await _dbRepo.GetRegistrationsAsync(processed); //Går ned i vores DAL for at hente vores frivillige
            }

            // Broken for now... Until fixed, we do manual mapping.
            // var registrationsDTO = _mapper.Map<IList<Registration>, IList<IRegistrationDTO>>(allRegistrationsUnprocessed);

            var registrationsDto = new List<IRegistrationDto>(); //Instancisere en liste med de volunteer properties som vores View har brug for.

            foreach (var item in allRegistrationsUnprocessed) //Smider data i vores VolunteerListe.
            {
                var volunteer = item.Volunteer;
                var registrationDto = new RegistrationDto()
                {
                    Approved = item.Approved,
                    Date = item.Date,
                    DateTimeRegistered = item.DateTimeRegistered,
                    Guild = new GuildDto
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
                registrationsDto.Add(registrationDto);
            }
            return registrationsDto;
        }

        public async Task SetStatusAsync(int registrationId, bool status) {
            await _dbRepo.RegistrationSetStatus(registrationId, status);
        }
    }
}