using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using System.Web.Http;

namespace SchoolManagement.Web.Controllers
{
    [RoutePrefix("api/assignment")]
    public class AssignmentController : ApiController
    {
        private readonly IAssignmentService assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            this.assignmentService = assignmentService;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {
            return Ok(assignmentService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(assignmentService.GetById(id));
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult Add(CreateAssignmentModel model)
        {
            assignmentService.Add(model);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(CreateAssignmentModel model)
        {
            assignmentService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Remove(int id)
        {
            assignmentService.Remove(id);
            return Ok();
        }
    }
}