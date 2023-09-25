using DataAccess.DBContext;
using DataAccess.Models;
using DataAccess.Repositories.Abstraction;

namespace DataAccess.Reposiories
{
    public class UserRepository:IUserRepository
    {
         private readonly IDatabaseContext _dbContext;
        public UserRepository(IDatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public async Task DeleteUser(int UID)
        {
            string sql = $"exec dbo.DeleteUser @UID={UID}";
            await _dbContext.ExecuteCommand<Users>(sql, UID);
            
        }

        public async Task<List<Users>> GetAllUser()
        {
            string sql = "exec dbo.GetUser";
            var result = await _dbContext.ExecuteCommand<Users>(sql, null);
            return (List<Users>)result;
        }

        public async Task<int> GetPass(Login login)
        {
            string sql = "exec dbo.GetPassword @Email=@Email,@Password=@Password";
            var result = await _dbContext.ExecuteCommand<int>(sql, login);
            return result.FirstOrDefault();
        }

        public async Task<List<Users>> GetUserEmails()
        {
            string sql = "exec dbo.GetUserEmails";
            var result = await _dbContext.ExecuteCommand<Users>(sql, null);
            return(List<Users>)result;
        }

        public async Task<List<UserName>> GetUserName()
        { 
            string sql = "select UID,Name from Users";
            var result = await _dbContext.ExecuteCommand<UserName>(sql, null);
            return result.ToList();
        }

        public async Task Register(Users users)
        {
            string sql = "insert into Users values (@Name,@Email,@Password,@PhoneNo,@IsActive);";
            await _dbContext.ExecuteCommand<Users>(sql, users);
        }

        public async Task UpdateUser(Users user)
        {
            string sql = "exec dbo.UpdateUser @UID=@UID ,@Name=@Name,@Email=@Email,@Password=@Password,@PhoneNo=@PhoneNo,@IsActive=@IsActive";
            await _dbContext.ExecuteCommand<Users>(sql, user);
            
        }
    }
}