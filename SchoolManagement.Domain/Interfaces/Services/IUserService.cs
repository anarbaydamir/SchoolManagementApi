using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<UsersModel> GetAll();
        UserModel GetById(int id);
        void Add(CreateUserModel model);
        void Update(UserModel model);
        void Remove(int id);   
    }
}
