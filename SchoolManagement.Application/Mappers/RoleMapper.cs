using Mapster;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Mappers
{
    public class RoleMapper
    {
        public Role CreateRoleMapToEntity(CreateRoleModel model) => model.Adapt<Role>();
        
        public IEnumerable<RoleModel> EntityListMapToRoleModelList(IEnumerable<Role> roles) => roles.Adapt<IEnumerable<RoleModel>>();   
    }
}
