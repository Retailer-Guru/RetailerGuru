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
        [HttpGet("GetDailyProductSearchStatistic/{productId}/{from}/{to}")]
        public IActionResult GetDailyProductSearchStatistic(int productId, DateTime from, DateTime to)
        {
            return Ok(_mediator.Send(new GetDailyProductSearch.Query { Id = productId, From = from, To = to }));
        }

        [HttpGet("GetDailyCompanyProductSearchStatistic/{companyId}/{from}/{to}")]
        public IActionResult GetDailyCompanySearchStatistic(Guid companyId, DateTime from, DateTime to)
        {
            return Ok(_mediator.Send(new GetDailyCompanyProductSearch.Query { CompanyId = companyId, From = from, To = to }));
        }

        [HttpGet("GetDailyProductVerifiedSalesStatistic/{productId}/{from}/{to}")]
        public IActionResult GetDailyProductVerifiedSalesStatistic(int productId, DateTime from, DateTime to)
        {
            return Ok(_mediator.Send(new GetDailyProductVerifiedSales.Query { ProductId = productId, From = from, To = to }));
        }

        [HttpGet("GetDailyCompanyVerifiedSalesStatistic/{companyId}/{from}/{to}")]
        public IActionResult GetDailyCompanyVerifiedSalesStatistic(Guid companyId, DateTime from, DateTime to)
        {
            return Ok(_mediator.Send(new GetDailyCompanyVerifiedSales.Query { CompanyId = companyId, From = from, To = to }));
        }

    }
}
