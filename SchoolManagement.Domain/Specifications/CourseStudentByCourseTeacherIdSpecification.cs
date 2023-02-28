using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Specifications.Abstractions;

namespace SchoolManagement.Domain.Specifications
{
    public class CourseStudentByCourseTeacherIdSpecification : BaseSpecification<CourseStudent>
    {
        public CourseStudentByCourseTeacherIdSpecification(int courseTeacherId) : base(x => x.CourseTeacherId == courseTeacherId)
        {
            AddInclude(x => x.Student);
            AddInclude(x => x.CourseTeacher.Course);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
