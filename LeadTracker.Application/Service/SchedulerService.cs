using LeadTracker.BusinessLayer.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    using LeadTracker.Core.DTO;
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    public class SchedulerService
    {
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private readonly IServiceProvider _serviceProvider;

        public SchedulerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        //public void Start()
        //{
        //    _cancellationTokenSource = new CancellationTokenSource();
        //    _cancellationToken = _cancellationTokenSource.Token;

        //    Task.Run(async () =>
        //    {
        //        while (!_cancellationToken.IsCancellationRequested)
        //        {
        //            DateTime now = DateTime.Now;
        //            DateTime nextRun;

        //            if (now.Hour < 23 || (now.Hour == 23 && now.Minute < 58))
        //            {

        //                nextRun = now.Date.AddHours(23).AddMinutes(58);
        //            }
        //            else
        //            {

        //                nextRun = now.Date.AddDays(1).AddHours(23).AddMinutes(58);
        //            }

        //            TimeSpan delay = nextRun - now;

        //            await Task.Delay(delay, _cancellationToken);

        //            await EmployeesTodaysActivity().ConfigureAwait(false);

        //            Console.WriteLine($"Scheduled task running at: {DateTime.Now}");
        //        }
        //    }, _cancellationToken);
        //}


        public void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            Task.Run(async () =>
            {
                while (!_cancellationToken.IsCancellationRequested)
                {
                    DateTime now = DateTime.Now;
                    DateTime nextRun;

                    if (IsWeekend(now))
                    {
                        nextRun = now.Date.AddDays(1).AddHours(23).AddMinutes(58);

                        //nextRun = now.Date.AddDays(1).AddHours(15).AddMinutes(07);

                    }
                    else
                    {
                        nextRun = now.Date.AddHours(23).AddMinutes(58);
                        //nextRun = now.Date.AddHours(15).AddMinutes(07);
                    }

                    TimeSpan delay = nextRun - now;

                    await Task.Delay(delay, _cancellationToken);

                    if (!IsWeekend(now, GetWeekendDay()))
                    {
                        await EmployeesTodaysActivity().ConfigureAwait(false);

                        Console.WriteLine($"Scheduled task running at: {DateTime.Now}");
                    }
                    else
                    {
                        Console.WriteLine($"Scheduled task skipped on weekend day: {DateTime.Now}");
                    }
                }
            }, _cancellationToken);
        }

        private bool IsWeekend(DateTime date, DayOfWeek? weekendDay = null)
        {
            if (weekendDay.HasValue)
            {
                return date.DayOfWeek == weekendDay.Value;
            }
            else
            {
                return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
            }
        }

        private DayOfWeek? GetWeekendDay()
        {
            string weekendDayFromConfig = "DAY";

            if (Enum.TryParse(weekendDayFromConfig, out DayOfWeek weekendDay))
            {
                return weekendDay;
            }
            return DayOfWeek.Monday;
        }


        //public void Start()
        //{
        //    _cancellationTokenSource = new CancellationTokenSource();
        //    cancellationToken = cancellationTokenSource.Token;

        //    Task.Run(async () =>
        //    {
        //        while (!_cancellationToken.IsCancellationRequested)
        //        {
        //            DateTime now = DateTime.Now;
        //            DateTime nextRun = now.Date.AddDays(1).AddHours(4); 


        //            TimeSpan delay = nextRun - now;


        //            await Task.Delay(delay, _cancellationToken);


        //            await EmployeesTodaysActivity().ConfigureAwait(false);

        //            Console.WriteLine($"Scheduled task running at: {DateTime.Now}");
        //        }
        //    }, _cancellationToken);
        //}


        public async Task EmployeesTodaysActivity()
        {

            using (var scope = _serviceProvider.CreateScope())
            {
                var attendanceService = scope.ServiceProvider.GetRequiredService<IAttendanceService>();
                var absentEmployeeIds = await attendanceService.GetAbsentUserIdsForTodayAsync(10).ConfigureAwait(false);
                var weekendEmployeeIds = await attendanceService.GetWeekendUserIdsForTodayAsync(10).ConfigureAwait(false);
                await attendanceService.AddAbsentUserIdsToAttendance(absentEmployeeIds).ConfigureAwait(false);
                await attendanceService.AddWeekendUserIdsToAttendance(weekendEmployeeIds).ConfigureAwait(false);

            }
        }

        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
        }

    }


}