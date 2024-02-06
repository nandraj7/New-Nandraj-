using AutoMapper;
using LeadTracker.API;
using LeadTracker.API.LeadTracker.API.SQL;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendancerepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mappingProfile;
        private readonly INotificationService _notificationService;
        private readonly IEmployeeService _employeeService;
        private readonly IRoleRepository _roleRepository;
        private readonly IHolidayRepository _holidayRepository;


        public AttendanceService(IHolidayRepository holidayRepository, IMapper mappingProfile, IAttendanceRepository attendanceService, IEmployeeRepository employeeRepository, INotificationService notificationService, IEmployeeService employeeService, IRoleRepository roleRepository)
        {
            _mappingProfile = mappingProfile;
            _attendancerepository = attendanceService;
            _employeeRepository = employeeRepository;
            _notificationService = notificationService;
            _employeeService = employeeService;
            _roleRepository = roleRepository;
            _holidayRepository = holidayRepository;

        }

        //public async Task<LoginAttendanceDTO> LoginAttendance(LoginAttendanceDTO loginAttendance, int userId)
        //{
        //    var existingLoginAttendance = _attendancerepository.GetLoginAttendance(userId);

        //    if (existingLoginAttendance != null && existingLoginAttendance.LoginDate.Value.Date == DateTime.Now.Date)
        //    {
        //        existingLoginAttendance.LoginLatitude = loginAttendance.LoginLatitude;
        //        existingLoginAttendance.LoginLongitude = loginAttendance.LoginLongitude;
        //        existingLoginAttendance.LoginDate = DateTime.Now;
        //        _attendancerepository.UpdateLoginAttendance(existingLoginAttendance);
        //    }
        //    else
        //    {
        //        Attendance attendances = new Attendance
        //        {
        //            UserId = userId,
        //            LoginLatitude = loginAttendance.LoginLatitude,
        //            LoginLongitude = loginAttendance.LoginLongitude,
        //            LoginDate = DateTime.Now,
        //            IsApproved = false,
        //            SentForApproval = false
        //        };
        //        _attendancerepository.CreateLoginAttendance(attendances);
        //    }
        //    return loginAttendance;
        //}


        public async Task<LoginAttendanceDTO> LoginAttendance(LoginAttendanceDTO loginAttendance, int userId)
        {
            var todaysDate = DateTime.Today;


            var existingLoginAttendance = _attendancerepository.GetLoginAttendance(userId, todaysDate);

            if (existingLoginAttendance != null && existingLoginAttendance.LoginDate.Value.Date == DateTime.Now.Date)
            {
                //existingLoginAttendance.LoginLatitude = loginAttendance.LoginLatitude;
                //existingLoginAttendance.LoginLongitude = loginAttendance.LoginLongitude;
                //existingLoginAttendance.LoginDate = DateTime.Now;
                //_attendancerepository.UpdateLoginAttendance(existingLoginAttendance);

                return null;
            }
            else
            {
                Attendance attendances = new Attendance
                {
                    UserId = userId,
                    LoginLatitude = loginAttendance.LoginLatitude,
                    LoginLongitude = loginAttendance.LoginLongitude,
                    LoginDate = DateTime.Now,
                    PunchInStatus = "PunchIn",
                    IsApproved = false,
                    SentForApproval = false
                };
                _attendancerepository.CreateLoginAttendance(attendances);

                return loginAttendance;
            }
        }



        public async Task<LogoutAttendanceDTO> LogoutAttendance(LogoutAttendanceDTO logoutAttendance, int userId, int orgId)
        {
            var existingLogoutAttendance = _attendancerepository.GetLogoutAttendance(userId);

            if (existingLogoutAttendance != null && existingLogoutAttendance.LoginDate != null)
            {
                existingLogoutAttendance.LogoutLatitude = logoutAttendance.LogoutLatitude;
                existingLogoutAttendance.LogoutLongitude = logoutAttendance.LogoutLongitude;
                existingLogoutAttendance.LogoutDate = DateTime.Now;
                existingLogoutAttendance.PunchInStatus = "PunchOut";


                var orgAttendanceLocation = await _attendancerepository.GetOrgAttendanceLocationByOrgIdAsync(orgId);

                bool isLocationMatch = existingLogoutAttendance.LoginLatitude == logoutAttendance.LogoutLatitude &&
                                       existingLogoutAttendance.LoginLongitude == logoutAttendance.LogoutLongitude &&
                                       orgAttendanceLocation.Latitude == logoutAttendance.LogoutLatitude &&
                                       orgAttendanceLocation.Longitude == logoutAttendance.LogoutLongitude;



                TimeSpan timeDifference = existingLogoutAttendance.LogoutDate.Value - existingLogoutAttendance.LoginDate.Value;


                bool isEightHoursDifference = timeDifference.TotalHours >= 8;


                existingLogoutAttendance.Status = isLocationMatch && isEightHoursDifference ? "PRESENT" : "PENDING APPROVAL";

                _attendancerepository.UpdateLogoutAttendance(existingLogoutAttendance);
            }

            return new LogoutAttendanceDTO();
        }


        public async Task<List<AttendanceDTO>> GetspAttendanceAsync(spGetAllAttendanceDTO attendance)
        {
            try
            {
                var spAttendance = _attendancerepository.GetspAttendanceAsync(attendance);

                if (spAttendance == null)
                {
                    return null;
                }

                var spAttendanceDTO = _mappingProfile.Map<List<AttendanceDTO>>(spAttendance).ToList();

                return spAttendanceDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<AttendanceDTO>> UpdateAttendancesAsync(spUpdateAttendanceDTO attendance)
        {
            try
            {
                var attendances = _attendancerepository.UpdateAttendanceAsync(attendance);

                if (attendances == null)
                {
                    return null;
                }
                var attendanceDTO = _mappingProfile.Map<List<AttendanceDTO>>(attendances).ToList();

                return attendanceDTO;
            }
            catch (Exception ex)
            {

                return null;
            }
        }



        public async Task<List<int>> GetEmployeeIdsByOrgIdAsync(int orgId)
        {
            return await _attendancerepository.GetEmployeeIdByOrgIdAsync(orgId);
        }

        public async Task<List<int>> GetAbsentUserIdsForTodayAsync(int orgId)
        {
            DateTime today = DateTime.Today;

            var allEmployeeIds = await GetEmployeeIdsByOrgIdAsync(orgId);

            var presentUserIds = await _attendancerepository.GetUserIdsForDateAsync(today);

            var absentUserIds = allEmployeeIds.Except(presentUserIds).ToList();

            return absentUserIds;
        }

        public async Task<List<int>> GetWeekendUserIdsForTodayAsync(int orgId)
        {
            DateTime today = DateTime.Today;

            var allEmployeeIds = await GetEmployeeIdsByOrgIdAsync(orgId);

            var presentUserIds = await _attendancerepository.GetUserIdsForDateAsync(today);

            var absentUserIds = allEmployeeIds.Except(presentUserIds).ToList();

            return absentUserIds;
        }

        public async Task<List<int>> GetHolidayUserIdsForTodayAsync(int orgId)
        {
            DateTime today = DateTime.Today;

            var allEmployeeIds = await GetEmployeeIdsByOrgIdAsync(orgId);

            var presentUserIds = await _attendancerepository.GetUserIdsForDateAsync(today);

            var absentUserIds = allEmployeeIds.Except(presentUserIds).ToList();

            return absentUserIds;
        }

        public async Task AddAbsentUserIdsToAttendance(List<int> absentUserIds)
        {
            DateTime today = DateTime.Today;


            foreach (var userId in absentUserIds)
            {
                var existingAttendance = await _attendancerepository.GetAttendanceForUserAndDateAsync(userId, today);

                if (existingAttendance == null)
                {

                    var newAttendance = new Attendance
                    {
                        UserId = userId,
                        LoginDate = today,
                        Status = "ABSENT",
                        IsActive = true,
                        CreatedDate= today,
                        ModifiedDate= today
                    };


                    _attendancerepository.AddAttendance(newAttendance);
                }
            }


            await _attendancerepository.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task AddWeekendUserIdsToAttendance(List<int> weekendUserIds)
        {
            string weekendKey = "Weekend";

            var isWeekend = await _attendancerepository.IsWeekendAsync(weekendKey).ConfigureAwait(false);

            if (isWeekend)
            {
                DateTime today = DateTime.Today;

                foreach (var userId in weekendUserIds)
                {
                    var existingAttendance = await _attendancerepository.GetAttendanceForUserAndDateAsync(userId, today).ConfigureAwait(false);

                    if (existingAttendance == null)
                    {
                        var newAttendance = new Attendance
                        {
                            UserId = userId,
                            LoginDate = today,
                            Status = "WEEKEND",
                            IsActive = true,
                            CreatedDate = today,
                            ModifiedDate = today
                        };

                        _attendancerepository.AddAttendance(newAttendance);
                    }
                }

                await _attendancerepository.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task AddHolidayUserIdsToAttendance(List<int> holidayUserIds, int orgId)
        {
            // var orgId = 1;

            var isHoliday = await _attendancerepository.IsTodayHolidayAsync(orgId).ConfigureAwait(false);

            if (isHoliday != null)
            {
                DateTime currentDate = DateTime.Today;

                foreach (var userId in holidayUserIds)
                {
                    var existingAttendance = await _attendancerepository.GetAttendanceForUserAndDateAsync(userId, currentDate).ConfigureAwait(false);

                    if (existingAttendance == null)
                    {
                        var newAttendance = new Attendance
                        {
                            UserId = userId,
                            LoginDate = currentDate,
                            Status = "HOLIDAY",
                            IsActive = true,
                            CreatedDate = currentDate,
                            ModifiedDate = currentDate
                        };

                        _attendancerepository.AddAttendance(newAttendance);
                    }
                }

                await _attendancerepository.SaveChangesAsync().ConfigureAwait(false);
            }
        }


        public async Task<List<spGetMonthlyAttendanceSummaryResponseDTO>> GetMonthlyAttendanceSummary(spGetMonthlyAttendanceSummaryRequestDTO request)
        {
            try
            {
                var spRequest = _attendancerepository.GetMonthlyAttendanceSummaryAsync(request);

                if (spRequest == null)
                {
                    return null;
                }

                var spRequestDto = _mappingProfile.Map<List<spGetMonthlyAttendanceSummaryResponseDTO>>(spRequest).ToList();

                return spRequestDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Attendance2DTO> UpdateAttendanceRemark(spAddAbsentRemarkDTO absentRemark)
        {
            try
            {
                var result = _attendancerepository.UpdateAttendanceRemarkAsync(absentRemark);

                if (result == null)
                {
                    return null;
                }
                var attendanceDTO = _mappingProfile.Map<Attendance2DTO>(result);

                return attendanceDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<AttendanceApprovalDTO>> UpdateOrCreateAttendanceApprovalAsync(AttendanceApprovalRequestDTO attendances, int userId)
        {
            var startDate = new DateTime(attendances.StartDate.Year, attendances.StartDate.Month, attendances.StartDate.Day);
            var endDate = new DateTime(attendances.EndDate.Year, attendances.EndDate.Month, attendances.EndDate.Day).AddDays(1);

            var existingAttendanceApprovals = _attendancerepository.GetAttendanceApprovals(attendances.UserIds, startDate, endDate);

            var parentIdOfParent = _employeeRepository.GetParentUserIdByEmployeeId(userId);


            if (existingAttendanceApprovals != null && existingAttendanceApprovals.Any())
            {
                foreach (var existingAttendance in existingAttendanceApprovals)
                {
                    existingAttendance.Remark = attendances.Remark;
                    existingAttendance.IsStepCompleted = true;
                    existingAttendance.Status = attendances.Status ?? "Pending";


                    var emplParentName = await _employeeRepository.GetEmployeeNameByIdAsync(userId);
                    var emplName = await _employeeRepository.GetEmployeeNameByIdAsync(existingAttendance.EmployeeId ?? 0);

                   

                    string textEmpl = $"Hello {emplName}, Your Attendance for {existingAttendance.ApprovalDate?.ToString("dd MMM yyyy")} is {existingAttendance.Status} by {emplParentName}";
                    string ModulesName = "Attendance Status";

                    await _notificationService.CreateNotificationForUser(existingAttendance.EmployeeId ?? 0, textEmpl, ModulesName, userId);
                }
            }


            var parentUserIds = _employeeRepository.GetParentUserIdsByUserIds(attendances);


            var newAttendancesForApproval = _attendancerepository.GetAttendacesByIdAndDate(attendances);


            var newAttendances = new List<AttendanceApproval>();

            if (existingAttendanceApprovals != null && existingAttendanceApprovals.Any())
            {
                foreach (var existingAttendance in existingAttendanceApprovals)
                {
                    if (attendances.Status == "Rejected")
                    {
                        await _attendancerepository.UpdateAttendanceAfterRejected(existingAttendance.AttendanceId ?? 0);
                    }


                    else if (existingAttendance.ApproveRequestId == 2)
                    {

                        var attendanceIdsToUpdate = existingAttendanceApprovals
                            .Where(a => a.ApproveRequestId == 2)
                            .Select(a => a.AttendanceId)
                            .ToList();


                        foreach (var attendanceId in attendanceIdsToUpdate)
                        {
                            await _attendancerepository.UpdateAttendanceAfterApproval(attendanceId ?? 0);
                        }
                    }
                    else

                    {
                        var attendance = new AttendanceApproval
                        {
                            AttendanceId = existingAttendance.AttendanceId,
                            EmployeeId = existingAttendance.EmployeeId,
                            ApproveRequestId = parentIdOfParent,
                            Status = "Pending",
                            //Remark = attendances.Remark,
                            ApprovalDate = existingAttendance.ApprovalDate,
                            CreatedDate = existingAttendance.CreatedDate,
                            CreatedBy = existingAttendance.CreatedBy,
                            ModifiedBy = userId,
                            ModifiedDate = DateTime.Now,
                            IsStepCompleted = false,
                            IsActive = true,
                            IsDeleted = false,
                           
                        };

                        newAttendances.Add(attendance);
                    }
                }

                if (newAttendances != null && newAttendances.Any())
                {
                    var countOfRequest = newAttendances.Count;
                    var requestParentName = await _employeeRepository.GetEmployeeNameByIdAsync(parentIdOfParent ?? 0);

                    string textParent = $"Hello {requestParentName}, You have {countOfRequest} new Attendance Requests for Approval ";
                    string ModulesName = "Attendance Status";

                    await _notificationService.CreateNotificationForUser(parentIdOfParent ?? 0, textParent, ModulesName, userId);


                }

            }
            else if (newAttendancesForApproval != null && newAttendancesForApproval.Any())
            {
                foreach (var newAttendanceForApproval in newAttendancesForApproval)
                {



                    var parentId = parentUserIds.FirstOrDefault();

                    var newAttendance = new AttendanceApproval
                    {
                        EmployeeId = newAttendanceForApproval.UserId,
                        AttendanceId = newAttendanceForApproval.AttendanceId,
                        ApproveRequestId = parentId,
                        Status = "Pending",
                        //Remark = attendances.Remark,
                        ApprovalDate = newAttendanceForApproval.LoginDate,
                        CreatedBy = userId,
                        ModifiedBy = userId,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IsStepCompleted = false,
                        IsActive = true,
                        IsDeleted = false,
                        
                    };

                    newAttendances.Add(newAttendance);
                }
                var parentName = await _employeeRepository.GetEmployeeNameByIdAsync(userId);
                var assignedToName = await _employeeRepository.GetEmployeeNameByIdAsync(parentIdOfParent ?? 0);


                int count = newAttendancesForApproval.Count;
                string ModuleName = "Attendance Approval";
                string Text = $"Hello {assignedToName}, you have {count} new attendance request of {parentName} for approval";

                await _notificationService.CreateNotificationForUser(parentIdOfParent ?? 0, Text, ModuleName, userId);
            }

            foreach (var attendance in newAttendances)
            {
                _attendancerepository.NewAttendanceApproval(attendance);
            }

            return _mappingProfile.Map<List<AttendanceApprovalDTO>>(newAttendances);
        }


        //public async Task<List<AttendanceApprovalDTO>> UpdateOrCreateAttendanceApprovalAsync(AttendanceApprovalRequestDTO attendances, int userId)
        //{
        //    var startDate = new DateTime(attendances.StartDate.Year, attendances.StartDate.Month, attendances.StartDate.Day);
        //    var endDate = new DateTime(attendances.EndDate.Year, attendances.EndDate.Month, attendances.EndDate.Day).AddDays(1);

        //    var existingAttendanceApprovals = _attendancerepository.GetAttendanceApprovals(attendances.UserIds, startDate, endDate);

        //    if (existingAttendanceApprovals != null && existingAttendanceApprovals.Any())
        //    {
        //        foreach (var existingAttendance in existingAttendanceApprovals)
        //        {
        //            existingAttendance.IsStepCompleted = true;
        //            existingAttendance.Status = attendances.Status ?? "Pending";
        //        }
        //    }

        //    var parentUserIds = _employeeRepository.GetParentUserIdsByUserIds(attendances);

        //    var parentIdOfParent = _employeeRepository.GetParentUserIdByEmployeeId(userId);

        //    var newAttendancesForApproval = _attendancerepository.GetAttendacesByIdAndDate(attendances);

        //    var newAttendances = new List<AttendanceApproval>();

        //    if (existingAttendanceApprovals != null && existingAttendanceApprovals.Any())
        //    {
        //        foreach (var existingAttendance in existingAttendanceApprovals)
        //        {
        //            var attendance = new AttendanceApproval
        //            {
        //                AttendanceId = existingAttendance.AttendanceId,
        //                EmployeeId = existingAttendance.EmployeeId,
        //                ApproveRequestId = parentIdOfParent,
        //                Status = "Pending",
        //                ApprovalDate = existingAttendance.ApprovalDate,
        //                CreatedDate = existingAttendance.CreatedDate,
        //                CreatedBy = existingAttendance.CreatedBy,
        //                ModifiedBy = userId,
        //                ModifiedDate = DateTime.Now,
        //                IsStepCompleted = false,
        //                IsActive = true,
        //                IsDeleted = false
        //            };

        //            newAttendances.Add(attendance);
        //        }
        //    }
        //    else if (newAttendancesForApproval != null && newAttendancesForApproval.Any())
        //    {
        //        foreach (var newAttendanceForApproval in newAttendancesForApproval)
        //        {

        //            var parentId = parentUserIds.FirstOrDefault();

        //            var newAttendance = new AttendanceApproval
        //            {
        //                EmployeeId = newAttendanceForApproval.UserId,
        //                AttendanceId = newAttendanceForApproval.AttendanceId,
        //                ApproveRequestId = parentId,
        //                Status = "Pending",
        //                ApprovalDate = newAttendanceForApproval.LoginDate,
        //                CreatedBy = userId,
        //                ModifiedBy = userId,
        //                CreatedDate = DateTime.Now,
        //                ModifiedDate = DateTime.Now,
        //                IsStepCompleted = false,
        //                IsActive = true,
        //                IsDeleted = false
        //            };

        //            newAttendances.Add(newAttendance);
        //        }
        //    }

        //    foreach (var attendance in newAttendances)
        //    {
        //        _attendancerepository.NewAttendanceApproval(attendance);
        //    }

        //    return _mappingProfile.Map<List<AttendanceApprovalDTO>>(newAttendances);
        //}





        //public async Task<List<AttendanceApprovalDTO>> GetAttendanceForApprovalByUserIdAsync(int parentId)
        //{
        //    try
        //    {
        //        var attendances = _attendancerepository.GetAttendancesForApprovalAsync(parentId);

        //        if (attendances == null)
        //        {
        //            return null;
        //        }

        //        var attendanceApprovalDTOs = _mappingProfile.Map<List<AttendanceApprovalDTO>>(attendances).ToList();

        //        return attendanceApprovalDTOs;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public async Task<List<AttendanceApproval2DTO>> GetAttendanceForApprovalByUserIdAsync(int parentId, int month)
        {
            try
            {
                var attendances = _attendancerepository.GetAttendancesForApprovalAsync(parentId, month);

                if (attendances == null)
                {
                    return null;
                }

                var attendanceApprovalDTOs = new List<AttendanceApproval2DTO>();

                foreach (var attendance in attendances)
                {
                    var employeeEntity = await _employeeRepository.GetByIdAsync(attendance.EmployeeId ?? 0);
                    var attendanceEntity = await _attendancerepository.GetByIdAsync(attendance.AttendanceId ?? 0);

                    var employeeDTO = _mappingProfile.Map<EmployeeDTO>(employeeEntity);
                    var attendanceDTO = _mappingProfile.Map<AttendanceDTO>(attendanceEntity);

                    var attendanceApprovalDTO = new AttendanceApproval2DTO
                    {
                        ApprovalId = attendance.Id,
                        AttendanceId = attendance.AttendanceId,
                        EmployeeId = attendance.EmployeeId,
                        ApproveRequestId = attendance.ApproveRequestId,
                        Status = attendance.Status,
                        ApprovalDate = attendance.ApprovalDate,
                        CreatedDate = attendance.CreatedDate,
                        CreatedBy = attendance.CreatedBy,
                        ModifiedDate = attendance.ModifiedDate,
                        ModifiedBy = attendance.ModifiedBy,
                        IsStepCompleted = attendance.IsStepCompleted,
                        IsActive = attendance.IsActive,
                        IsDeleted = attendance.IsDeleted,
                        Remark = attendance.Remark,
                        Employee = employeeDTO,
                        Attendance = attendanceDTO
                    };

                    attendanceApprovalDTOs.Add(attendanceApprovalDTO);
                }

                return attendanceApprovalDTOs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<InProgressDataDTO> GetspParentOfUsersAsync(int EmplId, DateTime ApprovalDate)
        {
            try
            {
                var attendances = _attendancerepository.GetInProgressSummaryAsync(EmplId, ApprovalDate);

                if (attendances == null)
                {
                    return null;
                }

                var attendanceList = new List<InProgressAttendances>();
                foreach (var attendance in attendances)
                {
                    var employeeEntity = await _employeeRepository.GetByIdAsync(attendance.ApproveRequestId ?? 0).ConfigureAwait(false);
                    var employeeName = employeeEntity?.Name;

                    var attendanceDTO = new InProgressAttendances
                    {
                        ApprovalId = attendance.Id,
                        AttendanceId = attendance.AttendanceId,
                        EmployeeId = attendance.EmployeeId,
                        ApproveRequestId = attendance.ApproveRequestId,
                        Status = attendance.Status,
                        ApprovalDate = attendance.ApprovalDate,
                        CreatedDate = attendance.CreatedDate,
                        CreatedBy = attendance.CreatedBy,
                        ModifiedDate = attendance.ModifiedDate,
                        ModifiedBy = attendance.ModifiedBy,
                        IsStepCompleted = attendance.IsStepCompleted,
                        IsActive = attendance.IsActive,
                        IsDeleted = attendance.IsDeleted,
                        Remark = attendance.Remark,
                        EmployeeName = employeeName,
                    };

                    attendanceList.Add(attendanceDTO);
                }

                var parentFlow = _employeeRepository.GetEmployeeAndParentByUserIdAsync(EmplId);

                var inProgressData = new InProgressDataDTO
                {
                    ParentFlow = parentFlow,
                    Attendance = attendanceList,
                };

                return inProgressData;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task UpdatePendingLogoutUserForApproval()
        {
            var existingAttendances = _attendancerepository.GetLoggedInUsersForTodayAsync();

            if (existingAttendances != null)
            {

                foreach (var attendance in existingAttendances)
                {
                    attendance.Status = "PENDING APPROVAL";

                    await _attendancerepository.UpdateAsync(attendance);
                }


            }
        }

        public async Task<string> GetAttenendanceStatus(int userId)
        {
            var attendance = _attendancerepository.GetLogoutAttendance(userId);

            if (attendance != null)
            {
                if (attendance.PunchInStatus == "PunchIn")
                {
                    return "PunchIn";
                }
                else if (attendance.PunchInStatus == "PunchOut")
                {
                    return "PunchOut";
                }
            }
            return null;
        }

    }
}
