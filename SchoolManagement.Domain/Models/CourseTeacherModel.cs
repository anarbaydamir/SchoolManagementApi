using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class CourseTeacherModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
    }

    public class CourseTeachersModel : CourseTeacherModel
    {
        public Course Course { get; set; }
        public User User { get; set; }
    }

    public class CreateCourseTeacherModel
    {
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
    }
}
