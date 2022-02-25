using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MF.TokenAuthenticationWithJwtWithoutIdentity01.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MF.TokenAuthenticationWithJwtWithoutIdentity01.Api.Services
{
    public static class TokenService
    {
        public static string GerarToken(LoginDTO dtoLogin, IConfiguration configuration)
        {
            var claimsIdentity =
                new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, dtoLogin.Usuario)
                }, JwtBearerDefaults.AuthenticationScheme);

            var jwtBearerSecretKey =
                configuration["JwtBearerSecretKey"];

            var jwtBearerSecretKeyBytes =
                Encoding.ASCII.GetBytes(jwtBearerSecretKey);

            var securityTokenDescriptor =
                new SecurityTokenDescriptor()
                {
                    Issuer = configuration["ValidIssuer"],
                    Audience = configuration["ValidAudience"],
                    Subject = claimsIdentity,
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials =
                        new SigningCredentials(new SymmetricSecurityKey(jwtBearerSecretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

            var jwtSecurityTokenHandler =
                new JwtSecurityTokenHandler();

            var securityToken =
                jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            var token =
                jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
