using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SchoolManagement.Web.Controllers
{
    [RoutePrefix("api/school")]
    [Authorize(Roles = "admin")]
    public class SchoolController: ApiController
    {
        private readonly ISchoolService schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            this.schoolService = schoolService;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {
            return Ok(schoolService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(schoolService.GetById(id));
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Add(CreateSchoolModel model)
        {
            schoolService.Add(model);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(CreateSchoolModel model)
        {
            schoolService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Remove(int id)
        {
            schoolService.Remove(id);
            return Ok();
        }
    }
}