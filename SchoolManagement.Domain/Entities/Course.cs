﻿using SchoolManagement.Domain.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<CourseTeacher> CourseTeachers { get; set; }
    }
}
