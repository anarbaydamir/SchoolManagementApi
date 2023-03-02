using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces.Services
{
    public interface ISchoolService
    {
        IEnumerable<SchoolModel> GetAll();
        byte[] GetLogo(string logoName);
        SchoolModel GetById(int id);
        Task Add(CreateSchoolModel model);
        Task Update(CreateSchoolModel model);
        void Remove(int id);
    }
}
