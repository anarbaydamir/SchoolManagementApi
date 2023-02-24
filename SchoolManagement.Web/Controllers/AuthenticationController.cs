using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.ProjectAggregates.Exceptions;
using SchoolManagement.Web.ApiModels;
using Serilog;
using System.Web.Http;

namespace SchoolManagement.Web.Controllers
{
    [RoutePrefix("api/authentication")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult Authenticate([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var token = authenticationService.AuthenticateUser(loginRequest.Email, loginRequest.Password);
                return Ok(token);
            }
            catch (UserNotFoundException ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("refresh-token")]
        public IHttpActionResult RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            var accessToken = authenticationService.RefreshToken(refreshTokenRequest.RefreshToken);
            return Ok(accessToken);
        }
    }
}