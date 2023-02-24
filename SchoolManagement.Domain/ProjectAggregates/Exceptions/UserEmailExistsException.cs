using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.ProjectAggregates.Exceptions
{
    public class UserEmailExistsException : AppException
    {
        public UserEmailExistsException()
            : base("User with this email already exists")
        {
        }
    }
}
