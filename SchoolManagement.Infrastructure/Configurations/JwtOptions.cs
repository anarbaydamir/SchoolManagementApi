using SchoolManagement.Infrastructure.Configurations.Interfaces;
using System;
using System.Configuration;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class JwtOptions : IJwtOptions
    {
        public string Issuer => ConfigurationManager.AppSettings["JwtIssuer"];

        public string Auidence => ConfigurationManager.AppSettings["JwtAudience"];

        public string SecretKey => ConfigurationManager.AppSettings["JwtSecretKey"];

        public int JwtTokenValidityInMinutes => Convert.ToInt32(ConfigurationManager.AppSettings["JwtTokenValidityInMinutes"]);

        public int JwtRefreshTokenValidityInDays => Convert.ToInt32(ConfigurationManager.AppSettings["JwtRefreshTokenValidityInDays"]);
    }
}
