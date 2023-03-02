using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Specifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Specifications
{
    public class AssignmentWithCourseTeacherSpecification : BaseSpecification<Assignment>
    {
        public AssignmentWithCourseTeacherSpecification() 
        {
            AddInclude(x => x.CourseTeacher.Course);
            AddInclude(x => x.CourseTeacher.Teacher);
        }
    }
}
