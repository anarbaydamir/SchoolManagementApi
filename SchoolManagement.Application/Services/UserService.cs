using SchoolManagement.Application.Mappers;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Domain.ProjectAggregates.Exceptions;
using SchoolManagement.Domain.ProjectAggregates.Helpers;
using SchoolManagement.Domain.Specifications;
using SchoolManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserMapper userMapper;
        private readonly IUnitOfWork unitOfWork;

        public UserService(UserMapper userMapper, IUnitOfWork unitOfWork)
        {
            this.userMapper = userMapper;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<UsersModel> GetAll()
        {
            var users = unitOfWork.Repository<User>().Find(new UserByIsActiveWithRoleSpecification());
            return userMapper.EntityListToUsersModelList(users);   
        }
        public UserModel GetById(int id)
        {
            var user = unitOfWork.Repository<User>().FindById(id);
            return userMapper.EntityToUserModel(user);
        }
        public void Add(CreateUserModel model)
        {
            if (CheckEmailExists(model.Email))
                throw new UserEmailExistsException();

            model.Password = PasswordManager.HashPassword(model.Password);
            var user = userMapper.CreateUserMapToEntity(model);
            unitOfWork.Repository<User>().Add(user);
            unitOfWork.Complete();
        }

        public void Update(UserModel model)
        {
            var user = userMapper.UserModelToEntity(model);
            unitOfWork.Repository<User>().Update(user);
            unitOfWork.Complete();
        }

        public void Remove(int id)
        {
            var user = unitOfWork.Repository<User>().FindById(id);
            user.IsActive = false;
            unitOfWork.Repository<User>().Update(user);
            unitOfWork.Complete();
        }

        private bool CheckEmailExists(string email)
        {
            var user = unitOfWork.Repository<User>().Find(new UserByEmailSpecification(email)).FirstOrDefault();
            return user != null;
        }
    }
}
