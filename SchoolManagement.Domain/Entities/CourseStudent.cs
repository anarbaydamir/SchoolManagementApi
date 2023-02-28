using SchoolManagement.Domain.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class CourseStudent: BaseEntity
    {
        public int CourseTeacherId { get; set; }
        public int StudentId { get; set; }

        public User Student { get; set; }
        public CourseTeacher CourseTeacher { get; set; }
    }
}
