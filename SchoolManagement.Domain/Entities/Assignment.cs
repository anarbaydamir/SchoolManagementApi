using SchoolManagement.Domain.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Assignment : BaseEntity
    {
        public string Name { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public int CourseTeacherId { get; set; }

        public CourseTeacher CourseTeacher { get; set; }
        public ICollection<AssignmentAnswer> AssignmentAnswers { get; set; }
    }
}
