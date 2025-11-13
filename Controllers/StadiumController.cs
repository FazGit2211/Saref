using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saref.Models.Stadium;
using Saref.Services.StadiumServices;

namespace Saref.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StadiumController : Controller
    {
        private readonly StadiumService _stadiumService;
        public StadiumController(StadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Stadium>>> GetStadiums()
        {
            try
            {
                List<Stadium> stadiumResult = await _stadiumService.GetAllStadiums();
                if (stadiumResult == null || stadiumResult.Count < 0)
                {
                    return NoContent();
                }
                return Ok(stadiumResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewStadium([FromBody] Stadium stadium)
        {
            try
            {
                Stadium stadiumCreated = await _stadiumService.CreateNew(stadium);
                if (stadiumCreated == null)
                {
                    return BadRequest();
                }
                return Ok(stadiumCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Stadium>> GetStadiumById(int id)
        {
            try
            {
                Stadium stadium = await _stadiumService.GetStadiumById(id);
                if (stadium == null)
                {
                    return NoContent();
                }
                return Ok(stadium);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
