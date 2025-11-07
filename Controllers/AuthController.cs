using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Saref.Models.Client;
using Saref.Models.Dtos;

namespace Saref.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly SignInManager<Client> _signInManager;
        private readonly UserManager<Client> _userManager;

        public AuthController(SignInManager<Client> signInManager, UserManager<Client> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Client>> Login([FromBody] DtoLoginViewModel model)
        {
            try
            {
                if (model.Username.Trim().Equals("") || model.Password.Trim().Equals(""))
                {
                    return NoContent();
                }
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("signin")]
        public async Task<ActionResult<Client>> Register([FromBody] DtoSignInViewModel model)
        {
            try
            {
                if (model.Username.Trim().Equals("") || model.Password.Trim().Equals("") || model.Name.Trim().Equals("") || model.DocumentNumber <= 0)
                {
                    return NoContent();
                }
                Client client = new Client { UserName = model.Username, Name = model.Name, DocumentNumber = model.DocumentNumber, Email = model.Email, Address = model.Address };
                var result = await _userManager.CreateAsync(client, model.Password);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
