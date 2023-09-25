using Bussiness_Layer.Abstraction;
using DataAccess.Models;
using DataAccess.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class CommentManager:ICommentManager
    {
        ICommentRepository _commentRepo;
        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepo = commentRepository;
        }

        public async Task AddComment(Comments[] comment)
        {
            await _commentRepo.AddComment(comment);
        }

        public async Task DeleteComment(int CID, int PID,int UID)
        {
            await _commentRepo.DeleteComment(CID, PID,UID);
        }

        public async Task<List<Comments>> GetAllComments()
        {
            var result=await _commentRepo.GetAllComments();
            return result;
        }

        public async Task<List<Comments>> GetComment(int PID)
        {
            var result= await _commentRepo.GetComment(PID);
            return result;
        }

        public async Task UpdateComment(Comments[] comment)
        {
            await _commentRepo.UpdateComment(comment);
        }
    }
}
