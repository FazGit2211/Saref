using Microsoft.AspNetCore.Mvc;
using Saref.Models.Dtos;
using Saref.Models.Shift;
using Saref.Services.ShiftServices;

namespace Saref.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : Controller
    {
        private readonly ShiftService shiftService;
        public ShiftController(ShiftService shiftService)
        {
            this.shiftService = shiftService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Shift>>> GetShifts()
        {
            try
            {
                List<Shift> shifts = await shiftService.GetAllShift();
                if (shifts.Count < 0)
                {
                    return NoContent();
                }
                return shifts;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("{idStadium}/{idClient}")]
        public async Task<ActionResult<DtoShift>> PostShift([FromBody] Shift shift, int idStadium, int idClient)
        {
            try
            {
                DtoShift shiftCreated = await shiftService.CreateShift(shift, idStadium, idClient);
                if (shiftCreated.Equals(null))
                {
                    return BadRequest();
                }
                return Ok(shiftCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
