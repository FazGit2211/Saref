using Microsoft.AspNetCore.Mvc;
using Saref.Models.User;
using Saref.Services.UserService;

namespace Saref.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly UserService _userService;
        public AuthController(UserService userService)
        {
            _userService = userService;
        }
        [Route("signin")]
        [HttpPost]
        public async Task<ActionResult<User>> SignIn([FromBody] User user)
        {
            try
            {
                User userExist = await _userService.CreateUser(user);
                if (userExist == null)
                {
                    return BadRequest("User can not signin.");
                }
                return Ok(userExist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<User>> Login([FromBody] User user)
        {
            try
            {
                User userExist = await _userService.GetUser(user);
                if (userExist == null)
                {
                    return BadRequest("User not exist.");
                }
                return Ok(userExist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
