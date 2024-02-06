using DocuSign.eSign.Model;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : BaseController
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        //[HttpPost("PunchIn")]
        //public async Task<IActionResult> LoginAttendance(LoginAttendanceDTO loginAttendance)
        //{
        //    //var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
        //    var _userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
        //    var result = await _attendanceService.LoginAttendance(loginAttendance, _userId).ConfigureAwait(false);

        //    return Ok(result);
        //}


        [HttpPost("PunchIn")]
        public async Task<IActionResult> LoginAttendance(LoginAttendanceDTO loginAttendance)
        {
            //var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var _userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var result = await _attendanceService.LoginAttendance(loginAttendance, _userId).ConfigureAwait(false);

            if (result == null)
            {
                return BadRequest("You have already logged in and out for today!!!");
            }
            else
            {
                return Ok(result);
            }
        }



        [HttpPut("PunchOut")]
        public async Task<IActionResult> LogoutAttendance(LogoutAttendanceDTO logoutAttendance)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            var logoutDTO = await _attendanceService.LogoutAttendance(logoutAttendance, userId, orgId).ConfigureAwait(false);

            return Ok(logoutDTO);
        }


        [HttpPost("Approved")]
        public async Task<ActionResult<List<AttendanceDTO>>> Approved([FromBody] spGetAllAttendanceDTO attendance)
        {
            var attendanceDTO = await _attendanceService.GetspAttendanceAsync(attendance).ConfigureAwait(false);

            return Ok(attendanceDTO);
        }


        //[HttpPut("AttendanceApproval")]
        //public async Task<ActionResult<List<AttendanceDTO>>> UpdateAttendance([FromBody] spUpdateAttendanceDTO attendance)
        //{
        //    var attendances = await _attendanceService.UpdateAttendancesAsync(attendance).ConfigureAwait(false);

        //    return attendances;
        //}


        //[HttpPost("CheckEmployeesTodaysAttendance")]
        //public async Task<ActionResult<List<AttendanceDTO>>> EmployeesTodaysActivity()
        //{
        //    //var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

        //    var absentEmployeeIds = await _attendanceService.GetAbsentUserIdsForTodayAsync(1).ConfigureAwait(false);

        //    await _attendanceService.UpdatePendingLogoutUserForApproval().ConfigureAwait(false);

        //    await _attendanceService.AddAbsentUserIdsToAttendance(absentEmployeeIds).ConfigureAwait(false);

        //    return Ok();
        //}

        [HttpPost("CheckEmployeesTodaysAttendance")]
        public async Task<ActionResult<List<AttendanceDTO>>> EmployeesTodaysActivity()
        {
            var absentEmployeeIds = await _attendanceService.GetAbsentUserIdsForTodayAsync(1).ConfigureAwait(false);

            var weekendEmployeeIds = await _attendanceService.GetWeekendUserIdsForTodayAsync(1).ConfigureAwait(false);

            await _attendanceService.UpdatePendingLogoutUserForApproval().ConfigureAwait(false);


            if (weekendEmployeeIds.Any())
            {
                await _attendanceService.AddWeekendUserIdsToAttendance(weekendEmployeeIds).ConfigureAwait(false);
            }
            await _attendanceService.AddAbsentUserIdsToAttendance(absentEmployeeIds).ConfigureAwait(false);

            return Ok();
        }

        //[HttpPost("CheckEmployeesTodaysAttendance")]
        //public async Task<ActionResult<List<AttendanceDTO>>> EmployeesTodaysActivity()
        //{
        //    var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);


        //    await _attendanceService.ProcessEmployeesAttendanceForTodayAsync(orgId).ConfigureAwait(false);

        //    return Ok();
        //}


        [HttpPost("monthlySummary")]
        public async Task<ActionResult<List<spGetMonthlyAttendanceSummaryResponseDTO>>> GetMonthlyAttendanceSummary([FromBody] spGetMonthlyAttendanceSummaryRequestDTO request)
        {
            var result = await _attendanceService.GetMonthlyAttendanceSummary(request).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPut("AddAbsentRemark")]
        public async Task<IActionResult> AddAbsentRemarkOfUser(spAddAbsentRemarkDTO absentRemark)
        {
            var absentReason = await _attendanceService.UpdateAttendanceRemark(absentRemark).ConfigureAwait(false);

            return Ok(absentReason);
        }




        [HttpPost("UpdateOrCreateAttendanceApproval")]
        public async Task<ActionResult<List<AttendanceApprovalDTO>>> UpdateOrCreateAttendanceApprovalById(AttendanceApprovalRequestDTO attendanceforApproval)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            //var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            var result = await _attendanceService.UpdateOrCreateAttendanceApprovalAsync(attendanceforApproval, userId).ConfigureAwait(false);

            return Ok(result);
        }


        [HttpGet("GetAttendancesForApprovalByMonth")]
        public async Task<ActionResult<List<AttendanceApproval2DTO>>> GetAttendanceForApprovalByMonth(int month)
        {

            var parentId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);


            var attendances = await _attendanceService.GetAttendanceForApprovalByUserIdAsync(parentId, month).ConfigureAwait(false);

            if (attendances == null)
            {
                return NotFound();
            }

            return Ok(attendances);
        }

        [HttpGet("GetInProgressAttendanceSummary")]

        public async Task<ActionResult<List<InProgressAttendances>>> GetInProgrssAttendance(int EmplId, DateTime ApprovalDate)
        {

            var records = await _attendanceService.GetspParentOfUsersAsync(EmplId, ApprovalDate).ConfigureAwait(false);

            if (records == null)
            {
                return NotFound();
            }

            return Ok(records);

        }

        [HttpGet("PunchInOROutStatus")]
        public async Task<ActionResult<AttendanceDTO>> AttenendanceStatus(int userId)
        {
            string status = await _attendanceService.GetAttenendanceStatus(userId);
            return Ok(status);
        }
    }
}
