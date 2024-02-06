using LeadTracker.API;
using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IVisitTrackingRepository : IRepository<VisitTracking>
    {
       // VisitTracking GetLoginAttendance(int userId, DateTime todaysDate);
        void CreateLoginAttendance(VisitTracking visitTracking);

        void UpdateVisitStatus(int? enquiryId);

        VisitTracking GetStopVisitTracking(int userId);

        void UpdateStopVisitTracking(VisitTracking visitTracking);

        VisitTracking GetVisitTrackingStatus(int userId, int enquiryId);

        Task CreateVisitTracking(VisitTracking visitTracking);

        List<VisitStatusDTO> GetVisitTrackingStatusAsync(VisitTrackingDetailsDTO visitStatus);
    }
}
