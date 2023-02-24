using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Specifications.Abstractions;

namespace SchoolManagement.Domain.Specifications
{
    public class UserByEmailSpecification : BaseSpecification<User>
    {
        public UserByEmailSpecification(string email) : base(x => x.Email == email)
        {
        }
    }
}
