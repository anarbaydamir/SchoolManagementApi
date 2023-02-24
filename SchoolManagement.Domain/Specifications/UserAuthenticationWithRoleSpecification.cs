using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Specifications.Abstractions;

namespace SchoolManagement.Domain.Specifications
{
    public class UserAuthenticationWithRoleSpecification : BaseSpecification<User>
    {
        public UserAuthenticationWithRoleSpecification(string email)
                                                        : base(x => x.Email == email)
        {
            AddInclude(x => x.Role);
        }
    }
}
