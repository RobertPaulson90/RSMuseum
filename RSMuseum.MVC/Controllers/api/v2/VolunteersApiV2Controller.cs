using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RSMuseum.Services;

namespace RSMuseum.MVC.Controllers.api.v2
{
    public class VolunteersApiV2Controller : ApiController
    {
        [HttpGet]
        [Route("api/v2/volunteers/{id}")]
        public IHttpActionResult GetVolunteersById(int id) {
            try {
                var volunteerService = DI.Container.GetInstance<VolunteerService>();
                var volunteer = volunteerService.GetVolunteerByID(id);
                return Ok(volunteer);
            }
            catch (Exception e) {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("api/v2/volunteers")] // Så url'en er /api/GetVolunteers
        public IHttpActionResult GetVolunteers() // Denne REST-api er for at hente samtlige frivillige
        {
            try {
                var volunteerService = DI.Container.GetInstance<VolunteerService>();
                /*  Beder vores DI container om instans af VolunteerService
                 Vi injecter ikke VolunteerService i parametrene (endnu), fordi det kræver integrering af di-container i MVC. Store problemer */
                var volunteers = volunteerService.GetVolunteersViewDTO(); // Forretningslogikken sættes igang! For det må vi jo ikke i controlleren :-)
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