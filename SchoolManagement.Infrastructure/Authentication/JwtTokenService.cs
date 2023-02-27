using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Authentication.Interfaces;
using SchoolManagement.Infrastructure.Configurations.Interfaces;
using SchoolManagement.Infrastructure.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace SchoolManagement.Infrastructure.Authentication
{
    public class JwtTokenService : ITokenService
    {
        private readonly IJwtOptions jwtOptions;

        public JwtTokenService(IJwtOptions jwtOptions)
        {
            this.jwtOptions = jwtOptions;
        }

        public string GenerateToken(UserClaimsModel userModel)
        {
            var key = Encoding.UTF8.GetBytes(jwtOptions.SecretKey);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("email", userModel.Email));
            permClaims.Add(new Claim("name", userModel.FirstName));
            permClaims.Add(new Claim("surname", userModel.LastName));
            permClaims.Add(new Claim("phoneNumber", userModel.PhoneNumber));
            permClaims.Add(new Claim("role", userModel.Role.Name));

            var token = new JwtSecurityToken(jwtOptions.Issuer, //Issure    
                           jwtOptions.Auidence,  //Audience    
                           permClaims,
                           expires: DateTime.UtcNow.AddMinutes(jwtOptions.JwtTokenValidityInMinutes),
                           signingCredentials: credentials);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }

        public RefreshToken GenerateRefreshToken()
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                var refreshToken = new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    ExpiryTime = DateTime.UtcNow.AddDays(jwtOptions.JwtRefreshTokenValidityInDays),
                };
                return refreshToken;
            }
        }
    }
}
