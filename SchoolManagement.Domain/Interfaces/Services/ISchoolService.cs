using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces.Services
{
    public interface ISchoolService
    {
        IEnumerable<SchoolModel> GetAll();
        SchoolModel GetById(int id);
        Task Add(CreateSchoolModel model);
        Task Update(CreateSchoolModel model);
        void Remove(int id);
    }
}
