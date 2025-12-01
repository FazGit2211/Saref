using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Saref.Models.Dtos;
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Stadium>>> GetStadiums()
        {
            try
            {
                List<Stadium> stadiumResult = await _stadiumService.GetAllStadiums();                
                return Ok(stadiumResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewStadium([FromBody] DtoStadium dtoStadium)
        {
            try
            {
                Stadium stadiumCreated = await _stadiumService.CreateNew(dtoStadium);
                return Created();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpGet(Name = "{id}")]
        public async Task<ActionResult<Stadium>> GetStadiumById(int id)
        {
            try
            {
                Stadium stadium = await _stadiumService.GetStadiumById(id);                
                return Ok(stadium);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut(Name = "{id}")]
        public async Task<ActionResult<Stadium>> UpdateStadiumById([FromBody] DtoStadium dtoStadium, int id)
        {
            try {
                Stadium stadiumUpdated = await _stadiumService.UpdateStadium(dtoStadium, id);
                return Ok(stadiumUpdated);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete(Name = "{id}")]
        public async Task<ActionResult<Stadium>> DeleteStadiumById(int id)
        {
            try
            {
                Stadium stadiumDeleted = await _stadiumService.DeleteStadium(id);
                return Ok(stadiumDeleted);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
