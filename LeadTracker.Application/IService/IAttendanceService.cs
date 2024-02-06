using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LeadTracker.BusinessLayer.IService
{
    public interface IAttendanceService
    {
        Task<LoginAttendanceDTO> LoginAttendance(LoginAttendanceDTO loginAttendance, int userId);
        Task<LogoutAttendanceDTO> LogoutAttendance(LogoutAttendanceDTO logoutAttendance, int userId, int orgId);

        Task<List<AttendanceDTO>> GetspAttendanceAsync(spGetAllAttendanceDTO attendance);

        Task<List<AttendanceDTO>> UpdateAttendancesAsync(spUpdateAttendanceDTO attendance);

        Task<List<int>> GetEmployeeIdsByOrgIdAsync(int orgId);

        Task<List<int>> GetAbsentUserIdsForTodayAsync(int orgId);
        Task<List<int>> GetWeekendUserIdsForTodayAsync(int orgId);
        Task<List<int>> GetHolidayUserIdsForTodayAsync(int orgId);

        Task AddAbsentUserIdsToAttendance(List<int> absentUserIds);
        Task AddWeekendUserIdsToAttendance(List<int> weekendUserIds);
        Task AddHolidayUserIdsToAttendance(List<int> holidayUserIds, int orgId);

        //Task ProcessEmployeesAttendanceForTodayAsync(int orgId);
        Task<List<spGetMonthlyAttendanceSummaryResponseDTO>> GetMonthlyAttendanceSummary(spGetMonthlyAttendanceSummaryRequestDTO request);

        Task<Attendance2DTO> UpdateAttendanceRemark(spAddAbsentRemarkDTO absentRemark);

        Task<List<AttendanceApprovalDTO>> UpdateOrCreateAttendanceApprovalAsync(AttendanceApprovalRequestDTO attendances, int userId);

        //Task<List<AttendanceApproval2DTO>> GetAttendanceForApprovalByUserIdAsync(int parentId);

        Task<List<AttendanceApproval2DTO>> GetAttendanceForApprovalByUserIdAsync(int parentId, int month);

        Task<InProgressDataDTO> GetspParentOfUsersAsync(int EmplId, DateTime ApprovalDate);

        Task UpdatePendingLogoutUserForApproval();

        Task<string> GetAttenendanceStatus(int userId);
    }
}
