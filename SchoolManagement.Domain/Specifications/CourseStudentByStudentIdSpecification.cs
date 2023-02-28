using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Specifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Specifications
{
    public class CourseStudentByStudentIdSpecification : BaseSpecification<CourseStudent>
    {
        public CourseStudentByStudentIdSpecification(int studentId) : base(x => x.StudentId == studentId)
        {
            AddInclude(x => x.CourseTeacher);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
