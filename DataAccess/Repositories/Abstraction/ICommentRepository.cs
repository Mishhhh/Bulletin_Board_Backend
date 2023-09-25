using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstraction
{
    public interface ICommentRepository
    {
        public Task<List<Comments>> GetComment(int PID);
        public Task<List<Comments>> GetAllComments();
        public Task AddComment(Comments[] comment);
        public Task UpdateComment(Comments[] comment);
        public Task DeleteComment(int CID, int PID, int UID);
    }
}
