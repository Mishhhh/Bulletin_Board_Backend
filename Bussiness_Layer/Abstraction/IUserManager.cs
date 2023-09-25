using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer.Abstraction
{
    public interface IUserManager
    {
        public Task<List<Users>> GetAllUserInfo();
        public Task RegisterUser(Users user);
        public Task<List<Users>> GetUserByEmailId();
        public Task UpdateUsers(Users user);
        public Task DeleteUser(int id);
        public Task<int> GetPassword(Login login);
        public Task<List<UserName>> GetUserName();
    }
}
