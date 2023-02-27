using SchoolManagement.Application.Mappers;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleMapper roleMapper;
        private readonly IUnitOfWork unitOfWork;

        public RoleService(RoleMapper roleMapper, IUnitOfWork unitOfWork)
        {
            this.roleMapper = roleMapper;
            this.unitOfWork = unitOfWork;
        }

        public void Add(CreateRoleModel model)
        {
            var role = roleMapper.CreateRoleMapToEntity(model);
            unitOfWork.Repository<Role>().Add(role);
            unitOfWork.Complete();
        }

        public IEnumerable<RoleModel> GetAll()
        {
            var roles = unitOfWork.Repository<Role>().Find().ToList();
            return roleMapper.EntityListMapToRoleModelList(roles);
        }
    }
}
