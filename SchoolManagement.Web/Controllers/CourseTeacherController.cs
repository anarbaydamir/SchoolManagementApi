using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SchoolManagement.Web.Controllers
{
    [RoutePrefix("api/course-teacher")]
    [Authorize(Roles = "admin")]
    public class CourseTeacherController : ApiController
    {
        private readonly ICourseTeacherService courseTeacherService;

        public CourseTeacherController(ICourseTeacherService courseTeacherService)
        {
            this.courseTeacherService = courseTeacherService;
        }

        [Route("all")]
        public IHttpActionResult GetAll()
        {
            return Ok(courseTeacherService.GetAll());
        }

        [Route("all/teacher/{id}")]
        public IHttpActionResult GetAllByTeacherId(int id)
        {
            return Ok(courseTeacherService.GetByTeacherId(id));
        }

        [Route("all/course/{id}")]
        public IHttpActionResult GetAllByCourseId(int id)
        {
            return Ok(courseTeacherService.GetByCourseId(id));
        }

        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(courseTeacherService.GetById(id));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Add(CreateCourseTeacherModel model)
        {
            courseTeacherService.Add(model);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(CreateCourseTeacherModel model)
        {
            courseTeacherService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Remove(int id)
        {
            courseTeacherService.Remove(id);
            return Ok();
        }
    }
}