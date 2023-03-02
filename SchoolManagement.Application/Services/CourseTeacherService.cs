using SchoolManagement.Application.Mappers;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Domain.Specifications;
using SchoolManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class CourseTeacherService : ICourseTeacherService
    {
        private readonly CourseTeacherMapper courseTeacherMapper;
        private readonly IUnitOfWork unitOfWork;

        public CourseTeacherService(CourseTeacherMapper courseTeacherMapper, IUnitOfWork unitOfWork)
        {
            this.courseTeacherMapper = courseTeacherMapper;
            this.unitOfWork = unitOfWork;
        }

        public void Add(CreateCourseTeacherModel model)
        {
            var courseTeacher = courseTeacherMapper.CreateCourseTeacherMapToEntity(model);
            unitOfWork.Repository<CourseTeacher>().Add(courseTeacher);
            unitOfWork.Complete();
        }

        public void Remove(int id)
        {
            var courseTeacher = unitOfWork.Repository<CourseTeacher>().FindById(id);
            unitOfWork.Repository<CourseTeacher>().Remove(courseTeacher);
            unitOfWork.Complete();
        }

        public IEnumerable<CourseTeachersModel> GetAll()
        {
            var courseTeachers = unitOfWork.Repository<CourseTeacher>().Find(new CourseTeacherWithTeacherAndCourseSpecification());
            return courseTeacherMapper.EntityListToCourseTeacherModelList(courseTeachers);
        }

        public IEnumerable<CourseTeachersModel> GetByCourseId(int courseId)
        {
            var courseTeachers = unitOfWork.Repository<CourseTeacher>().Find(new CourseTeacherByCourseIdSpecification(courseId));
            return courseTeacherMapper.EntityListToCourseTeacherModelList(courseTeachers);
        }

        public CourseTeacherModel GetById(int id)
        {
            var courseTeacher = unitOfWork.Repository<CourseTeacher>().FindById(id);
            return courseTeacherMapper.EntityToCourseTeacherModel(courseTeacher);
        }

        public IEnumerable<CourseTeachersModel> GetByTeacherId(int teacherId)
        {
            var courseTeachers = unitOfWork.Repository<CourseTeacher>().Find(new CourseTeacherByTeacherIdSpecification(teacherId));
            return courseTeacherMapper.EntityListToCourseTeacherModelList(courseTeachers);
        }

        public void Update(CreateCourseTeacherModel model)
        {
            var courseTeacher = courseTeacherMapper.CreateCourseTeacherMapToEntity(model);
            unitOfWork.Repository<CourseTeacher>().Update(courseTeacher);
            unitOfWork.Complete();
        }
    }
}
