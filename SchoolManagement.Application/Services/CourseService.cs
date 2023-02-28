using SchoolManagement.Application.Mappers;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly CourseMapper courseMapper;
        private readonly IUnitOfWork unitOfWork;

        public CourseService(CourseMapper courseMapper, IUnitOfWork unitOfWork)
        {
            this.courseMapper = courseMapper;
            this.unitOfWork = unitOfWork;
        }

        public void Add(CreateCourseModel model)
        {
            var course = courseMapper.CreateCourseModelToEntity(model);
            unitOfWork.Repository<Course>().Add(course);
            unitOfWork.Complete();
        }

        public CourseModel GetById(int id)
        {
            var course = unitOfWork.Repository<Course>().FindById(id);
            return courseMapper.EntityToCourseModel(course);
        }

        public IEnumerable<CourseModel> GetAll()
        {
            var courses = unitOfWork.Repository<Course>().Find();
            return courseMapper.EntityListToCourseModelList(courses);   
        }

        public void Remove(int id)
        {
            var course = unitOfWork.Repository<Course>().FindById(id);
            unitOfWork.Repository<Course>().Remove(course);
            unitOfWork.Complete();
        }

        public void Update(CourseModel model)
        {
            var course = courseMapper.CourseModelToEntity(model);
            unitOfWork.Repository<Course>().Update(course);
            unitOfWork.Complete();
        }
    }
}
