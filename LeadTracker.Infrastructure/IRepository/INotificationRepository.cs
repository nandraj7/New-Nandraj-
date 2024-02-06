using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task CreateNotificationAsync(List<Notification> notification);

        Task<List<Notification>> GetNotificationsAsync(NewNotificationDTO notification);
        Notification GetNotificationRecordById(UpdateNotificationDTO notification);
        List<Notification> GetExistingNotificationsRecordsByUserId(UpdateNotificationDTO notification);
        Task SaveChangesAsync();
        Task AddNotificationsAsync(List<Notification> notifications);
        Task<List<int>> GetLoggedInUserIdsForDateAsync(DateTime date);
        Task<UserLocation> GetOnlineUserIdsForDateAsync(int userId, DateTime currentDateTime);

        //Notification GetNotificationRecord(UpdateNotificationDTO notification);

        //List<AttendanceApproval> GetExistingNotificationsRecords(UpdateNotificationDTO notification);
    }
}
