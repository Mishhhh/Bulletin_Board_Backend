using Bussiness_Layer.Abstraction;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bulletin_Board.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentManager _commentManager;
        public CommentController(ICommentManager commentManager)
        {
            _commentManager = commentManager;            
        }
        [HttpGet]
        public async Task<ActionResult<List<Comments>>> GetAllComments()
        {
            var result= await _commentManager.GetAllComments();
            return Ok(result);
        }
        [HttpGet("/commentByPostId")]
        public async Task<ActionResult<List<Comments>>> GetComments(int PID)
        {
            var result = await _commentManager.GetComment(PID);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> AddComment(Comments[] comments)
        {
            await _commentManager.AddComment(comments);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult>UpdateComments(Comments[] comments)
        {
            await _commentManager.UpdateComment(comments);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult>DeleteComments(int CID,int PID,int UID)
        {
            await _commentManager.DeleteComment(CID, PID, UID);
            return Ok();
        }
        
    }
}
