using SchoolManagement.Domain.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class AssignmentAnswer :BaseEntity
    {
        public string Answer { get; set; }
        public double Grade { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }

        public User Student { get; set; }
        public Assignment Assignment { get; set; }
    }
}
