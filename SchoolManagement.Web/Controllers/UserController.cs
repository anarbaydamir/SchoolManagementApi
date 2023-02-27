using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Domain.ProjectAggregates.Exceptions;
using SchoolManagement.Web.ApiModels;
using Serilog;
using System.Net;
using System.Web.Http;

namespace SchoolManagement.Web.Controllers
{
    [RoutePrefix("api/user")]
    [Authorize(Roles = "admin")]
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetUsers()
        {
            return Ok(userService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetUser(int id)
        {
            return Ok(userService.GetById(id));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddUser(CreateUserModel model)
        {
            try
            {
                userService.Add(model);
            }
            catch (UserEmailExistsException ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateUser(UserModel model)
        {
            userService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteUser(int id)
        {
            userService.Remove(id);
            return Ok();
        }
    }
}