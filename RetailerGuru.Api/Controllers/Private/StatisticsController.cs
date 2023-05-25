using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailerGuru.Api.Infrastructure;
using RetailerGuru.Api.Infrastructure.Versions;
using RetailerGuru.Core.Queries.Statistics;

namespace RetailerGuru.Api.Controllers.Private
{
    [SpaApiV1]
    public class StatisticsController : AuthorizedApiController
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        // TODO: Vll ActionResult austauschen
        [HttpGet("GetDailyProductSearchStatistic/{productId}")]
        public async Task<IActionResult> GetDailyProductSearchStatistic(int productId, DateTime from, DateTime to)
        {
            return Ok(await _mediator.Send(new GetDailyProductSearch.Query { Id = productId, From = from, To = to }));
        }
    }
}
