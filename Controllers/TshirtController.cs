using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Saref.Models.Dtos;
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
        public async Task<ActionResult> CreateNewTshirt([FromBody] DtoProduct dtoProduct)
        {
            try
            {
                Tshirt tshirtCreated = await _tshirtService.CreateTshirt(dtoProduct);
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Tshirt>>> GetAllTshirts()
        {
            try
            {
                List<Tshirt> tshirts = await _tshirtService.GetTshirts();
                if (tshirts == null)
                {
                    return NotFound();
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

        [HttpPut(Name = "{id}")]
        public async Task<ActionResult<Tshirt>> UpdateTshirtById([FromBody] DtoProduct dtoProduct,int id) {
            try
            {
                Tshirt tshirtUpdated = await _tshirtService.UpdateTshirt(dtoProduct, id);
                return Ok(tshirtUpdated);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(Name = "{id}")]
        public async Task<ActionResult<Tshirt>> DeleteTshirtById(int id) {
            try
            {
                Tshirt tshirtDeleted = await _tshirtService.DeleteTshirt(id);
                return Ok(tshirtDeleted);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
