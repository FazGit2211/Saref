using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Saref.Models.Client;
using Saref.Models.Dtos;
using Saref.Services.JwtServices;

namespace Saref.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly SignInManager<Client> _signInManager;
        private readonly UserManager<Client> _userManager;
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(SignInManager<Client> signInManager, UserManager<Client> userManager, JwtTokenService jwtTokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
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
                    var token = _jwtTokenService.GenerateToken(model.Username);
                    return Ok(new { Token = token });
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
            Client client = new Client { UserName = model.Username, Name = model.Name, DocumentNumber = model.DocumentNumber, Email = model.Email, Address = model.Address };
            var clientWithRole = await _userManager.AddToRoleAsync(client, "ADMIN");
            if (!clientWithRole.Succeeded)
            {
                throw new Exception("Error add role user");
            }
            var result = await _userManager.CreateAsync(client, model.Password);
            if (!result.Succeeded)
            {
               throw new Exception("Error create user"); 
            }
            return Ok(result);
        }
    }
}
