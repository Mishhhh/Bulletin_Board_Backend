using Bussiness_Layer.Abstraction;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Bulletin_Board.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;

        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetUser()
        {
            var result = await _userManager.GetAllUserInfo().ConfigureAwait(false);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> RegisterUser(Users user)
        {
            await _userManager.RegisterUser(user).ConfigureAwait(false);
            return Ok();
        }
        [HttpGet("/UserEmails")]
        public async Task<ActionResult<List<Users>>> GetUserByEmailId()
        {
            var result = await _userManager.GetUserByEmailId().ConfigureAwait(false);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult>UpdateUser(Users user)
        {
            await _userManager.UpdateUsers(user);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult>DeleteUsers(int UID)
        {
            await _userManager.DeleteUser(UID);
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<ActionResult<int>>Authentication(Login login)
        {
            var result=await _userManager.GetPassword(login);
            return Ok(result);

        }
        [HttpGet("Name")]
        public async Task<ActionResult<List<UserName>>> GetUserName()
        {
            var result = await _userManager.GetUserName();
            return Ok(result);
        }
    }
}
