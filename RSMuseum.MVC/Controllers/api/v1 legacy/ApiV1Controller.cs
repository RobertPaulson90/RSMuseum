using RSMuseum.Repository.Entities;
using RSMuseum.Services;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSMuseum.MVC.Controllers.api
{
    /* !!! WARNING !!!
     * !!! WARNING !!!
     * THIS CLASS IS DEPRECATED.
     * USE LATEST V2 API Controllers instead */

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiV1Controller : ApiController
    {
        private readonly RegistrationService _registrationService;
        private readonly GuildService _guildService;
        private readonly StatisticsService _statisticsService;
        private readonly VolunteerService _volunteerService;

        public ApiV1Controller(RegistrationService registrationService, GuildService guildService, StatisticsService statisticsService, VolunteerService volunteerService) {
            _registrationService = registrationService;
            _guildService = guildService;
            _statisticsService = statisticsService;
            _volunteerService = volunteerService;
        }

        [HttpGet]
        [Route("api/GetVolunteers")]
        public async Task<IHttpActionResult> GetVolunteers() {
            try {
                var volunteers = await _volunteerService.GetVolunteersDtoAsync();
                return Ok(volunteers);
            }
            catch (Exception e) {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("api/AddRegistration")] // Så url'en er /api/AddRegistration
        public async Task<IHttpActionResult> AddRegistrations([FromBody] Registration registration) // Denne REST-api er for at hente samtlige frivillige
        {
            try {
                await _registrationService.Add(registration);
                return Ok();
            }
            catch (Exception e) {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("api/GetGuilds")]
        public async Task<IHttpActionResult> GetGuilds() {
            var allGuilds = await _guildService.GetGuildsDtoAsync();
            return Ok(allGuilds);
        }

        [Route("api/GetVolunteerById/{Id}")]
        public async Task<IHttpActionResult> GetVolunteerById(int Id) {
            var volunteer = await _volunteerService.GetVolunteerByIdAsync(Id);
            return Ok(volunteer);
        }

        [Route("api/GetRegistrations/{unprocessed?}")]
        public async Task<IHttpActionResult> GetRegistrations(bool? unprocessed = null) {
            if (unprocessed == true) {
                var allRegistrations = await _registrationService.GetRegistrationsDtoAsync(processed: false);
                return Ok(allRegistrations);
            }
            return InternalServerError();
        }

        [HttpGet]
        [Route("api/HandleRegistrations/{registrationId}/{process}")]
        public async Task<IHttpActionResult> HandleRegistrations(int registrationId, bool process) {
            try {
                await _registrationService.SetStatusAsync(registrationId, process);
                return Ok();
            }
            catch (Exception e) {
                return InternalServerError(e);
            }
        }
    }
}