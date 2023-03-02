using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class AssignmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public int CourseTeacherId { get; set; }

    }

    public class AssignmentsModel: AssignmentModel
    {
        public CourseTeacher CourseTeacher { get; set; }
    }

    public class CreateAssignmentModel
    {
        public string Name { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public int CourseTeacherId { get; set; }
    }
}
