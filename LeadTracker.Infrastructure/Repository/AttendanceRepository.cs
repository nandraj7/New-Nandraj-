using LeadTracker.API;
using LeadTracker.API.Entities;
using LeadTracker.API.LeadTracker.API.SQL;
using LeadTracker.Core.DTO;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.Repository
{
    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        private readonly LeadTrackerContext _context;
        public AttendanceRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }

        //public Attendance GetLoginAttendance(int userId)
        //{
        //    return _context.Attendances
        //        .FirstOrDefault(la => la.UserId == userId);
        //}

        public Attendance GetLoginAttendance(int userId, DateTime todaysDate)
        {
            return _context.Attendances
                .FirstOrDefault(la => la.UserId == userId &&
                                       la.LoginDate >= todaysDate);
        }

        public void UpdateLoginAttendance(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            _context.SaveChanges();
        }

        public void CreateLoginAttendance(Attendance attendance)
        {
            attendance.IsActive = true;
            attendance.CreatedDate = DateTime.Now;
            attendance.ModifiedDate = DateTime.Now;
            attendance.IsDeleted = false;
            attendance.SentForApproval = false;
            attendance.PunchInStatus = "PunchIn";

            _context.Attendances.Add(attendance);
            _context.SaveChanges();
        }

        public Attendance GetLogoutAttendance(int userId)
        {
            return _context.Attendances
                   .Where(la => la.UserId == userId)
                   .OrderByDescending(la => la.Id)
                   .FirstOrDefault();
        }

        public void UpdateLogoutAttendance(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            _context.SaveChanges();
        }


        public async Task<OrgAttendanceLocation> GetOrgAttendanceLocationByOrgIdAsync(int orgId)
        {
            return await _context.OrgAttendanceLocations
                .FirstOrDefaultAsync(o => o.OrgId == orgId);
        }


        public List<AttendanceDTO> GetspAttendanceAsync(spGetAllAttendanceDTO attendance)
        {
            try
            {
                var defFromDt = DateTime.Now.Date;
                var defToDt = DateTime.Now.Date.AddHours(23).AddMinutes(59);
                attendance.StartDate = attendance.StartDate == DateTime.MinValue ? defFromDt : attendance.StartDate;
                attendance.EndDate = attendance.EndDate == DateTime.MinValue ? defToDt : attendance.EndDate;
                var parameters = new List<SqlParameter>
               {
                   new SqlParameter("@UserId", (object)attendance.UserId ?? DBNull.Value),
                   new SqlParameter("@StartDate", attendance.StartDate),
                   new SqlParameter("@EndDate", attendance.EndDate),
                   new SqlParameter("@Status", attendance.Status),
                   new SqlParameter("@SelfFlag", attendance.SelfFlag),

                   //new SqlParameter("@IsApproved", attendance.IsApproved),

               };
                var result = _context.Set<AttendanceDTO>()
                    .FromSqlRaw("spGetAllAttendance @UserId, @StartDate, @EndDate, @Status, @SelfFlag", parameters.ToArray())
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AttendanceDTO> UpdateAttendanceAsync(spUpdateAttendanceDTO attendance)
        {
            try
            {
                var defFromDt = DateTime.Now.Date;
                var defToDt = DateTime.Now.Date.AddHours(23).AddMinutes(59);
                attendance.StartDate = attendance.StartDate == DateTime.MinValue ? defFromDt : attendance.StartDate;
                attendance.EndDate = attendance.EndDate == DateTime.MinValue ? defToDt : attendance.EndDate;

                var parameters = new List<SqlParameter>
               {
                   new SqlParameter("@EmployeeId", attendance.EmployeeId),
                   new SqlParameter("@StartDate", attendance.StartDate),
                   new SqlParameter("@EndDate", attendance.EndDate),
                   new SqlParameter("@ApprovedBy", attendance.ApprovedBy)
               };

                var result = _context.Set<AttendanceDTO>()
                    .FromSqlRaw("spUpdateAttendance @EmployeeId, @StartDate, @EndDate, @ApprovedBy", parameters.ToArray())
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<int>> GetEmployeeIdByOrgIdAsync(int orgId)
        {
            return await _context.Employees
                .Where(e => e.OrgId == orgId)
                .Select(e => e.Id)
                .ToListAsync();
        }

        public async Task<Attendance> GetAttendanceForUserAndDateAsync(int userId, DateTime date)
        {
            return await _context.Attendances
                .FirstOrDefaultAsync(a => a.UserId == userId && a.LoginDate == date)
                .ConfigureAwait(false);
        }

        public async Task<List<int>> GetUserIdsForDateAsync(DateTime date)
        {
            return await _context.Attendances
                .Where(a => a.LoginDate.HasValue && a.LoginDate.Value.Date == date.Date)
                .Select(a => a.UserId ?? 0) 
                .Distinct()
                .ToListAsync()
                .ConfigureAwait(false);
        }


        public void AddAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }


        public List<spGetMonthlyAttendanceSummaryResponseDTO> GetMonthlyAttendanceSummaryAsync(spGetMonthlyAttendanceSummaryRequestDTO request)
        {
            try
            {
                var defFromDt = DateTime.Now.Date;
                var defToDt = DateTime.Now.Date.AddHours(23).AddMinutes(59);
                request.StartDate = request.StartDate == DateTime.MinValue ? defFromDt : request.StartDate;
                request.EndDate = request.EndDate == DateTime.MinValue ? defToDt : request.EndDate;


                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@UserId", (object)request.UserId ?? DBNull.Value),
            new SqlParameter("@StartDate", request.StartDate),
            new SqlParameter("@EndDate", request.EndDate)
        };

                var result = _context.Set<spGetMonthlyAttendanceSummaryResponseDTO>()
                    .FromSqlRaw("spGetMonthlyAttendanceSummary @UserId, @StartDate, @EndDate", parameters.ToArray())
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }



        public Attendance2DTO UpdateAttendanceRemarkAsync(spAddAbsentRemarkDTO absentRemark)
        {
            try
            {
                var defFromDt = DateTime.MinValue;
                absentRemark.Date = absentRemark.Date == DateTime.MinValue ? defFromDt : absentRemark.Date;

                var parameters = new List<SqlParameter>
                {
                   new SqlParameter("@UserId", absentRemark.UserId),
                   new SqlParameter("@Date", absentRemark.Date),
                   new SqlParameter("@Remark", absentRemark.Remark)
                };

                var result = _context.Set<Attendance2DTO>()
                .FromSqlRaw("EXEC UpdateAttendanceRemark @UserId, @Date, @Remark", parameters.ToArray())
                .AsEnumerable()
                .FirstOrDefault();


                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<AttendanceApproval> GetAttendanceApprovals(List<int> userIds, DateTime startDate, DateTime endDate)
        {
            var attendanceApprovals = _context.AttendanceApprovals
                .Where(a => userIds.Contains((int)a.EmployeeId) &&
                            a.ApprovalDate >= startDate &&
                            a.ApprovalDate < endDate &&
                            a.IsStepCompleted == false)
                .ToList();

            return attendanceApprovals;
        }



        //public List<AttendanceDTO> GetAttendacesByIdAndDate(AttendanceApprovalRequestDTO attendances)
        //{
        //    var startDate = new DateTime(attendances.StartDate.Year, attendances.StartDate.Month, attendances.StartDate.Day);
        //    var endDate = new DateTime(attendances.EndDate.Year, attendances.EndDate.Month, attendances.EndDate.Day).AddDays(1);

        //    var attendanceData = _context.Attendances
        //        .Where(a => attendances.UserIds.Contains(a.UserId.Value) &&
        //                    a.LoginDate >= startDate && a.LoginDate < endDate)
        //        .Select(a => new AttendanceDTO
        //        {
        //            AttendanceId = a.Id,
        //            UserId = a.UserId.Value,
        //            LoginDate = a.LoginDate,
        //            LoginLatitude = a.LoginLatitude,
        //            LoginLongitude = a.LoginLongitude,
        //            LogoutDate = a.LogoutDate,
        //            LogoutLatitude = a.LogoutLatitude,
        //            LogoutLongitude = a.LogoutLongitude,
        //            IsApproved = a.IsApproved,
        //            Status = a.Status,
        //            ApprovedBy = a.ApprovedBy,
        //            IsActive = a.IsActive,
        //            IsDeleted = a.IsDeleted,
        //            CreatedDate = a.CreatedDate,
        //            CreatedBy = a.CreatedBy,
        //            ModifiedDate = a.ModifiedDate,
        //            ModifiedBy = a.ModifiedBy,
        //            Remark = a.Remark
        //        })
        //        .ToList();

        //    return attendanceData;
        //}


        public List<AttendanceDTO> GetAttendacesByIdAndDate(AttendanceApprovalRequestDTO attendances)
        {
            var startDate = new DateTime(attendances.StartDate.Year, attendances.StartDate.Month, attendances.StartDate.Day);
            var endDate = new DateTime(attendances.EndDate.Year, attendances.EndDate.Month, attendances.EndDate.Day).AddDays(1);

            var attendanceData = _context.Attendances
                .Where(a => attendances.UserIds.Contains(a.UserId.Value) &&
                            a.LoginDate >= startDate && a.LoginDate < endDate)
                .Select(a => new AttendanceDTO
                {
                    AttendanceId = a.Id,
                    UserId = a.UserId.Value,
                    LoginDate = a.LoginDate,
                    LoginLatitude = a.LoginLatitude,
                    LoginLongitude = a.LoginLongitude,
                    LogoutDate = a.LogoutDate,
                    LogoutLatitude = a.LogoutLatitude,
                    LogoutLongitude = a.LogoutLongitude,
                    IsApproved = a.IsApproved,
                    Status = a.Status,
                    ApprovedBy = a.ApprovedBy,
                    IsActive = a.IsActive,
                    IsDeleted = a.IsDeleted,
                    CreatedDate = a.CreatedDate,
                    CreatedBy = a.CreatedBy,
                    ModifiedDate = a.ModifiedDate,
                    ModifiedBy = a.ModifiedBy,
                    Remark = a.Remark
                })
                .ToList();

            attendanceData.ForEach(attendance =>
            {
                attendance.SentForApproval = true;
            });


            UpdatetheSentForApproval(attendanceData, attendances);


            return attendanceData;
        }


        public async Task UpdateAttendanceAfterApproval(int attendanceId)
        {
            var attendance = await _context.Attendances.FindAsync(attendanceId);

            if (attendance != null)
            {

                attendance.Status = "PRESENT";
                //attendance.SentForApproval = false;
                attendance.IsApproved = true;


                _context.Attendances.Update(attendance);
                await _context.SaveChangesAsync();
            }


        }


        public async Task UpdateAttendanceAfterRejected(int attendanceId)
        {
            var attendance = await _context.Attendances.FindAsync(attendanceId);

            if (attendance != null)
            {

                attendance.Status = "ABSENT";
                //attendance.SentForApproval = false;
                attendance.IsApproved = true;


                _context.Attendances.Update(attendance);
                await _context.SaveChangesAsync();
            }

            var attendanceApproval = _context.AttendanceApprovals
                                     .Where(a => a.AttendanceId == attendanceId)
                                     .FirstOrDefault();

            if (attendanceApproval != null)
            {
                attendanceApproval.Status = "Rejected";
                attendanceApproval.IsStepCompleted = true;

                _context.AttendanceApprovals.Update(attendanceApproval);
                await _context.SaveChangesAsync();
            }
        }


        public void UpdatetheSentForApproval(List<AttendanceDTO> attendanceData, AttendanceApprovalRequestDTO attendancesDTO)
        {
            var attendanceIdsToUpdate = attendanceData.Select(a => a.AttendanceId).ToList();


            var attendancesToUpdate = _context.Attendances
                .Where(a => attendanceIdsToUpdate.Contains(a.Id))
                .ToList();


            attendancesToUpdate.ForEach(attendance =>
            {
                attendance.SentForApproval = true;
                attendance.Status = "IN PROGRESS";
                attendance.Remark = attendancesDTO.Remark;

            });


            _context.SaveChanges();
        }

        public void NewAttendanceApproval(AttendanceApproval attendance)
        {

            _context.AttendanceApprovals.Add(attendance);
            _context.SaveChanges();
        }


        public List<AttendanceApproval> GetAttendancesForApprovalAsync(int approvedById, int month)
        {
            var attendancesForApproval = _context.AttendanceApprovals
                .Where(a => a.ApproveRequestId == approvedById &&
                            a.IsStepCompleted == false &&
                            a.ApprovalDate != null &&
                            a.ApprovalDate.Value.Month == month)
                .ToList();

            return attendancesForApproval;
        }

        public List<AttendanceApproval> GetInProgressSummaryAsync(int EmplId, DateTime ApprovalDate)
        {
            var attendancesForApproval = _context.AttendanceApprovals
                .Where(a => a.EmployeeId == EmplId &&
                            a.ApprovalDate == ApprovalDate)

                .ToList();

            return attendancesForApproval;
        }

        public List<Attendance> GetLoggedInUsersForTodayAsync()
        {
            DateTime todaysDate = DateTime.Today;

            return _context.Attendances
                .Where(a => a.LoginDate.HasValue && a.LogoutDate == null && a.LoginDate.Value.Date == todaysDate.Date)
                .ToList();

        }
        public async Task<Holiday> IsTodayHolidayAsync(int orgId)
        {
            return await _context.Holidays
                .FirstOrDefaultAsync(h => h.OrgId == orgId && h.Date == DateTime.Today)
                .ConfigureAwait(false);
        }

        public async Task<bool> IsWeekendAsync(string key)
        {
            var weekendConfig = await _context.SystemConfigurations
                .FirstOrDefaultAsync(config => config.KeyDetail == key)
                .ConfigureAwait(false);

            var weekendDay = weekendConfig?.Value;

            if (weekendDay != null)
            {
                return DateTime.Now.DayOfWeek.ToString().Equals(weekendDay, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}
