using Mapster;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Mappers
{
    public class UserMapper
    {
        public User CreateUserMapToEntity(CreateUserModel model) => model.Adapt<User>();

        public UserClaimsModel EntityToUserClaimsModel(User user) => user.Adapt<UserClaimsModel>();

        public IEnumerable<UsersModel> EntityListToUsersModelList(IEnumerable<User> users) => users.Adapt<IEnumerable<UsersModel>>();
        public UserModel EntityToUserModel(User user) => user.Adapt<UserModel>();
        public User UserModelToEntity(UserModel model) => model.Adapt<User>();
    }
}
