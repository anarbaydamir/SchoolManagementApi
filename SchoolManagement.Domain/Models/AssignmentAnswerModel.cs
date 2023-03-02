using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class AssignmentAnswerModel
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public double Grade { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }


    }

    public class AssignmentAnswersModel : AssignmentAnswerModel
    {
        public User Student { get; set; }
        public Assignment Assignment { get; set; }
    }

    public class CreateAssignmentAnswerModel
    {
        public string Answer { get; set; }
        public double Grade { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
    }
}
