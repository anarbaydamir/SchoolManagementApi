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
    public class CourseStudentService : ICourseStudentService
    {
        private readonly CourseStudentMapper mapper;
        private readonly UnitOfWork unitOfWork;

        public CourseStudentService(CourseStudentMapper mapper, UnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public void Add(CreateCourseStudentModel model)
        {
            var courseStudent = mapper.CreateCourseStudentMapToEntity(model);
            unitOfWork.Repository<CourseStudent>().Add(courseStudent);
            unitOfWork.Complete();
        }

        public void Remove(int id)
        {
            var courseStudent = unitOfWork.Repository<CourseStudent>().FindById(id);
            unitOfWork.Repository<CourseStudent>().Remove(courseStudent);
            unitOfWork.Complete();
        }

        public IEnumerable<CourseStudentsModel> GetByCourseTeacherId(int courseTeacherId)
        {
            var courseStudents = unitOfWork.Repository<CourseStudent>().Find(new CourseStudentByCourseTeacherIdSpecification(courseTeacherId));
            return mapper.EntityListToCourseStudentModelList(courseStudents);
        }

        public CourseStudentModel GetById(int id)
        {
            var courseStudent = unitOfWork.Repository<CourseStudent>().FindById(id);
            return mapper.EntityToCourseStudentModel(courseStudent);
        }

        public IEnumerable<CourseStudentsModel> GetByStudentId(int studentId)
        {
            var courseStudents = unitOfWork.Repository<CourseStudent>().Find(new CourseStudentByStudentIdSpecification(studentId));
            return mapper.EntityListToCourseStudentModelList(courseStudents);
        }

        public void Update(CreateCourseStudentModel model)
        {
            var courseStudent = mapper.CreateCourseStudentMapToEntity(model);
            unitOfWork.Repository<CourseStudent>().Update(courseStudent);
            unitOfWork.Complete();
        }
    }
}
