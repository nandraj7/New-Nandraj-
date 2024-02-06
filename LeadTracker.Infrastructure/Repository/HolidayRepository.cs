using LeadTracker.API.Entities;
using LeadTracker.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LeadTracker.Infrastructure.Repository
{
    public class HolidayRepository : Repository<Holiday>, IHolidayRepository
    {
        private readonly LeadTrackerContext _context;
        public HolidayRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }


        public async Task CreateNewHolidayAsync(List<Holiday> holiday)
        {
            foreach (var entity in holiday)
            {
                entity.Status = true;
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;

                await _context.Holidays.AddAsync(entity).ConfigureAwait(false);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);

        }

        //public async Task<bool> IsTodayHolidayAsync(int orgId)
        //{
        //    //DateTime today = DateTime.Today;

        //    var holiday = await _context.Holidays
        //        .AnyAsync(h => h.OrgId == orgId && h.Date == DateTime.Today)
        //        .ConfigureAwait(false);

        //    return holiday;
        //}

        //public async Task UpdateHolidayAsync(Holiday holidays)
        //{
        //    holidays.Status = true;
        //    holidays.IsActive = true;
        //    holidays.IsDeleted = false;
        //    holidays.ModifiedDate = DateTime.Now;

        //    _context.Holidays.Update(holidays);
        //    await _context.SaveChangesAsync().ConfigureAwait(false);
        //}
    }

}
