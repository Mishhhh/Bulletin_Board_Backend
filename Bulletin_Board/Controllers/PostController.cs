using Bussiness_Layer;
using Bussiness_Layer.Abstraction;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bulletin_Board.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostManager _postManager;
        public PostController(IPostManager manager)
        {
            _postManager = manager;
        }
        [HttpPost]
        public async Task<ActionResult> AddPost(Posts posts)
        {
            try
            {
                await _postManager.AddPosts(posts);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Not Created!!");
            }
        }
        [HttpGet("Post_By_Category")]
        public async Task<ActionResult<List<Posts>>>GetPostByCategory(string Category)
        {
            try
            {
                var result = await _postManager.GetPostByCategory(Category);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Not a Valid Category");
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Posts>>>GetAllPosts(int Limit,int page)
        {
            try
            {
                var result = await _postManager.GetAllPosts(Limit, page);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest("Page not found");
            }
        }

        [HttpGet("/PostDetails")]
        public async Task<ActionResult<Posts>>GetPost(int PID)
        {
            var result = await _postManager.GetPost(PID);
            return Ok(result);  
        }

        [HttpGet("/Categories")]
        public async Task<ActionResult<List<Posts>>> GetCategories()
        {
            var result= await _postManager.GetCategories();
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdatePost(Posts[] posts)
        {
            await _postManager.UpdatePost(posts);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeletePost(int PID)
        {
            await _postManager.DeletePosts(PID);
            return Ok();
        }
        [HttpPost("Like")]
        public async Task<ActionResult> UpdateLikes(int PID, int UID)
        {
            try
            {
                await _postManager.UpdateLikes(PID, UID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Already Liked!!");
            }
        }
    }
}
