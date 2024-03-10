using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;
        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;

        }

        [HttpPost("CreateHoliday")]
        public async Task<ActionResult> CreateHoliday(HolidayDTO holiday)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);
            await _holidayService.CreateNewHoliday(holiday, orgId, userId).ConfigureAwait(false);
            return Ok(holiday);
        }

        [HttpGet("GetAllHoliday")]
        public async Task<ActionResult<IEnumerable<HolidayDTO>>> GetAllHoliday()
        {
            var holiday = await _holidayService.GetAllHolidayAsync().ConfigureAwait(false);
            return Ok(holiday);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayDTO>> GetHoliday(int id)
        {
            var holiday = await _holidayService.GetHodidayByIdAsync(id).ConfigureAwait(false);
            if (holiday == null)
            {
                return null;
            }
            return Ok(holiday);
        }

        [HttpPut("UpdateHoliday/{id}")]
        public async Task<IActionResult> UpdateHoliday(int id, NewHolidayDTO holiday)
        {
            var holidayDTO = await _holidayService.UpdateHolidayAsync(id, holiday).ConfigureAwait(false);
            if (holidayDTO != null)
            {
                return Ok(holidayDTO);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteHoliday/{id}")]
        public async Task<IActionResult> DeleteHoliday(int id)
        {
            await _holidayService.DeleteHolidayAsync(id).ConfigureAwait(false);
            return Ok();
        }

    }

}
