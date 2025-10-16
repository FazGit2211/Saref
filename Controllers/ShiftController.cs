using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("{id}")]
        public async Task<ActionResult<Shift>> PostShift([FromBody] Shift shift, int id)
        {
            try
            {
                Shift shiftCreated = await shiftService.CreateShift(shift, id);
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
