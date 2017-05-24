using System;
using System.Web.Http;
using RSMuseum.Services;

namespace RSMuseum.MVC.Controllers.api.v2
{
    public class StatisticsApiV2Controller : ApiController
    {
        [HttpGet]
        [Route("api/v2/Statistics/{dateFrom}/{dateTo?}")]
        public IHttpActionResult GetStatistics(DateTime dateFrom, DateTime? dateTo = null) {
            try {
                var statisticsService = DI.Container.GetInstance<StatisticsService>();
                dateTo = dateTo ?? DateTime.Now;
                return Ok(statisticsService.GetGuildStatisticsDTOs(dateFrom, (DateTime)dateTo));
            }
            catch (Exception e) {
                return InternalServerError(e);
            }
        }
    }
}