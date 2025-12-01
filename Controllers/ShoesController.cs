using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Saref.Models.Product;
using Saref.Services.ProductServices.ShoesService;

namespace Saref.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ShoesController : Controller
    {
        private readonly ShoesService _shoesService;
        public ShoesController(ShoesService shoesService)
        {
            _shoesService = shoesService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewShoes([FromBody] Shoes shoes)
        {
            try
            {
                Shoes shoesCreated = await _shoesService.CreateShoes(shoes);
                if (shoesCreated == null)
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Shoes>>> GetAllShoes()
        {
            try
            {
                List<Shoes> shoes = await _shoesService.GetShoes();
                if (shoes == null)
                {
                    return NotFound();
                }
                if (shoes.Count == 0)
                {
                    return NoContent();
                }
                return Ok(shoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
