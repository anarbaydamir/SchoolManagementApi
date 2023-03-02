using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.ProjectAggregates.Exceptions
{
    public class LogoNotFoundException: AppException
    {
        public LogoNotFoundException()
            : base("Logo not found") { }
    }
}
