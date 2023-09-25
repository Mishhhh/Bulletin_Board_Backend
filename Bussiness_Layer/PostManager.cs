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
    public class PostManager:IPostManager
    {
        IPostRepository _postRepository;
        public PostManager(IPostRepository repository)
        {
            _postRepository = repository;
            
        }

        public async Task AddPosts(Posts posts)
        {
             await _postRepository.AddPosts(posts);
             //await _postRepository.Addimage(posts);
           
        }

        public async Task DeletePosts(int PID)
        {
            await _postRepository.DeletePosts(PID);
        }

        public async Task<List<Posts>> GetAllPosts(int Limit, int page)
        {
            var result= await _postRepository.GetAllPosts(Limit,page);
            return result;  
        }

        public async Task<List<Posts>> GetCategories()
        {
            var result =await _postRepository.GetCategories();
            return result;
        }

        public async Task<Posts> GetPost(int PID)
        {
            var result= await _postRepository.GetPost(PID);
            return result;
        }

        public async Task<List<Posts>> GetPostByCategory(string category)
        {
            var result=await _postRepository.GetPostByCategory(category);
            return result;
        }

        public async Task UpdateLikes(int PID, int UID)
        {
            await _postRepository.UpdateLikes(PID, UID);
        }

        public async Task UpdatePost(Posts[] post)
        {
            await _postRepository.UpdatePost(post);
            
        }
    }
}
