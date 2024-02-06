using LeadTracker.API;
using LeadTracker.API.Entities;
using LeadTracker.API.LeadTracker.API.SQL;
using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        Attendance GetLoginAttendance(int userId, DateTime todaysDate);
        void UpdateLoginAttendance(Attendance attendance);
        void CreateLoginAttendance(Attendance attendance);
        Attendance GetLogoutAttendance(int userId);
        void UpdateLogoutAttendance(Attendance attendance);

        Task<OrgAttendanceLocation> GetOrgAttendanceLocationByOrgIdAsync(int orgId);

        List<AttendanceDTO> GetspAttendanceAsync(spGetAllAttendanceDTO attendance);

        List<AttendanceDTO> UpdateAttendanceAsync(spUpdateAttendanceDTO attendance);

        Task<List<int>> GetEmployeeIdByOrgIdAsync(int orgId);

        Task<List<int>> GetUserIdsForDateAsync(DateTime date);

        Task<Attendance> GetAttendanceForUserAndDateAsync(int userId, DateTime date);

        void AddAttendance(Attendance attendance);

        Task SaveChangesAsync();

        List<spGetMonthlyAttendanceSummaryResponseDTO> GetMonthlyAttendanceSummaryAsync(spGetMonthlyAttendanceSummaryRequestDTO request);

        Attendance2DTO UpdateAttendanceRemarkAsync(spAddAbsentRemarkDTO absentRemark);

        //List<AttendanceApproval> GetAttendanceApprovals(AttendanceApprovalRequestDTO attendances);

        List<AttendanceApproval> GetAttendanceApprovals(List<int> userIds, DateTime startDate, DateTime endDate);

        List<AttendanceDTO> GetAttendacesByIdAndDate(AttendanceApprovalRequestDTO attendances);

        Task UpdateAttendanceAfterApproval(int attendanceId);

        Task UpdateAttendanceAfterRejected(int attendanceId);

        void NewAttendanceApproval(AttendanceApproval attendance);

        //List<AttendanceApproval> GetAttendancesForApprovalAsync(int approvedById);

        List<AttendanceApproval> GetAttendancesForApprovalAsync(int approvedById, int month);

        void UpdatetheSentForApproval(List<AttendanceDTO> attendanceData, AttendanceApprovalRequestDTO attendancesDTO);

        List<AttendanceApproval> GetInProgressSummaryAsync(int EmplId, DateTime ApprovalDate);

        List<Attendance> GetLoggedInUsersForTodayAsync();

        Task<Holiday> IsTodayHolidayAsync(int orgId);
        Task<bool> IsWeekendAsync(string key);
    }
}
