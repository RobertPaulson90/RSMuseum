using System;
using System.Threading.Tasks;
using RSMuseum.Repository.Entities;
using RSMuseum.Services;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSMuseum.MVC.Controllers.api.v2
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegistrationsApiController : ApiController
    {
        private readonly RegistrationService _registrationService;

        public RegistrationsApiController(RegistrationService registrationService) {
            _registrationService = registrationService;
        }

        [HttpPost]
        [Route("api/v2/registrations")] // Så url'en er /api/AddRegistration
        public async Task<IHttpActionResult> CreateRegistration([FromBody] Registration registration) // Denne REST-api er for at hente samtlige frivillige
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
        [Route("api/v2/registrations/{unprocessedOnly?}")]
        public async Task<IHttpActionResult> ListRegistrations(bool? unprocessedOnly = null) {
            if (unprocessedOnly == null) {
                var allRegistrations = await _registrationService.GetRegistrationsDtoAsync();
                return Ok(allRegistrations);
            }
            else {
                return Ok(_registrationService.GetRegistrationsDtoAsync(!unprocessedOnly));
            }
        }

        [HttpPut]
        [Route("api/v2/registrations/{registrationId}/{approved}")]
        public async Task<IHttpActionResult> UpdateRegistration(int registrationId, bool approved) {
            try {
                await _registrationService.SetStatusAsync(registrationId, approved);
                return Ok();
            }
            catch (Exception e) {
                return InternalServerError(e);
            }
        }
    }
}