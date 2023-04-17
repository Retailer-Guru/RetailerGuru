using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RetailerGuru.Core.Extensions;
using RetailerGuru.Core.Queries.Users;
using RetailerGuru.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RetailerGuru.Core.Services
{
    public class AuthService
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;

        public AuthService(IMediator mediator, IConfiguration cofig)
        {
            _mediator = mediator;
            _config = cofig;
        }

        // TODO: vll param auf securestring umstellen
        // TODO: return wert vll auf anonymes objekt umstellen
        public async Task<AuthModel?> Login(string username, string password)
        {
            var logOn = await _mediator.Send(new UserLogin.Query { Username= username, Password = password });

            if(logOn is not null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JwtBaerer")["Key"].Decode64()));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken
                (
                    issuer: _config.GetSection("JwtBaerer")["Issuer"],
                    audience: _config.GetSection("JwtBaerer")["Audience"],
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signingCredentials
                );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return new AuthModel
                {
                    Token = token,
                    UserId = logOn.UserId,
                    CompanyId = logOn.CompanyId,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
