using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RSMuseum.Services;

namespace RSMuseum.MVC.Controllers.api.v2
{
    public class GuildApiV2Controller : ApiController
    {
        [HttpGet]
        [Route("api/v2/Guilds")]
        public IHttpActionResult GetGuilds() {
            var guildService = DI.Container.GetInstance<GuildService>();
            var allGuilds = guildService.GetAllGuilds();
            return Ok(allGuilds);
        }
    }
}