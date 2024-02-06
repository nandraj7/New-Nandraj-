using AutoMapper;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class NotificationService : INotificationService
    {
        private readonly IMapper _mappingProfile;
        private readonly INotificationRepository _notificationRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public NotificationService(IMapper mappingProfile, INotificationRepository notificationService, IEmployeeRepository employeeRepository)
        {
            _mappingProfile = mappingProfile;
            _notificationRepository = notificationService;
            _employeeRepository = employeeRepository;
        }
        public async Task CreateNotification(NotificationDTO notification, int userId)
        {
            var notif = new List<Notification>();
            notif.Add(new Notification()
            {
                UserId = notification.UserId,
                NotificationText = notification.NotificationText,
                ModuleName = notification.ModuleName,
                Status = notification.Status,
                ParentUserId = notification.ParentUserId,
                CreatedBy = userId,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = userId,
            });
            await _notificationRepository.CreateNotificationAsync(notif).ConfigureAwait(false);
        }

        public async Task<List<NotificationDTO>> GetNotificationAsync(NewNotificationDTO notification)
        {

            var notifications = await _notificationRepository.GetNotificationsAsync(notification).ConfigureAwait(false);

            var notificationDtos = notifications.Select(MapToNotificationDTO).ToList();

            return notificationDtos;
        }

        private NotificationDTO MapToNotificationDTO(Notification notification)
        {
            return new NotificationDTO
            {
                NotificationId = notification.Id,
                UserId = notification.UserId,
                NotificationText = notification.NotificationText,
                ModuleName = notification.ModuleName,
                Status = notification.Status,
                ParentUserId = notification.ParentUserId,
                IsActive = notification.IsActive,
                IsDeleted = notification.IsDeleted,
                CreatedDate = notification.CreatedDate,
                CreatedBy = notification.CreatedBy,
                ModifiedDate = notification.ModifiedDate,
                ModifiedBy = notification.ModifiedBy
            };
        }


        public async Task<object> UpdateNotificationStatusAsync(UpdateNotificationDTO notification, int userId)
        {
            if (notification != null)
            {
                if (notification.Id.HasValue && notification.Id > 0)
                {
                    var record = _notificationRepository.GetNotificationRecordById(notification);

                    if (record != null)
                    {
                        record.Status = notification.Status;
                        record.ModifiedDate = DateTime.Now;
                        record.ModifiedBy = userId;
                        await _notificationRepository.SaveChangesAsync().ConfigureAwait(false);

                        var result = new NotificationDTO
                        {
                            NotificationId = record.Id,
                            UserId = record.UserId,
                            NotificationText = record.NotificationText,
                            ModuleName = record.ModuleName,
                            Status = record.Status,
                            ParentUserId = record.ParentUserId,
                            IsActive = record.IsActive,
                            IsDeleted = record.IsDeleted,
                            CreatedDate = record.CreatedDate,
                            CreatedBy = record.CreatedBy,
                            ModifiedDate = record.ModifiedDate,
                            ModifiedBy = record.ModifiedBy
                        };

                        return result;
                    }
                    else
                    {
                        return $"No record found with Id: {notification.Id}";
                    }
                }
                else if (notification.UserId.HasValue && notification.UserId > 0)
                {
                    var existingRecords = _notificationRepository.GetExistingNotificationsRecordsByUserId(notification);

                    if (existingRecords != null && existingRecords.Any())
                    {
                        foreach (var record in existingRecords)
                        {
                            record.Status = notification.Status;
                            record.ModifiedDate = DateTime.Now;
                            record.ModifiedBy = userId;
                        }

                        await _notificationRepository.SaveChangesAsync().ConfigureAwait(false);

                        var results = existingRecords.Select(record => new NotificationDTO
                        {
                            NotificationId = record.Id,
                            UserId = record.UserId,
                            NotificationText = record.NotificationText,
                            ModuleName = record.ModuleName,
                            Status = record.Status,
                            ParentUserId = record.ParentUserId,
                            IsActive = record.IsActive,
                            IsDeleted = record.IsDeleted,
                            CreatedDate = record.CreatedDate,
                            CreatedBy = record.CreatedBy,
                            ModifiedDate = record.ModifiedDate,
                            ModifiedBy = record.ModifiedBy
                        }).ToList();

                        return results;
                    }
                    else
                    {
                        return $"No records found with UserId: {notification.UserId}";
                    }
                }
            }

            return "Invalid input data for updating notification status.";
        }



        public async Task<List<NotificationDTO>> SendNotificationAsync(SendNotificationDTO notification, int userId)
        {
            var notifications = new List<Notification>();

            foreach (var usersId in notification.UserId)
            {
                var newNotification = new Notification
                {
                    UserId = usersId,
                    NotificationText = notification.NotificationText,
                    Status = "Pending",
                    ModuleName = "Other",
                    ParentUserId = userId,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    CreatedBy = userId,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = userId,

                };

                notifications.Add(newNotification);
            }

            await _notificationRepository.AddNotificationsAsync(notifications).ConfigureAwait(false);

            var result = _mappingProfile.Map<List<NotificationDTO>>(notifications);

            return result;
        }


        public async Task NotificationForBookingAsync(string moduleName, int userId, string assignedToName)
        {
            if (moduleName == "Work flow")
            {
                var employeeIds = await _employeeRepository.GetAllEmployeeIdsAsync();

                foreach (var employeeId in employeeIds)
                {
                    var employeeName = await _employeeRepository.GetEmployeeNameByIdAsync(employeeId);

                    string text = $"Hello {employeeName}, {assignedToName} is having a Booking!!!";

                    var notification = new Notification
                    {
                        UserId = employeeId,
                        NotificationText = text,
                        Status = "Pending",
                        ModuleName = moduleName,
                        ParentUserId = userId,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        CreatedBy = userId,
                        ModifiedDate = DateTime.Now,
                        ModifiedBy = userId,
                    };

                    await _notificationRepository.CreateAsync(notification).ConfigureAwait(false);
                }
            }
        }


        public async Task CreateNotificationForUser(int assignedTo, string text, string moduleName, int userId)
        {
            if (moduleName == "Unassigned Leads" || moduleName == "Attendance Approval" || moduleName == "Reassigned Data" || moduleName == "Attendance Status" || moduleName == "Employee Registration" || moduleName == "Rejected" || moduleName == "Tracking Stopped" || moduleName == "Delete Employee")
            {

                var notification = new Notification
                {
                    UserId = assignedTo,
                    NotificationText = text,
                    Status = "Pending",
                    ModuleName = moduleName,
                    ParentUserId = userId,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    CreatedBy = userId,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = userId,
                };
                await _notificationRepository.CreateAsync(notification).ConfigureAwait(false);
            }
        }

        public async Task NotificationForNewProjectAsync(string moduleName, int userId, string assignedToName)
        {
            if (moduleName == "New Project")
            {
                var employeeIds = await _employeeRepository.GetAllEmployeeIdsAsync();

                foreach (var employeeId in employeeIds)
                {
                    var employeeName = await _employeeRepository.GetEmployeeNameByIdAsync(employeeId);

                    string text = $"Hello {employeeName}, {assignedToName} is Added a new Project!!!";

                    var notification = new Notification
                    {
                        UserId = employeeId,
                        NotificationText = text,
                        Status = "Pending",
                        ModuleName = moduleName,
                        ParentUserId = userId,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        CreatedBy = userId,
                        ModifiedDate = DateTime.Now,
                        ModifiedBy = userId,
                    };

                    await _notificationRepository.CreateAsync(notification).ConfigureAwait(false);
                }



            }
        }

        public async Task<List<int>> GetPresentUserIdsForTodayAsync()
        {
            DateTime today = DateTime.Today;

            //var allEmployeeIds = await GetEmplloyeeIdsByOrgIdAsync(orgId);

            var presentUserIds = await _notificationRepository.GetLoggedInUserIdsForDateAsync(today);


            return presentUserIds;
        }

        public async Task SendNotificationToHrAndParentAsync(List<int> presentEmployeeIds)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime today = DateTime.Today;


            List<int> onlineRecordIds = new List<int>();



            foreach (var presentEmployeeId in presentEmployeeIds)
            {
                var employeeOnlineRecord = await _notificationRepository.GetOnlineUserIdsForDateAsync(presentEmployeeId, currentDateTime);

                if (employeeOnlineRecord == null)
                {
                    onlineRecordIds.Add(presentEmployeeId);
                }
            }


            foreach (var missingUserId in onlineRecordIds)
            {
                var emplName = await _employeeRepository.GetEmployeeNameByIdAsync(missingUserId);

                var parentId = _employeeRepository.GetParentUserIdByEmployeeId(missingUserId);

                var ParentName = await _employeeRepository.GetEmployeeNameByIdAsync(parentId ?? 0);

                var HrName = await _employeeRepository.GetEmployeeNameByIdAsync(3);

                string moduleName = "Tracking Stopped";

                string text1 = $"Hello {ParentName}, {emplName} couldn't be tracked from last 15 minutes!!!";

                await CreateNotificationForUser(parentId ?? 0, text1, moduleName, missingUserId);

                string text2 = $"Hello {HrName}, {emplName} couldn't be tracked from last 15 minutes!!!";

                await CreateNotificationForUser(3, text2, moduleName, missingUserId);


            }



        }

    }

}
