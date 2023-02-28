using Mapster;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Mappers
{
    public class CourseTeacherMapper
    {
        public CourseTeacher CreateCourseTeacherMapToEntity(CreateCourseTeacherModel model) => model.Adapt<CourseTeacher>();

        public IEnumerable<CourseTeachersModel> EntityListToCourseTeacherModelList(IEnumerable<CourseTeacher> courseTeachers) => courseTeachers.Adapt<IEnumerable<CourseTeachersModel>>();
        public CourseTeacherModel EntityToCourseTeacherModel(CourseTeacher courseTeacher) => courseTeacher.Adapt<CourseTeacherModel>();
        public CourseTeacher CourseTeacherModelToEntity(CourseTeacherModel model) => model.Adapt<CourseTeacher>();
    }
}
