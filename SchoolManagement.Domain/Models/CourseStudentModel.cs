using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class CourseStudentModel
    {
        public int Id { get; set; }
        public int CourseTeacherId { get; set; }
        public int StudentId { get; set; }

       
    }

    public class CourseStudentsModel : CourseStudentModel
    {
        public User Student { get; set; }
        public CourseTeacher CourseTeacher { get; set; }
    }

    public class CreateCourseStudentModel
    {
        public int CourseTeacherId { get; set; }
        public int StudentId { get; set; }
    }
}
