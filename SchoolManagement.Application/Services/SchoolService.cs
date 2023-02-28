using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Application.Mappers;
using SchoolManagement.Infrastructure.Persistence;

namespace SchoolManagement.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly SchoolMapper mapper;
        private readonly UnitOfWork unitOfWork;

        public SchoolService(SchoolMapper mapper, UnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task Add(CreateSchoolModel model)
        {
            var imagePath = await SaveImageAndReturnPath(model.LogoBase64);
            var school = new School
            {
                Name = model.Name,
                Description = model.Description,
                LogoPath = imagePath
            };
            
            unitOfWork.Repository<School>().Add(school);
            unitOfWork.Complete();
        }

        public IEnumerable<SchoolModel> GetAll()
        {
            var schools = unitOfWork.Repository<School>().Find();
            return mapper.EntityListMapToSchoolModelList(schools);
        }

        public SchoolModel GetById(int id)
        {
            var school = unitOfWork.Repository<School>().FindById(id);
            return mapper.EntityToSchoolModel(school);
        }

        public void Remove(int id)
        {
            var school = unitOfWork.Repository<School>().FindById(id);
            unitOfWork.Repository<School>().Remove(school);
            unitOfWork.Complete();  
        }

        public async Task Update(CreateSchoolModel model)
        {
            var imagePath = await SaveImageAndReturnPath(model.LogoBase64);
            var school = new School
            {
                Name = model.Name,
                Description = model.Description,
                LogoPath = imagePath
            };
            unitOfWork.Repository<School>().Update(school);
            unitOfWork.Complete();
        }

        private async Task<string> SaveImageAndReturnPath(string imageBase64)
        {
            byte[] imageData = Convert.FromBase64String(imageBase64);

            using(MemoryStream stream = new MemoryStream(imageData))
            {
                using(Image image = Image.Load(stream))
                {
                    string fileName = Path.Combine("~/Images", Guid.NewGuid().ToString());
                    using(FileStream fileStream = new FileStream(fileName, FileMode.CreateNew))
                    {
                        await image.SaveAsPngAsync(fileStream);
                    }
                    return Path.GetFileName(fileName);
                }
            }
        }
    }
}
