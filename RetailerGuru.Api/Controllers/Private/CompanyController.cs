using RetailerGuru.Api.Infrastructure;
using RetailerGuru.Api.Infrastructure.Versions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using RetailerGuru.Core.Queries.Companyies;

namespace RetailerGuru.Api.Controllers.Private
{
    [SpaApiV1]
    public class CompanyController : ApiController
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCompanyName")]
        public string GetCompanyName()
        {
            return "TestCompany";
        }

        // TODO: durch echte funktion ersetzen
        [HttpGet("GetFirstCompanyId")] 
        public async Task<Guid> GetFirstCompanyId()
        {
            return await _mediator.Send(new GetFirstCompanyId.Query());
        }
    }
}
