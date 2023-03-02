using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces.Services
{
    public interface IAssignmentAnswerService
    {
        IEnumerable<AssignmentAnswersModel> GetAll();
        AssignmentAnswerModel GetById(int id);
        void Add(CreateAssignmentAnswerModel model);
        void Update(CreateAssignmentAnswerModel model);
        void Remove(int id);
    }
}
