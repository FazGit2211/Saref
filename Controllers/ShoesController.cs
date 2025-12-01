using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Saref.Models.Dtos;
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
        public async Task<ActionResult> CreateNewShoes([FromBody] DtoProduct dtoProduct)
        {
            try
            {
                Shoes shoesCreated = await _shoesService.CreateShoes(dtoProduct);
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

        [HttpPut(Name ="{id}")]
        public async Task<ActionResult<Shoes>> UpdateShoesById([FromBody] DtoProduct dtoProduct, int id) {
            try
            {
                Shoes shoesUpdated = await _shoesService.UpdateShoes(dtoProduct, id);
                return Ok(shoesUpdated);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(Name = "{id}")]
        public async Task<ActionResult<Shoes>> DeleteById(int id) {
            try {
                Shoes shoesDeleted = await _shoesService.DeleteShoes(id);
                return Ok(shoesDeleted);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
