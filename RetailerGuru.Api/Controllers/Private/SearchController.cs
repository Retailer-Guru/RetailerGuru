using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailerGuru.Api.Infrastructure;
using RetailerGuru.Api.Infrastructure.Versions;
using RetailerGuru.Core.Queries.Searches;

namespace RetailerGuru.Api.Controllers.Private
{
    [SpaApiV1]
    public class SearchController : ApiController
    {
        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProductSearch/{searchText}")]
        public IActionResult GetPrdouctSearch(string searchText)
        {
            return Ok(_mediator.Send(new ProductSearchByText.Query { SearchText = searchText }));
        }
    }
}
