using BillCreator.Api.Infrastructure;
using BillCreator.Api.Infrastructure.Versions;
using Microsoft.AspNetCore.Mvc;

namespace RetailerGuru.Api.Controllers.Private
{
    [SpaApiV1]
    public class CompanyController : ApiController
    {
        [HttpGet("GetCompanyName")]
        public string GetCompanyName()
        {
            return "TestCompany";
        }
    }
}
