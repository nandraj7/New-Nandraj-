using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitTrackingController : ControllerBase
    {
        private readonly IVisitTrackingService _visitTrackingService;

        public VisitTrackingController(IVisitTrackingService visitTrackingService)
        {
            _visitTrackingService = visitTrackingService;

        }

        [HttpPost("StartVisitTracking")]
        public async Task<IActionResult> StartVisitTracking(StartVisitTrackingDTO startVisitTracking)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var result = await _visitTrackingService.StartVisitTracking(startVisitTracking, userId).ConfigureAwait(false);


            return Ok(result);
        }

        [HttpPut("StopVisitTracking")]
        public async Task<IActionResult> StopVisitTracking(StopVisitTrackingDTO stopVisitTracking)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var result = await _visitTrackingService.StopVisitTracking(stopVisitTracking, userId).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("VisitTrackingStatus")]
        public async Task<ActionResult<object>> VisitTrackingStatus(int userId, int enquiryId)
        {
            var result = await _visitTrackingService.GetVisitTrackingStatus(userId, enquiryId);

            if (result.StartDateTime.HasValue || result.StopDateTime.HasValue || result.Status.HasValue)
            {
                return Ok(new
                {
                    StartDateTime = result.StartDateTime,
                    StopDateTime = result.StopDateTime,
                    Status = result.Status
                });
            }
            else
            {
                return null;
            }
        }

        [HttpPost("VisitTracking")]
        public async Task<ActionResult<List<VisitStatusDTO>>> VisitTracking([FromBody] VisitTrackingDetailsDTO visitStatus)
        {
            var visitTracking = await _visitTrackingService.GetVisitTrackingStatusAsync(visitStatus).ConfigureAwait(false);
            return Ok(visitTracking);
        }

        [HttpGet("{visitTrackingId}")]
        public async Task<ActionResult<VisitTrackingDTO>> GetVisitTracking(int visitTrackingId)
        {
            var visit = await _visitTrackingService.GetVisitTrackingByIdAsync(visitTrackingId).ConfigureAwait(false);
            if (visit == null)
            {
                return NotFound();
            }
            return Ok(visit);
        }

    }
}
