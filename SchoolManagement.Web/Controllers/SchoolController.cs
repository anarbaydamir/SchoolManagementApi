using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Domain.ProjectAggregates.Exceptions;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        [Route("logo/{logoName}")]
        public HttpResponseMessage GetLogo(string logoName)
        {
            try
            {
                var logoBytes = schoolService.GetLogo(logoName);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(logoBytes);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                return response;
            }
            catch (LogoNotFoundException ex)
            {
                Log.Error(ex.ToString());
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPost]
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