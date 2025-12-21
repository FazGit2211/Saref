using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Shift>>> GetShifts()
        {
            List<Shift> shifts = await shiftService.GetAllShift();
            return Ok(shifts);
        }

        [HttpPost]
        public async Task<ActionResult> CreateShift([FromBody] DtoShift shift)
        {
            await shiftService.CreateShift(shift);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateShiftById([FromBody] DtoShift shift,int shiftId,int clientId)
        {
            await shiftService.UpdateShift(shift,shiftId,clientId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            await shiftService.DeleteShift(id);
            return Ok();
        }
    }
}
