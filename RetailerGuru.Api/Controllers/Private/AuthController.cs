using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailerGuru.Api.Controllers.Models;
using RetailerGuru.Api.Infrastructure;
using RetailerGuru.Api.Infrastructure.Versions;
using RetailerGuru.Core.Services;

namespace RetailerGuru.Api.Controllers.Private
{
    [SpaApiV1]
    public class AuthController : ApiController
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model is null)
                return BadRequest("Invalid client request");

            var logonData = await _authService.Login(model.Username, model.Password);

            if (logonData is null)
                return Unauthorized();

            return Ok(new
            {
                Token = logonData.Token,
                UserId = logonData.UserId,
                CompanyId = logonData.CompanyId,
            });
        }
    }
}
