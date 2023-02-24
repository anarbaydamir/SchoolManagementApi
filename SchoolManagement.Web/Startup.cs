using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Configuration;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(SchoolManagement.Web.Startup))]

namespace SchoolManagement.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey= true,
                        ValidIssuer = ConfigurationManager.AppSettings["JwtIssuer"],
                        ValidAudience= ConfigurationManager.AppSettings["JwtAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                        (ConfigurationManager.AppSettings["JwtSecretKey"]))
                    },
                    Provider = new OAuthBearerAuthenticationProvider
                    {
                        OnValidateIdentity = context =>
                        {
                            var ticket = context.Ticket;
                            var identity = ticket.Identity;
                            var roleClaim = identity.FindFirst(ClaimTypes.Role);
                            if (roleClaim == null)
                            {
                                // No role claim found, reject the token.
                                context.Rejected();
                                return Task.FromResult<object>(null);
                            }

                            var roles = roleClaim.Value.Split(';');
                            foreach (var role in roles)
                            {
                                identity.AddClaim(new Claim(ClaimTypes.Role, role));
                            }

                            return Task.FromResult<object>(null);
                        }
                    } 
                });
        }
    }
}
