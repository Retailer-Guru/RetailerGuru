using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailerGuru.Api.Controllers.Models;
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
        [HttpPost("GetDailyProductSearchStatistic")]
        public IActionResult GetDailyProductSearchStatistic([FromBody] StatisticModel<int> model)
        {
            return Ok(_mediator.Send(new GetDailyProductSearch.Query { ProductId = model.Id, From = model.From, To = model.To }));
        }

        [HttpPost("GetDailyCompanyProductSearchStatistic")]
        public IActionResult GetDailyCompanySearchStatistic([FromBody] StatisticModel<Guid> model)
        {
            return Ok(_mediator.Send(new GetDailyCompanyProductSearch.Query { CompanyId = model.Id, From = model.From, To = model.To }));
        }

        [HttpPost("GetDailyProductVerifiedSalesStatistic")]
        public IActionResult GetDailyProductVerifiedSalesStatistic([FromBody] StatisticModel<int> model)
        {
            return Ok(_mediator.Send(new GetDailyProductVerifiedSales.Query { ProductId = model.Id, From = model.From, To = model.To }));
        }

        [HttpPost("GetDailyCompanyVerifiedSalesStatistic")]
        public IActionResult GetDailyCompanyVerifiedSalesStatistic([FromBody] StatisticModel<Guid> model)
        {
            return Ok(_mediator.Send(new GetDailyCompanyVerifiedSales.Query { CompanyId = model.Id, From = model.From, To = model.To }));
        }

    }
}
