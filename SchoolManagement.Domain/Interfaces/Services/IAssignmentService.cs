using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces.Services
{
    public interface IAssignmentService
    {
        IEnumerable<AssignmentsModel> GetAll();
        AssignmentModel GetById(int id);
        void Add(CreateAssignmentModel model);
        void Update(CreateAssignmentModel model);
        void Remove(int id);
    }
}
