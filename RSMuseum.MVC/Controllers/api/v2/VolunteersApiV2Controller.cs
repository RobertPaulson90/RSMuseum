using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using RSMuseum.Services;

namespace RSMuseum.MVC.Controllers.api.v2
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VolunteersApiV2Controller : ApiController
    {
        private readonly VolunteerService _volunteerService;

        public VolunteersApiV2Controller(VolunteerService volunteerService) {
            _volunteerService = volunteerService;
        }

        [HttpGet]
        [Route("api/v2/volunteers/{id}")]
        public async Task<IHttpActionResult> GetVolunteer(int id) {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("api/v2/volunteers")] // Så url'en er /api/GetVolunteers
        public async Task<IHttpActionResult> ListVolunteers() // Denne REST-api er for at hente samtlige frivillige
        {
            try {
                /*  Beder vores DI container om instans af VolunteerService
                 Vi injecter ikke VolunteerService i parametrene (endnu), fordi det kræver integrering af di-container i MVC. Store problemer */
                var volunteers = await _volunteerService.GetVolunteersDtoAsync(); // Forretningslogikken sættes igang! For det må vi jo ikke i controlleren :-)
                return Ok(volunteers); // Retunere alle frivillige ud til browseren i JSON med HTTP-OK besked
            }
            catch (Exception e) {
                InternalServerError(e);
                // Something went wrong... God skik at give browseren besked med HTTP-InternalServerError
            }
            return InternalServerError();
        }
    }
}