using SchoolManagement.Domain.Models;
using System.Collections.Generic;

namespace SchoolManagement.Domain.Interfaces.Services
{
    public interface ICourseService
    {
        IEnumerable<CourseModel> GetAll();
        CourseModel GetById(int id);
        void Add(CreateCourseModel model);
        void Update(CourseModel model);
        void Remove(int id);
    }
}
