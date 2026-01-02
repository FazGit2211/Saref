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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(SignInManager<Client> signInManager, UserManager<Client> userManager, RoleManager<IdentityRole> roleManager, JwtTokenService jwtTokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Client>> Login([FromBody] DtoLoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);
            if (result.Succeeded)
            {
                var token = _jwtTokenService.GenerateToken(model.Username);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

        [HttpPost("signin")]
        public async Task<ActionResult<Client>> Register([FromBody] DtoSignInViewModel model)
        {
            Client client = new Client { UserName = model.Username, Name = model.Name, DocumentNumber = model.DocumentNumber, Email = model.Email, Address = model.Address };
            var result = await _userManager.CreateAsync(client, model.Password);
            if (result.Succeeded)
            {
                var role = new IdentityRole("User");
                var roleExist = await _roleManager.RoleExistsAsync("User");
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(role);
                }
                await _userManager.AddToRoleAsync(client, "User");
            }
            return Ok(result);
        }
    }
}
