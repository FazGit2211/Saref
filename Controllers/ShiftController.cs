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
        [HttpPost("{idStadium}")]
        public async Task<ActionResult<Shift>> PostShift([FromBody] Shift shift, int idStadium)
        {
            try
            {
                Shift shiftCreated = await shiftService.CreateShift(shift, idStadium);
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
        [HttpGet("{idStadium}")]
        public async Task<ActionResult<List<Shift>>> GetShiftByIdStadium(int idStadium)
        {
            try
            {
                List<Shift> shifts = await shiftService.GetShiftByStadium(idStadium);
                if (shifts.Count <= 0 || shifts == null)
                {
                    return NoContent();
                }
                return Ok(shifts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
