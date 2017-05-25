using RSMuseum.Repository.Entities;
using RSMuseum.Services;
using System.Web.Http;

namespace RSMuseum.MVC.Controllers.api.v2
{
    public class RegistrationsApiController : ApiController
    {
        private readonly RegistrationService _registrationService;

        public RegistrationsApiController(RegistrationService registrationService) {
            _registrationService = registrationService;
        }

        [HttpPost]
        [Route("api/v2/registrations")] // Så url'en er /api/AddRegistration
        public IHttpActionResult AddRegistration([FromBody] Registration registration) // Denne REST-api er for at hente samtlige frivillige
        {
            var succeeded = _registrationService.AddRegistration(registration);
            if (succeeded) {
                return Ok(succeeded);
            }
            else {
                return InternalServerError();
            }
        }

        [Route("api/v2/registrations/{unprocessedOnly?}")]
        public IHttpActionResult GetRegistrations(bool? processed = null) {
            if (processed == null) {
                var allRegistrations = _registrationService.GetRegistrationsDTO();
                return Ok(allRegistrations);
            }
            else {
                return Ok(_registrationService.GetRegistrationsDTO(processed));
            }
            return InternalServerError();
        }

        [HttpPut]
        [Route("api/v2/registrations/{registrationId}/{accepted}")]
        public IHttpActionResult UpdateRegistration(int registrationId, bool approved) {
            bool result = _registrationService.ChangeRegistrationStatus(registrationId, approved);
            if (result) {
                return Ok();
            }
            return InternalServerError();
        }
    }
}