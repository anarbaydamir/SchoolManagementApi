using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CreateRoleModel
    {
        public string Name { get; set; }
    }
}
