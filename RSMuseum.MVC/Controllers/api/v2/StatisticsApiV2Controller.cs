using System;
using System.Threading.Tasks;
using System.Web.Http;
using RSMuseum.Services;

namespace RSMuseum.MVC.Controllers.api.v2
{
    public class StatisticsApiV2Controller : ApiController
    {
        private readonly StatisticsService _statisticsService;

        public StatisticsApiV2Controller(StatisticsService statisticsService) {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        [Route("api/v2/statistics/{dateFrom}/{dateTo?}")]
        public async Task<IHttpActionResult> GetStatistics(DateTime dateFrom, DateTime? dateTo = null) {
            try {
                dateTo = dateTo ?? DateTime.Now;
                return Ok(await _statisticsService.GetGuildsStatisticsDtosAsync(dateFrom, (DateTime)dateTo));
            }
            catch (Exception e) {
                return InternalServerError(e);
            }
        }
    }
}