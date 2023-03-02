using Mapster;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Mappers
{
    public class AssignmentAnswerMapper
    {
        public AssignmentAnswer CreateAssignmentAnswerMapToEntity(CreateAssignmentAnswerModel model) => model.Adapt<AssignmentAnswer>();

        public IEnumerable<AssignmentAnswersModel> EntityListToAssignmentAnswerModelList(IEnumerable<AssignmentAnswer> assignmentAnswers) => assignmentAnswers.Adapt<IEnumerable<AssignmentAnswersModel>>();
        public AssignmentAnswerModel EntityToAssignmentAnswerModel(AssignmentAnswer assignmentAnswer) => assignmentAnswer.Adapt<AssignmentAnswerModel>();
        public AssignmentAnswer AssignmentAnswerModelToEntity(AssignmentAnswerModel model) => model.Adapt<AssignmentAnswer>();
    }
}
