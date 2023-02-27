using SchoolManagement.Application.Services;
using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Domain.ProjectAggregates.Exceptions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SchoolManagement.Web.Controllers
{
    [RoutePrefix("api/course")]
    public class CourseController: ApiController
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetCourses()
        {
            return Ok(courseService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCourse(int id)
        {
            return Ok(courseService.GetById(id));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddCourse(CreateCourseModel model)
        {
            courseService.Add(model);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateCourse(CourseModel model)
        {
            courseService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCourse(int id)
        {
            courseService.Remove(id);
            return Ok();
        }
    }
}