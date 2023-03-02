using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Specifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Specifications
{
    public class AssignmentAnswerWithAssignmentAndStudentSpecification: BaseSpecification<AssignmentAnswer>
    {
        public AssignmentAnswerWithAssignmentAndStudentSpecification()
        {
            AddInclude(x => x.Assignment);
            AddInclude(x => x.Student);
        }
    }
}
