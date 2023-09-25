using DataAccess.DBContext;
using DataAccess.Models;
using DataAccess.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        IDatabaseContext _dbContext;
        public CommentRepository(IDatabaseContext databaseContext)
        {
            _dbContext = databaseContext;            
        }

        public async Task AddComment(Comments[] comment)
        {
            string sql = "insert into Comments values(@CommentDetails,@UID,getdate(),@PID)";
            foreach (var item in comment)
            {
                await _dbContext.ExecuteCommand<Comments>(sql, item);
            }          
           
        }
        public async Task DeleteComment(int CID, int PID, int UID )
        {
            string sql = $"delete from Comments where PID='{PID}' and CID='{CID}'and UID='{UID}' ";
            await _dbContext.ExecuteCommand<Comments>(sql, new {PID,CID,UID});
        }

        public async Task<List<Comments>> GetAllComments()
        {
            string sql = "select * from Comments";
            var result = await _dbContext.ExecuteCommand<Comments>(sql, null);
            return result.ToList();
        }

        public async Task<List<Comments>> GetComment(int PID)
        {
            string sql = $"select * from Comments where PID='{PID}'";
            var result=await _dbContext.ExecuteCommand<Comments>(sql,PID); 
            return result.ToList();
        }

        public async Task UpdateComment(Comments[] comment)
        {
            string sql = $"update Comments set CommentDetails=@CommentDetails where UID=@UID and PID=@PID and CID=@CID";
            foreach (var item in comment)
            {
                await _dbContext.ExecuteCommand<Comments>(sql, item);
            }
            
        }
    }
}
