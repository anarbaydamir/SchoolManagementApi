using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Specifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Specifications
{
    public class CourseTeacherByCourseIdSpecification : BaseSpecification<CourseTeacher>
    {
        public CourseTeacherByCourseIdSpecification(int courseId) : base(x => x.CourseId == courseId)
        {
            AddInclude(x => x.Course);
            AddInclude(x => x.Teacher);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
