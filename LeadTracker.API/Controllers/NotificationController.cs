using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseController
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpPost("NewNotification")]
        public async Task<ActionResult> SaveProject(NotificationDTO notification)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);

            await _notificationService.CreateNotification(notification, userId).ConfigureAwait(false);

            return Ok(notification);
        }

        [HttpPost("GetNotification")]
        public async Task<ActionResult<NotificationDTO>> GetNotification(NewNotificationDTO notification)
        {
            var notificationDto = await _notificationService.GetNotificationAsync(notification).ConfigureAwait(false);

            return Ok(notificationDto);
        }



        [HttpPut("UpdateNotificationStatus")]
        public async Task<IActionResult> UpdateNotificationStatus(UpdateNotificationDTO notification)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var updatedNotification = await _notificationService.UpdateNotificationStatusAsync(notification, userId).ConfigureAwait(false);

            if (updatedNotification != null)
            {
                return Ok(updatedNotification);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("SendNotification")]
        public async Task<IActionResult> SendNotification(SendNotificationDTO notification)
        {
            if (notification != null && notification.UserId != null && notification.UserId.Any())
            {
                var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);

                var result = await _notificationService.SendNotificationAsync(notification, userId).ConfigureAwait(false);
                return Ok(result);
            }
            else
            {
                return BadRequest("Invalid input data.");
            }
        }


        [HttpGet("TrackEmployee")]
        public async Task<ActionResult<List<NotificationDTO>>> TrackEmployeeCurrentLocation()
        {
            var presentEmployeeIds = await _notificationService.GetPresentUserIdsForTodayAsync().ConfigureAwait(false);

            await _notificationService.SendNotificationToHrAndParentAsync(presentEmployeeIds).ConfigureAwait(false);


            return Ok();
        }
    }

}
