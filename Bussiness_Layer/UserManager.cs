using Bussiness_Layer.Abstraction;
using DataAccess.Models;
using DataAccess.Repositories.Abstraction;

namespace Bussiness_Layer
{
    public class UserManager:IUserManager
    {
        IUserRepository _repository;
        public UserManager(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteUser(int UID)
        {
            await _repository.DeleteUser(UID);
            
        }

        public async Task<List<Users>> GetAllUserInfo()
        {
            var result=await _repository.GetAllUser().ConfigureAwait(false);
            return result;
            
        }

        public async Task<int> GetPassword(Login login)
        {
            int result= await _repository.GetPass(login);
            return result;
            
            
        }

        public async Task<List<Users>> GetUserByEmailId()
        {
            var result = await _repository.GetUserEmails().ConfigureAwait(false);
            return result;
        }

        public async Task<List<UserName>> GetUserName()
        {
            var result = await _repository.GetUserName();
            return result;
        }

        public async Task RegisterUser(Users user)
        {
            await _repository.Register(user);
        }

        public async Task UpdateUsers(Users user)
        {
            await _repository.UpdateUser(user);
            
        }
    }
}