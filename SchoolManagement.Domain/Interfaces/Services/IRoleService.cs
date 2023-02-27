using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleModel> GetAll();
        void Add(CreateRoleModel model);
    }
}
