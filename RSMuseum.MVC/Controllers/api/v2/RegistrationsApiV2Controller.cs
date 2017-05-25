using RSMuseum.Repository.Entities;
using RSMuseum.Services;
using System;
using System.Web.Http;

namespace RSMuseum.MVC.Controllers.api.v2
{
    public class RegistrationsApiController : ApiController
    {
        [HttpPost]
        [Route("api/v2/registrations")] // Så url'en er /api/AddRegistration
        public IHttpActionResult AddRegistration([FromBody] Registration registration) // Denne REST-api er for at hente samtlige frivillige
        {
            var registationService = DI.Container.GetInstance<RegistrationService>();
            var succeeded = registationService.AddRegistration(registration);
            if (succeeded) {
                return Ok(succeeded);
            }
            else {
                return InternalServerError();
            }
        }

        [Route("api/v2/registrations/{unprocessedOnly?}")]
        public IHttpActionResult GetRegistrations(bool? processed = null) {
            var registationService = DI.Container.GetInstance<RegistrationService>();
            if (processed == null) {
                var allRegistrations = registationService.GetRegistrationsDTO();
                return Ok(allRegistrations);
            }
            else {
                return Ok(registationService.GetRegistrationsDTO(processed));
            }
            return InternalServerError();
        }

        [HttpPut]
        [Route("api/v2/registrations/{registrationId}/{accepted}")]
        public IHttpActionResult UpdateRegistration(int registrationId, bool approved) {
            var registationService = DI.Container.GetInstance<RegistrationService>();
            bool result = registationService.ChangeRegistrationStatus(registrationId, approved);
            if (result) {
                return Ok();
            }
            return InternalServerError();
        }
    }
}