using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SchoolManagement.Web.Controllers
{
    [RoutePrefix("api/course-student")]
    [Authorize (Roles = "admin")]
    public class CourseStudentController : ApiController
    {
        private readonly ICourseStudentService courseStudentService;

        public CourseStudentController(ICourseStudentService courseStudentService)
        {
            this.courseStudentService = courseStudentService;
        }

        [HttpGet]
        [Route("student/courses/{id}")]
        public IHttpActionResult GetCoursesByStudentId(int id)
        {
            return Ok(courseStudentService.GetByStudentId(id));
        }


        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(courseStudentService.GetById(id));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Add(CreateCourseStudentModel model)
        {
            courseStudentService.Add(model);
            return Ok();    
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(CreateCourseStudentModel model)
        {
            courseStudentService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Remove(int id)
        {
            courseStudentService.Remove(id);
            return Ok();
        }
    }
}