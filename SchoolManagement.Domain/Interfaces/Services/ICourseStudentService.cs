using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces.Services
{
    public interface ICourseStudentService
    {
        IEnumerable<CourseStudentsModel> GetByCourseTeacherId(int courseTeacherId);
        IEnumerable<CourseStudentsModel> GetByStudentId(int studentId);
        CourseStudentModel GetById(int id);
        void Add(CreateCourseStudentModel model);
        void Update(CreateCourseStudentModel model);
        void Remove(int id);
    }
}
