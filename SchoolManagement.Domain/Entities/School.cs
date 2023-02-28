using SchoolManagement.Domain.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class School: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
    }
}
