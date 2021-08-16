using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WorkoutApi.DTOs;


namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController
    {
        private IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] AccountDto accountDto)
        {
            var Claims = new List<Claim>
            {
                new Claim("type", "Admin")
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Secret"]));
            var Token = new JwtSecurityToken(
               "http://localhost:5001",
               "http://localhost:5001",
               Claims,
               expires: DateTime.Now.AddDays(30.0),
               signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256)
            );

            return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(Token));
        }

    }
}