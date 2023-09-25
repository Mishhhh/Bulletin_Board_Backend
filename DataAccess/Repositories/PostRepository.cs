using Dapper;
using DataAccess.DBContext;
using DataAccess.Models;
using DataAccess.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PostRepository:IPostRepository
    {
        IDatabaseContext _dbContext;
        public PostRepository(IDatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public async Task<int> AddPosts(Posts posts)
        {
            IEnumerable<int> result;
            string sql = "exec dbo.AddPost @PostDetails=@PostDetails,@PostTitle=@PostTitle,@UID=@UID,@Category=@Category";
            result =await _dbContext.ExecuteCommand<int>(sql, posts);
            return result.FirstOrDefault();
        }

        public async Task DeletePosts(int PID)
        {
            string sql = $"exec dbo.DeletePost @PID={PID} ";
            await _dbContext.ExecuteCommand<Posts>(sql, PID);

        }

        public async Task<List<Posts>> GetAllPosts(int limit,int page)
        {
            int offset = (page - 1) * limit;
            string sql = "exec dbo.GetPosts @limit=@limit ,@offset=@offset";
            var result = await _dbContext.ExecuteCommand<Posts>(sql, new {limit,offset});
            return result.ToList();
        }

        public async Task<List<Posts>> GetCategories()
        {
            string sql = "exec dbo.GetCategories";
            var result=await _dbContext.ExecuteCommand<Posts>(sql,null);
            return result.ToList();
        }
        public async Task<List<Posts>> GetPostByCategory(string category)
        {
            string sql = $"select * from Posts where Category='{category}'";
            var result = await _dbContext.ExecuteCommand<Posts>(sql, null);
            return result.ToList(); 
        }

        public async Task<Posts> GetPost(int PID)
        {   
            string sql = $"exec dbo.GetPost @PID={PID}";
            
            var result = await _dbContext.ExecuteCommand<Posts>(sql,PID);
            return result.First();
        }

        public async Task UpdateLikes(int PID, int UID)
        {
            string sql = $"insert into Likes values(@UID,@PID)";
            await _dbContext.ExecuteCommand<Posts>(sql,new { UID,PID});
        }

        public async Task UpdatePost(Posts[] post)
        {
            string sql = "update Posts set PostTitle=@PostTitle,PostDetails=@PostDetails,Category=@Category,Timestamp=getdate() where PID=@PID and UID=@UID";
            foreach (var item in post)
            {
                await _dbContext.ExecuteCommand<Posts>(sql, item);
            }
            
        }

        //public async Task Addimage(Posts posts)
        //{
        //    string sql = "insert into Posts (ImageUrl) values (@ImageUrl)";
        //    await _dbContext.ExecuteCommand<Posts>(sql, posts);
            
        //}
    }
}
