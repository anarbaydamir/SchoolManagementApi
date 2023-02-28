using SchoolManagement.Domain.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class CourseTeacher: BaseEntity
    {
        public int CourseId { get; set; }
        public int TeacherId { get; set; }

        public Course Course { get; set; }
        public User Teacher { get; set; }
        public ICollection<CourseStudent> CourseStudents { get; set; }
        public ICollection<CourseTeacher> CourseTeachers { get; set; }
    }
}
