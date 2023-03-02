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
    public class AssignmentAnswerService: IAssignmentAnswerService
    {
        private readonly AssignmentAnswerMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public AssignmentAnswerService(AssignmentAnswerMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<AssignmentAnswersModel> GetAll()
        {
            var assignmentAnswers = unitOfWork.Repository<AssignmentAnswer>().Find(new AssignmentAnswerWithAssignmentAndStudentSpecification());
            return mapper.EntityListToAssignmentAnswerModelList(assignmentAnswers);
        }

        public AssignmentAnswerModel GetById(int id)
        {
            var assignmentAnswer = unitOfWork.Repository<AssignmentAnswer>().FindById(id);
            return mapper.EntityToAssignmentAnswerModel(assignmentAnswer);
        }

        public void Remove(int id)
        {
            var assignmentAnswer = unitOfWork.Repository<AssignmentAnswer>().FindById(id);
            unitOfWork.Repository<AssignmentAnswer>().Remove(assignmentAnswer);
            unitOfWork.Complete();
        }

        public void Update(CreateAssignmentAnswerModel model)
        {
            var assignmentAnswer = mapper.CreateAssignmentAnswerMapToEntity(model);
            unitOfWork.Repository<AssignmentAnswer>().Update(assignmentAnswer);
            unitOfWork.Complete();
        }

        public void Add(CreateAssignmentAnswerModel model)
        {
            var assignmentAnswer = mapper.CreateAssignmentAnswerMapToEntity(model);
            unitOfWork.Repository<AssignmentAnswer>().Add(assignmentAnswer);
            unitOfWork.Complete();
        }
    }
}
