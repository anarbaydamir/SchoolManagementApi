using SchoolManagement.Domain.Entities.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SchoolManagement.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; } = true;
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public Role Role { get; set; }

        public ICollection<CourseTeacher> CourseTeachers { get; set; }
        public ICollection<CourseStudent> CourseStudents { get; set; }
        public ICollection<AssignmentAnswer> AssignmentAnswers { get; set; }

    }
}
