using System.Web.Http;
using RSMuseum.Services;
using RSMuseum.Repository.Entities;
using System.Web.Http.Cors;


namespace RSMuseum.MVC.Controllers.api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiController : System.Web.Http.ApiController
    {
        [Route("api/GetVolunteers")] // Så url'en er /api/GetVolunteers
        public IHttpActionResult GetVolunteers() // Denne REST-api er for at hente samtlige frivillige
        {
            var volunteerService = DI.Container.GetInstance<VolunteerService>(); // Beder vores DI container om instans af VolunteerService

            // Vi injecter ikke VolunteerService i parametrene (endnu), fordi det kræver integrering af SimpleInjector i MVC (umiddelbart lidt tricky...)

            var volunteers = volunteerService.GetVolunteersViewDTO(); // Forretningslogikken sættes igang! For det må vi jo ikke i controlleren :-)

            //if (volunteers != null)
            //{
            return Ok(volunteers); // Retunere alle frivillige ud til browseren i JSON med HTTP-OK besked
            //}
            //else
            //{
            //    return InternalServerError(); // Something went wrong... God skik at give browseren besked med HTTP-InternalServerError
            //}
        }

        [Route("api/AddRegistration")] // Så url'en er /api/AddRegistration
        public IHttpActionResult AddRegistrations([FromBody] Registration registration) // Denne REST-api er for at hente samtlige frivillige
        {
            var registationService = DI.Container.GetInstance<RegistrationService>();
            var succeeded = registationService.AddRegistration(registration);
            if (succeeded)
            {
                return Ok(succeeded);
            }
            else
            {
                return InternalServerError();
            }
        }

        [Route("api/GetGuilds")] 
        public IHttpActionResult GetGuilds()
        {
            var guildService = DI.Container.GetInstance<GuildService>();
            var allGuilds = guildService.GetAllGuilds();
            return Ok(allGuilds);
        }
        [Route("api/GetVolunteerById/{Id}")]
        public IHttpActionResult GetVolunteerById(int Id)
        {
            var volunteerService = DI.Container.GetInstance<VolunteerService>();
            var volunteer = volunteerService.GetVolunteerByID(Id);
            return Ok(volunteer);
        }

        [Route("api/GetRegistrations/{unprocessedOnly}")]
        public IHttpActionResult GetRegistrations(bool unprocessedOnly = false)
        {
            var registationService = DI.Container.GetInstance<RegistrationService>();
            if (unprocessedOnly) { 
            var allRegistrations = registationService.GetAllRegistrationsUnprocessed();
            return Ok(allRegistrations);
            }
            return InternalServerError();
        }

        [HttpGet]
        [Route("api/HandleRegistrations/{registrationId}/{process}")]
        public IHttpActionResult HandleRegistrations(int registrationId,bool process)
        {
            var registationService = DI.Container.GetInstance<RegistrationService>();
            bool changeRegistrationCheck = registationService.ChangeRegistrationStatus(registrationId, process);
            if (changeRegistrationCheck)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
                
                
        }
    }
}