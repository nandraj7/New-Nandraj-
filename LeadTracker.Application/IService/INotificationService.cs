using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface INotificationService
    {
        Task CreateNotification(NotificationDTO notification, int userId);
        Task<List<NotificationDTO>> GetNotificationAsync(NewNotificationDTO notification);
        Task<object> UpdateNotificationStatusAsync(UpdateNotificationDTO notification, int userId);
        Task<List<NotificationDTO>> SendNotificationAsync(SendNotificationDTO notification, int userId);
        Task NotificationForBookingAsync(string moduleName, int userId, string assignedToName);
        Task CreateNotificationForUser(int assignedTo, string text, string moduleName, int userId);
        Task NotificationForNewProjectAsync(string moduleName, int userId, string assignedToName);
        Task<List<int>> GetPresentUserIdsForTodayAsync();
        Task SendNotificationToHrAndParentAsync(List<int> presentEmployeeIds);
    }

}
