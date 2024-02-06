using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.Repository
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        private readonly LeadTrackerContext _context;

        public NotificationRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }

        public async Task CreateNotificationAsync(List<Notification> notification)
        {
            foreach (var entity in notification)
            {
                entity.IsActive = true;
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;
                entity.IsDeleted = false;

                await (_context as LeadTrackerContext).Notifications.AddAsync(entity).ConfigureAwait(false);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        //public async Task<List<Notification>> GetNotificationsAsync(NewNotificationDTO notification)
        //{
        //    var query = _context.Notifications.AsQueryable();

        //    if (notification.UserId.HasValue)
        //    {
        //        query = query.Where(n => n.UserId == notification.UserId);
        //    }

        //    if (!string.IsNullOrEmpty(notification.Status))
        //    {
        //        query = query.Where(n => n.Status == notification.Status);
        //    }

        //    if (notification.StartDate.HasValue)
        //    {
        //        query = query.Where(n => n.CreatedDate >= notification.StartDate);
        //    }

        //    if (notification.EndDate.HasValue)
        //    {
        //        query = query.Where(n => n.CreatedDate <= notification.EndDate);
        //    }

        //    var notifications = await query.ToListAsync().ConfigureAwait(false);

        //    return notifications;
        //}

        public async Task<List<Notification>> GetNotificationsAsync(NewNotificationDTO notification)
        {
            var query = _context.Notifications.AsQueryable();

            if (notification.UserId.HasValue)
            {
                query = query.Where(n => n.UserId == notification.UserId);
            }

            if (!string.IsNullOrEmpty(notification.Status))
            {
                query = query.Where(n => n.Status == notification.Status);
            }

            if (notification.StartDate.HasValue)
            {
                query = query.Where(n => n.CreatedDate >= notification.StartDate);
            }

            if (notification.EndDate.HasValue)
            {
                query = query.Where(n => n.CreatedDate <= notification.EndDate);
            }

            query = query.OrderByDescending(n => n.CreatedDate);

            var notifications = await query.ToListAsync().ConfigureAwait(false);

            return notifications;
        }


        public Notification GetNotificationRecordById(UpdateNotificationDTO notification)
        {
            var record = _context.Notifications
                .FirstOrDefault(la => la.Id == notification.Id);

            // Add logging to print the generated SQL query
            var sql = _context.Database.GetDbConnection().CreateCommand().CommandText;
            Console.WriteLine($"SQL Query: {sql}");

            return record;
        }

        public List<Notification> GetExistingNotificationsRecordsByUserId(UpdateNotificationDTO notification)
        {
            var notifications = _context.Notifications
                                .Where(n => n.UserId == notification.UserId)
                                .ToList();

            return notifications;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }


        public async Task AddNotificationsAsync(List<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                await _context.Notifications.AddAsync(notification).ConfigureAwait(false);
            }

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<int>> GetLoggedInUserIdsForDateAsync(DateTime date)
        {
            return await _context.Attendances
                .Where(a => a.LoginDate.HasValue && a.LogoutDate == null && a.LoginDate.Value.Date == date.Date)
                .Select(a => a.UserId ?? 0)
                .Distinct()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<UserLocation> GetOnlineUserIdsForDateAsync(int userId, DateTime currentDateTime)
        {
            DateTime fifteenMinutesBefore = currentDateTime.AddMinutes(-15);

            var userLocation = await _context.UserLocations
                .Where(ul => ul.UserId == userId && ul.Date > fifteenMinutesBefore && ul.Date <= currentDateTime)
                .OrderByDescending(ul => ul.Date)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return userLocation;
        }

    }
}
