using RSMuseum.Repository.Entities;
using RSMuseum.Services;
using System;
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
        [Route("api/GetVolunteers")] // Så url'en er /api/GetVolunteers
        public IHttpActionResult GetVolunteers() // Denne REST-api er for at hente samtlige frivillige
        {
            var volunteers = _volunteerService.GetVolunteersDTO(); // Forretningslogikken sættes igang! For det må vi jo ikke i controlleren :-)
            //if (volunteers != null)
            //{
            return Ok(volunteers); // Retunere alle frivillige ud til browseren i JSON med HTTP-OK besked
            //}
            //else
            //{
            //    return InternalServerError(); // Something went wrong... God skik at give browseren besked med HTTP-InternalServerError
            //}
        }

        [HttpPost]
        [Route("api/AddRegistration")] // Så url'en er /api/AddRegistration
        public IHttpActionResult AddRegistrations([FromBody] Registration registration) // Denne REST-api er for at hente samtlige frivillige
        {
            var succeeded = _registrationService.AddRegistration(registration);
            if (succeeded) {
                return Ok(succeeded);
            }
            else {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/GetGuilds")]
        public IHttpActionResult GetGuilds() {
            var allGuilds = _guildService.GetGuildsDTO();
            return Ok(allGuilds);
        }

        [Route("api/GetVolunteerById/{Id}")]
        public IHttpActionResult GetVolunteerById(int Id) {
            var volunteer = _volunteerService.GetVolunteerByID(Id);
            return Ok(volunteer);
        }

        [Route("api/GetRegistrations/{unprocessed?}")]
        public IHttpActionResult GetRegistrations(bool? unprocessed = null) {
            if (unprocessed == true) {
                var allRegistrations = _registrationService.GetRegistrationsDTO(processed: false);
                return Ok(allRegistrations);
            }
            return InternalServerError();
        }

        [HttpGet]
        [Route("api/Statistics/{dateFrom?}/{dateTo?}")]
        public IHttpActionResult GetStatistics(DateTime? dateFrom = null, DateTime? dateTo = null) {
            if (dateFrom == null) {
                return BadRequest();
            }
            var newDateTo = dateTo ?? DateTime.Now;
            var newDateFrom = dateFrom ?? DateTime.Now;
            return Ok(_statisticsService.GetGuildStatisticsDTOs(newDateFrom, newDateTo));
        }

        [HttpGet]
        [Route("api/HandleRegistrations/{registrationId}/{process}")]
        public IHttpActionResult HandleRegistrations(int registrationId, bool process) {
            bool changeRegistrationCheck = _registrationService.ChangeRegistrationStatus(registrationId, process);
            if (changeRegistrationCheck) {
                return Ok();
            }
            else {
                return InternalServerError();
            }
        }
    }
}