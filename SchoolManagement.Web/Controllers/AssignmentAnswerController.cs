using Org.BouncyCastle.Asn1.Ocsp;
using SchoolManagement.Application.Services;
using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Domain.ProjectAggregates.Exceptions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;

namespace SchoolManagement.Web.Controllers
{
    [RoutePrefix("api/assignment-answer")]
    public class AssignmentAnswerController: ApiController
    {
        private readonly IAssignmentAnswerService assignmentAnswerService;

        public AssignmentAnswerController(IAssignmentAnswerService assignmentAnswerService)
        {
            this.assignmentAnswerService = assignmentAnswerService;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {
            return Ok(assignmentAnswerService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(assignmentAnswerService.GetById(id));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Add(CreateAssignmentAnswerModel model)
        {
            assignmentAnswerService.Add(model);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(CreateAssignmentAnswerModel model)
        {
            assignmentAnswerService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Remove(int id)
        {
            assignmentAnswerService.Remove(id);
            return Ok();
        }
    }
}