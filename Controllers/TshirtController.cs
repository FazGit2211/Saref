using Microsoft.AspNetCore.Mvc;
using Saref.Models.Product;
using Saref.Services.ProductServices.TshirtService;

namespace Saref.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TshirtController : Controller
    {
        private readonly TshirtService _tshirtService;
        public TshirtController(TshirtService tshirtService)
        {
            _tshirtService = tshirtService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateNewTshirt([FromBody] Tshirt tshirt)
        {
            try
            {
                Tshirt tshirtCreated = await _tshirtService.CreateTshirt(tshirt);
                if (tshirtCreated == null)
                {
                    return BadRequest();
                }
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Tshirt>>> GetAllTshirts()
        {
            try
            {
                List<Tshirt> tshirts = await _tshirtService.GetTshirts();
                if (tshirts == null)
                {
                    return BadRequest();
                }
                if (tshirts.Count == 0)
                {
                    return NoContent();
                }
                return Ok(tshirts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
