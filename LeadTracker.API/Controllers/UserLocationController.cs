using DocuSign.eSign.Model;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLocationController : BaseController
    {
        private readonly IUserLocationService _userLocationService;
        private readonly INotificationService _notificationService;
        public UserLocationController(IUserLocationService userLocationService, INotificationService notificationService)
        {
            _userLocationService = userLocationService;
            _notificationService = notificationService;
        }

        [HttpPost("UpdateOrCreateUserLocation")]
        public async Task<IActionResult> UpdateOrCreateUserLocation(UserLocationDTO userLocation) 
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            try
            {

                var result = await _userLocationService.UpdateOrCreateUserLocation(userLocation, userId, orgId).ConfigureAwait(false);
            }
            catch (Exception)
            {

            }
            var notifications = await _notificationService.GetNotificationAsync(new NewNotificationDTO()
            {
                UserId = userId,
                StartDate = DateTime.Now.Date.AddDays(-30),
                EndDate = DateTime.Now.Date.AddDays(1),
                Status = "Pending",
            });

            return Ok(notifications);
        }


        [HttpGet("GetAllUserLocationByOrg")]
        public async Task<ActionResult<UserLocationResponseDTO>> GetAllUserLocationByOrg()
        {

            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);

            var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            var userLocations = await _userLocationService.GetAllUserLocationAsync(orgId, userId);

            return Ok(userLocations);
        }


        //[HttpGet("GetUserRoutePath")]
        //public async Task<ActionResult<UserLocationResponseDTO>> GetUserLocationPathByIdAndDate(RoutePathRequestDTO pathRequest)
        //{

        //    var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

        //    var userLocations = await _userLocationService.GetUserPathAsync(pathRequest,orgId);

        //    return Ok(userLocations);
        //}

        [HttpGet("GetUserRoutePath")]
        public async Task<ActionResult<RoutePathResponseDTO>> GetUserLocationPathByIdAndDate([FromQuery] RoutePathRequestDTO pathRequest)
        {
            //var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            var userLocations = await _userLocationService.GetUserPathAsync(pathRequest);

            return Ok(userLocations);
        }


    }
}