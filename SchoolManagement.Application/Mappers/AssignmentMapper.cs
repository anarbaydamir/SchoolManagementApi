using Mapster;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Mappers
{
    public class AssignmentMapper
    {
        public Assignment CreateAssignmentMapToEntity(CreateAssignmentModel model) => model.Adapt<Assignment>();

        public IEnumerable<AssignmentsModel> EntityListToAssignmentModelList(IEnumerable<Assignment> assignments) => assignments.Adapt<IEnumerable<AssignmentsModel>>();
        public AssignmentModel EntityToAssignmentModel(Assignment assignment) => assignment.Adapt<AssignmentModel>();
        public Assignment AssignmentModelToEntity(AssignmentModel model) => model.Adapt<Assignment>();
    }
}
