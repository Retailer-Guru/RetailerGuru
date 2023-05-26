using RetailerGuru.Api.Infrastructure;
using RetailerGuru.Api.Infrastructure.Versions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using RetailerGuru.Core.Queries.Companyies;

namespace RetailerGuru.Api.Controllers.Private
{
    [SpaApiV1]
    public class CompanyController : AuthorizedApiController
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCompanyName")]
        public string GetCompanyName()
        {
            throw new NotImplementedException();
        }

        
    }
}
