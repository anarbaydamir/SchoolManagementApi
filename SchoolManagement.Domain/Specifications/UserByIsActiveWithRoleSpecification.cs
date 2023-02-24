using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Entities.Abstractions;
using SchoolManagement.Domain.Specifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Specifications
{
    public class UserByIsActiveWithRoleSpecification : BaseSpecification<User>
    {
        public UserByIsActiveWithRoleSpecification() : base (x=> x.IsActive == true)
        {
            AddInclude(x => x.Role);
        }
    }
}
