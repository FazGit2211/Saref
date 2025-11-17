using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saref.Models.Dtos;
using Saref.Models.Shift;
using Saref.Services.ShiftServices;

namespace Saref.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : Controller
    {
        private readonly ShiftService shiftService;
        public ShiftController(ShiftService shiftService)
        {
            this.shiftService = shiftService;
        }

        [AllowAnonymous]
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
        [HttpPost]
        public async Task<ActionResult<DtoShift>> PostShift([FromBody] Shift shift)
        {
            try
            {
                DtoShift shiftCreated = await shiftService.CreateShift(shift);
                if (shiftCreated == null)
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
