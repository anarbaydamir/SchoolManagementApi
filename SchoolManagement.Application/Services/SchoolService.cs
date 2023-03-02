using SchoolManagement.Application.Mappers;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Domain.ProjectAggregates.Exceptions;
using SchoolManagement.Infrastructure.Persistence;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly SchoolMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SchoolService(SchoolMapper mapper, IUnitOfWork unitOfWork)
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

        public byte[] GetLogo(string logoName)
        {
            string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\", logoName + ".png");
            if (!File.Exists(logoPath))
                throw new LogoNotFoundException();

            using (FileStream fileStream = new FileStream(logoPath, FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
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

            using (MemoryStream stream = new MemoryStream(imageData))
            {
                using (Image image = Image.Load(stream))
                {
                    string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\", Guid.NewGuid().ToString());
                    try
                    {
                        using (MemoryStream imageStream = new MemoryStream())
                        {
                            await image.SaveAsync(imageStream, new PngEncoder());
                            File.WriteAllBytes(fileName + ".png",imageStream.ToArray());
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    return Path.GetFileName(fileName);
                }
            }
        }
    }
}
