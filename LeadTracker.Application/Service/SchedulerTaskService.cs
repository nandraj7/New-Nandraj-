using LeadTracker.API.Entities;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

//namespace LeadTracker.BusinessLayer.Service
//{
//    public class SchedulerTaskService : IHostedService, IDisposable
//    {
//        private Timer _timer;
//        private readonly IServiceProvider _serviceProvider;

//        public SchedulerTaskService(IServiceProvider serviceProvider)
//        {
//            _serviceProvider = serviceProvider;
//        }

//        public Task StartAsync(CancellationToken cancellationToken)
//        {

//            var now = DateTime.Now;
//            var timeUntilTarget = new DateTime(now.Year, now.Month, now.Day, 23, 00, 0) - now;

//            if (timeUntilTarget < TimeSpan.Zero)
//            {

//                timeUntilTarget = timeUntilTarget.Add(TimeSpan.FromDays(1));
//            }

//            _timer = new Timer(DoWork, null, timeUntilTarget, TimeSpan.FromDays(1)); // Repeat every day
//            return Task.CompletedTask;
//        }

//        private void DoWork(object state)
//        {
//            try
//            {
//                using (var scope = _serviceProvider.CreateScope())
//                {
//                    var attendanceService = scope.ServiceProvider.GetRequiredService<IAttendanceService>();
//                    EmployeesTodaysActivity(attendanceService).GetAwaiter().GetResult();
//                }
//            }
//            catch (Exception ex)
//            {

//                Console.WriteLine($"Exception occurred in DoWork: {ex.Message}");
//            }
//        }

//        public Task StopAsync(CancellationToken cancellationToken)
//        {
//            _timer?.Dispose();
//            return Task.CompletedTask;
//        }

//        public void Dispose()
//        {
//            _timer?.Dispose();
//        }

//        public async Task EmployeesTodaysActivity(IAttendanceService attendanceService)
//        {
//            try
//            {
//                var absentEmployeeIds = await attendanceService.GetAbsentUserIdsForTodayAsync(1).ConfigureAwait(false);
//                await attendanceService.AddAbsentUserIdsToAttendance(absentEmployeeIds).ConfigureAwait(false);
//                Console.WriteLine("EmployeesTodaysActivity executed successfully.");
//            }
//            catch (Exception ex)
//            {

//                Console.WriteLine($"Exception occurred in EmployeesTodaysActivity: {ex.Message}");
//            }
//        }
//    }
//}



namespace LeadTracker.BusinessLayer.Service
{
    public class SchedulerTaskService : IHostedService, IDisposable
    {
        private Timer _dailyTimer;
        private Timer _fifteenMinuteTimer;
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScopeFactory _scopeFactory;

        public SchedulerTaskService(IServiceProvider serviceProvider, IServiceScopeFactory scopeFactory)
        {
            _serviceProvider = serviceProvider;
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.Now;
            var timeUntilMidnight = new DateTime(now.Year, now.Month, now.Day, 23, 00, 00) - now;

            if (timeUntilMidnight < TimeSpan.Zero)
            {
                timeUntilMidnight = timeUntilMidnight.Add(TimeSpan.FromDays(1));
            }

            _dailyTimer = new Timer(DailyWork, null, timeUntilMidnight, TimeSpan.FromDays(1));

            _fifteenMinuteTimer = new Timer(TrackEmployeeCurrentLocation, null, TimeSpan.Zero, TimeSpan.FromMinutes(15));

            return Task.CompletedTask;
        }

        private void DailyWork(object state)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var attendanceService = scope.ServiceProvider.GetRequiredService<IAttendanceService>();
                    EmployeesTodaysActivity().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred in DailyWork: {ex.Message}");
            }
        }

        private void TrackEmployeeCurrentLocation(object state)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
                    TrackEmployeeCurrentLocation(notificationService).GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred in TrackEmployeeCurrentLocation: {ex.Message}");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _dailyTimer?.Dispose();
            _fifteenMinuteTimer?.Dispose();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _dailyTimer?.Dispose();
            _fifteenMinuteTimer?.Dispose();
        }

        //public async Task EmployeesTodaysActivity()
        //{
        //    var orgId = 1;

        //    using (var scope = _serviceProvider.CreateScope())
        //    {
        //        var attendanceService = scope.ServiceProvider.GetRequiredService<IAttendanceService>();
        //        var absentEmployeeIds = await attendanceService.GetAbsentUserIdsForTodayAsync(10).ConfigureAwait(false);
        //        var weekendEmployeeIds = await attendanceService.GetWeekendUserIdsForTodayAsync(10).ConfigureAwait(false);
        //        var holidayEmployeeIds = await attendanceService.GetHolidayUserIdsForTodayAsync(10).ConfigureAwait(false);
        //        await attendanceService.AddAbsentUserIdsToAttendance(absentEmployeeIds).ConfigureAwait(false);
        //        await attendanceService.AddWeekendUserIdsToAttendance(weekendEmployeeIds).ConfigureAwait(false);
        //        await attendanceService.AddHolidayUserIdsToAttendance(holidayEmployeeIds, orgId).ConfigureAwait(false);
        //    }
        //}

        public async Task EmployeesTodaysActivity()
        {
            var orgId = 1;

            using (var scope = _serviceProvider.CreateScope())
            {
                var attendanceService = scope.ServiceProvider.GetRequiredService<IAttendanceService>();
                var databaseService = scope.ServiceProvider.GetRequiredService<IDatabaseService>();

                var weekendConfig = databaseService.GetWeekendConfig();

                bool isWeekend = IsWeekendDay(DateTime.Today, weekendConfig);

                if (isWeekend)
                {
                    var weekendEmployeeIds = await attendanceService.GetWeekendUserIdsForTodayAsync(1).ConfigureAwait(false);
                    await attendanceService.AddWeekendUserIdsToAttendance(weekendEmployeeIds).ConfigureAwait(false);
                }

                var holidayConfig = databaseService.GetHoliday();

                if (IsHolidayToday(holidayConfig))
                {
                    var holidayEmployeeIds = await attendanceService.GetHolidayUserIdsForTodayAsync(1).ConfigureAwait(false);
                    await attendanceService.AddHolidayUserIdsToAttendance(holidayEmployeeIds, orgId).ConfigureAwait(false);
                }
                else
                {
                    var absentEmployeeIds = await attendanceService.GetAbsentUserIdsForTodayAsync(1).ConfigureAwait(false);
                    await attendanceService.AddAbsentUserIdsToAttendance(absentEmployeeIds).ConfigureAwait(false);
                }
            }
        }

        private bool IsWeekendDay(DateTime date, SystemConfiguration weekendConfig)
        {
            string[] weekendDays = weekendConfig?.Value?.Split(',');

            if (weekendDays != null && weekendDays.Length > 0)
            {
                return weekendDays.Contains(date.DayOfWeek.ToString(), StringComparer.OrdinalIgnoreCase);
            }

            return false;
        }

        //private bool IsHolidayToday(Holiday holidayConfig)
        //{
        //    string[] holidayDates = holidayConfig?.Date?.Split(',');

        //    if (holidayDates != null && holidayDates.Length > 0)
        //    {
        //        return holidayDates.Contains(DateTime.Today.ToString("yyyy-MM-dd"));
        //    }

        //    return false;
        //}

        private bool IsHolidayToday(Holiday holidayConfig)
        {
            DateTime? date = holidayConfig?.Date;

            if (date.HasValue)
            {
                string[] holidayDates = date.Value.ToString("yyyy-MM-dd").Split(',');

                return holidayDates.Select(dateValue => dateValue.Trim())
                                   .Contains(DateTime.Today.ToString("yyyy-MM-dd"));
            }

            return false;
        }

        public async Task TrackEmployeeCurrentLocation(INotificationService notificationService)
        {
            try
            {
                var presentEmployeeIds = await notificationService.GetPresentUserIdsForTodayAsync().ConfigureAwait(false);
                await notificationService.SendNotificationToHrAndParentAsync(presentEmployeeIds).ConfigureAwait(false);
                Console.WriteLine("TrackEmployeeCurrentLocation executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred in TrackEmployeeCurrentLocation: {ex.Message}");
            }
        }
    }
}












//namespace LeadTracker.BusinessLayer.Service
//{
//    public class SchedulerTaskService : IHostedService, IDisposable
//    {
//        private Timer _dailyTimer;
//        private Timer _fifteenMinuteTimer;
//        private readonly IServiceProvider _serviceProvider;

//        public SchedulerTaskService(IServiceProvider serviceProvider)
//        {
//            _serviceProvider = serviceProvider;
//        }

//        public Task StartAsync(CancellationToken cancellationToken)
//        {
//            var now = DateTime.Now;
//            var timeUntilMidnight = new DateTime(now.Year, now.Month, now.Day, 23, 00, 0) - now;

//            if (timeUntilMidnight < TimeSpan.Zero)
//            {
//                timeUntilMidnight = timeUntilMidnight.Add(TimeSpan.FromDays(1));
//            }

//            _dailyTimer = new Timer(DailyWork, null, timeUntilMidnight, TimeSpan.FromDays(1));

//            _fifteenMinuteTimer = new Timer(TrackEmployeeCurrentLocation, null, TimeSpan.Zero, TimeSpan.FromMinutes(15));

//            return Task.CompletedTask;
//        }

//        private void DailyWork(object state)
//        {
//            try
//            {
//                using (var scope = _serviceProvider.CreateScope())
//                {
//                    var attendanceService = scope.ServiceProvider.GetRequiredService<IAttendanceService>();
//                    EmployeesTodaysActivity(attendanceService).GetAwaiter().GetResult();
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Exception occurred in DailyWork: {ex.Message}");
//            }
//        }

//        private void TrackEmployeeCurrentLocation(object state)
//        {
//            try
//            {
//                using (var scope = _serviceProvider.CreateScope())
//                {
//                    var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
//                    TrackEmployeeCurrentLocation(notificationService).GetAwaiter().GetResult();
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Exception occurred in TrackEmployeeCurrentLocation: {ex.Message}");
//            }
//        }

//        public Task StopAsync(CancellationToken cancellationToken)
//        {
//            _dailyTimer?.Dispose();
//            _fifteenMinuteTimer?.Dispose();
//            return Task.CompletedTask;
//        }

//        public void Dispose()
//        {
//            _dailyTimer?.Dispose();
//            _fifteenMinuteTimer?.Dispose();
//        }

//        public async Task EmployeesTodaysActivity(IAttendanceService attendanceService)
//        {
//            try
//            {
//                var absentEmployeeIds = await attendanceService.GetAbsentUserIdsForTodayAsync(1).ConfigureAwait(false);
//                await attendanceService.UpdatePendingLogoutUserForApproval().ConfigureAwait(false);
//                await attendanceService.AddAbsentUserIdsToAttendance(absentEmployeeIds).ConfigureAwait(false);
//                Console.WriteLine("EmployeesTodaysActivity executed successfully.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Exception occurred in EmployeesTodaysActivity: {ex.Message}");
//            }
//        }

//        public async Task TrackEmployeeCurrentLocation(INotificationService notificationService)
//        {
//            try
//            {
//                var presentEmployeeIds = await notificationService.GetPresentUserIdsForTodayAsync().ConfigureAwait(false);
//                await notificationService.SendNotificationToHrAndParentAsync(presentEmployeeIds).ConfigureAwait(false);
//                Console.WriteLine("TrackEmployeeCurrentLocation executed successfully.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Exception occurred in TrackEmployeeCurrentLocation: {ex.Message}");
//            }
//        }
//    }
//}

