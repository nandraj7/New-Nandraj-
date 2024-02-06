using LeadTracker.API;
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
    public class VisitTrackingRepository : Repository<VisitTracking>, IVisitTrackingRepository
    {
        private readonly LeadTrackerContext _context;
        public VisitTrackingRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;

        }

        //public VisitTracking GetLoginAttendance(int userId, DateTime todaysDate)
        //{
        //    return _context.VisitTrackings
        //        .FirstOrDefault(la => la.UserId == userId &&
        //                               la.StartDateTime >= todaysDate);
        //}

        public void CreateLoginAttendance(VisitTracking visitTracking)
        {
            visitTracking.IsActive = true;
            visitTracking.CreatedDate = DateTime.Now;
            visitTracking.ModifiedDate = DateTime.Now;
            visitTracking.IsDeleted = false;
            visitTracking.Status = false;

            _context.VisitTrackings.Add(visitTracking);
            _context.SaveChanges();
        }
        public void UpdateVisitStatus(int? enquiryId)
        {
            var visitTracking = _context.VisitTrackings.FirstOrDefault(vt => vt.EnquiryId == enquiryId);

            if (visitTracking != null)
            {
                visitTracking.IsActive = false;
                visitTracking.IsDeleted = true;
                _context.SaveChanges();
            }
        }

        public VisitTracking GetStopVisitTracking(int userId)
        {
            return _context.VisitTrackings
                   .Where(la => la.UserId == userId)
                   .OrderByDescending(la => la.Id)
                   .FirstOrDefault();
        }

        public void UpdateStopVisitTracking(VisitTracking visitTracking)
        {
            visitTracking.ModifiedDate = DateTime.Now;
            visitTracking.Status = true;
            _context.VisitTrackings.Update(visitTracking);
            _context.SaveChanges();
        }

        public VisitTracking GetVisitTrackingStatus(int userId, int enquiryId)
        {
            return _context.VisitTrackings
                   .Where(la => la.UserId == userId && la.EnquiryId == enquiryId)
                   .OrderByDescending(la => la.Id)
                   .FirstOrDefault();
            
        }



        public async Task CreateVisitTracking(VisitTracking visitTracking)
        {
            visitTracking.IsActive = true;
            visitTracking.CreatedDate = DateTime.Now;
            visitTracking.ModifiedDate = DateTime.Now;
            visitTracking.IsDeleted = false;
            visitTracking.Status = false;

            _context.VisitTrackings.Add(visitTracking);
            _context.SaveChanges();

        }

        public List<VisitStatusDTO> GetVisitTrackingStatusAsync(VisitTrackingDetailsDTO visitStatus)
        {

            var parameters = new List<SqlParameter>
            {
                //new SqlParameter("@UserId", (object)visitStatus.UserId ?? DBNull.Value),
                //new SqlParameter("@StartDate", visitStatus.StartDate),
                //new SqlParameter("@EndDate", visitStatus.EndDate),
                new SqlParameter("@VisitStatus", visitStatus.VisitStatus)
            };
            var result = _context.Set<VisitStatusDTO>()
                .FromSqlRaw("spGetEmployeeVisitLeadData  @VisitStatus", parameters.ToArray())
                .ToList();
            return result;
        }

    }

}
