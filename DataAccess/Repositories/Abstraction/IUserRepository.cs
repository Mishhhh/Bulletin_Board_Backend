using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstraction
{
    public interface IUserRepository
    {
        public Task<List<Users>> GetAllUser();
        public Task Register(Users users);
        public Task<List<Users>> GetUserEmails();
        public Task UpdateUser(Users user);
        public Task DeleteUser(int id);
        public Task<int> GetPass(Login login);
        public Task<List<UserName>> GetUserName();
    }
}
