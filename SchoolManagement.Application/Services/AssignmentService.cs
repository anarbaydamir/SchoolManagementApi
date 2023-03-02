using SchoolManagement.Application.Mappers;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Domain.Specifications;
using SchoolManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly AssignmentMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public AssignmentService(AssignmentMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public void Add(CreateAssignmentModel model)
        {
            var assignment = mapper.CreateAssignmentMapToEntity(model);
            unitOfWork.Repository<Assignment>().Add(assignment);
            unitOfWork.Complete();
        }

        public IEnumerable<AssignmentsModel> GetAll()
        {
            var assignments = unitOfWork.Repository<Assignment>().Find(new AssignmentWithCourseTeacherSpecification()); 
            return mapper.EntityListToAssignmentModelList(assignments);
        }

        public AssignmentModel GetById(int id)
        {
            var assignment = unitOfWork.Repository<Assignment>().FindById(id);
            return mapper.EntityToAssignmentModel(assignment);
        }

        public void Remove(int id)
        {
            var assignment = unitOfWork.Repository<Assignment>().FindById(id);
            unitOfWork.Repository<Assignment>().Remove(assignment);
            unitOfWork.Complete();
        }

        public void Update(CreateAssignmentModel model)
        {
            var assignment = mapper.CreateAssignmentMapToEntity(model);
            unitOfWork.Repository<Assignment>().Update(assignment);
            unitOfWork.Complete();
        }
    }
}
