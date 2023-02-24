using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Specifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Specifications
{
    public class UserByRefreshTokenWithRoleSpecification : BaseSpecification<User>
    {
        public UserByRefreshTokenWithRoleSpecification(string refreshToken) : base(x=>x.RefreshToken == refreshToken)
        {
            AddInclude(x => x.Role);
        }
    }
}
