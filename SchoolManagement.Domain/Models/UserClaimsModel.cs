using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.Models
{
    public class UserClaimsModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string RefreshToken { get; set; }
        public Role Role { get; set; }
    }
}
