using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saref.Models.Dtos;
using Saref.Models.Stadium;
using Saref.Services.StadiumServices;

namespace Saref.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
    public class StadiumController : Controller
    {
        private readonly StadiumService _stadiumService;
        public StadiumController(StadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Stadium>>> GetStadiums()
        {
            List<Stadium> stadiumResult = await _stadiumService.GetAllStadiums();
            return Ok(stadiumResult);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewStadium([FromBody] DtoStadium dtoStadium)
        {
            await _stadiumService.CreateNew(dtoStadium);
            return Created();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Stadium>> GetStadiumById(int id)
        {
            Stadium stadium = await _stadiumService.GetStadiumById(id);
            return Ok(stadium);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStadiumById([FromBody] DtoStadium dtoStadium, int id)
        {
            await _stadiumService.UpdateStadium(dtoStadium, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStadiumById(int id)
        {
            await _stadiumService.DeleteStadium(id);
            return Ok();
        }
    }
}
