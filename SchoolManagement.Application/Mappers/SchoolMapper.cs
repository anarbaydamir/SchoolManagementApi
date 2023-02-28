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
    public class SchoolMapper
    {
        public IEnumerable<SchoolModel> EntityListMapToSchoolModelList(IEnumerable<School> schools) => schools.Adapt<IEnumerable<SchoolModel>>();
        public SchoolModel EntityToSchoolModel(School school) => school.Adapt<SchoolModel>();
    }
}
