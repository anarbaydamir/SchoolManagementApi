using Mapster;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Mappers
{
    public class CourseStudentMapper
    {
        public CourseStudent CreateCourseStudentMapToEntity(CreateCourseStudentModel model) => model.Adapt<CourseStudent>();

        public IEnumerable<CourseStudentsModel> EntityListToCourseStudentModelList(IEnumerable<CourseStudent> courseStudents) => courseStudents.Adapt<IEnumerable<CourseStudentsModel>>();
        public CourseStudentModel EntityToCourseStudentModel(CourseStudent courseStudent) => courseStudent.Adapt<CourseStudentModel>();
        public CourseStudent CourseStudentModelToEntity(CourseStudentModel model) => model.Adapt<CourseStudent>();
    }
}
