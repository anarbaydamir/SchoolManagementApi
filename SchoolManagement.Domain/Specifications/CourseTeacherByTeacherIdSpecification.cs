using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Specifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Specifications
{
    public class CourseTeacherByTeacherIdSpecification: BaseSpecification<CourseTeacher>
    {
        public CourseTeacherByTeacherIdSpecification(int teacherId) : base(x => x.TeacherId == teacherId)
        {
            AddInclude(x => x.Teacher);
            AddInclude(x => x.Course);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
