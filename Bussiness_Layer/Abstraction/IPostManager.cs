using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer.Abstraction
{
    public interface IPostManager
    {
        public Task<List<Posts>> GetAllPosts(int limit, int page);
        public Task<Posts> GetPost(int PID);
        public Task AddPosts(Posts posts);
        public Task DeletePosts(int PID);
        public Task<List<Posts>> GetCategories();
        public Task UpdatePost(Posts[] post);
        public Task UpdateLikes(int PID, int UID);
        public Task<List<Posts>> GetPostByCategory(string category);
    }
}
