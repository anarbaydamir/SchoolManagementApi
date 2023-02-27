using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace SchoolManagement.Web.Controllers
{
    [RoutePrefix("api/role")]
    [Authorize(Roles = "admin")]
    public class RoleController : ApiController
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetRoles()
        {
            return Ok(roleService.GetAll());
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddRole(CreateRoleModel model)
        {
            roleService.Add(model);
            return Ok();
        }
    }
}