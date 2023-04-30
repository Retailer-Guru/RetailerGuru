using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RetailerGuru.Api.Infrastructure
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiController : ControllerBase
    {

    }

    [Authorize]
    public abstract class AuthorizedApiController : ApiController
    {

    }
}
