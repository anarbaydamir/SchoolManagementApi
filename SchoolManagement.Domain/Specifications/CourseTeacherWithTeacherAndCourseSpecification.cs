using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Specifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Specifications
{
    public class CourseTeacherWithTeacherAndCourseSpecification: BaseSpecification<CourseTeacher>
    {
        public CourseTeacherWithTeacherAndCourseSpecification()
        {
            AddInclude(x => x.Teacher);
            AddInclude(x => x.CourseTeachers);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
