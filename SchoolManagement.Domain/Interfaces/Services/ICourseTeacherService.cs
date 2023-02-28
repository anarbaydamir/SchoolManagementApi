using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces.Services
{
    public interface ICourseTeacherService
    {
        IEnumerable<CourseTeachersModel> GetAll();
        IEnumerable<CourseTeachersModel> GetByCourseId(int courseId);
        IEnumerable<CourseTeachersModel> GetByTeacherId(int teacherId);

        CourseTeacherModel GetById(int id);
        void Add(CreateCourseTeacherModel model);
        void Update(CreateCourseTeacherModel model);
        void Remove(int id);    
    }
}
