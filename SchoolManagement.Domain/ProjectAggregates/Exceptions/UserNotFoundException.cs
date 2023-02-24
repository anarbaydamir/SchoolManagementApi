using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.ProjectAggregates.Exceptions
{
    public class UserNotFoundException : AppException
    {
        public UserNotFoundException()
            : base("User does not exist")
        {
        }
    }
}
