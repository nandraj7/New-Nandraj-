using LeadTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IHolidayRepository : IRepository<Holiday>
    {
        Task CreateNewHolidayAsync(List<Holiday> holiday);
       // Task<bool> IsTodayHolidayAsync(int orgId);
        //Task UpdateHolidayAsync(Holiday holidays);
    }
}
