using Mapster;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Mappers
{
    public class CourseMapper
    {
        public Course CreateCourseModelToEntity(CreateCourseModel model) => model.Adapt<Course>();
        public CourseModel EntityToCourseModel(Course course) => course.Adapt<CourseModel>();
        public Course CourseModelToEntity(CourseModel model) => model.Adapt<Course>();
        public IEnumerable<CourseModel> EntityListToCourseModelList(IEnumerable<Course> courses) => courses.Adapt<IEnumerable<CourseModel>>();

    }
}
