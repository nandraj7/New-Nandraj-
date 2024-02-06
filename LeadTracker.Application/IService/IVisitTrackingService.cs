using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IVisitTrackingService
    {
        Task<StartVisitTrackingDTO> StartVisitTracking(StartVisitTrackingDTO startVisitTracking, int userId);
        Task<StopVisitTrackingDTO> StopVisitTracking(StopVisitTrackingDTO stopVisitTracking, int userId);

        Task<(DateTime? StartDateTime, DateTime? StopDateTime, bool? Status)> GetVisitTrackingStatus(int userId, int enquiryId);

        Task<List<VisitStatusDTO>> GetVisitTrackingStatusAsync(VisitTrackingDetailsDTO visitStatus);

        Task<VisitTrackingDTO> GetVisitTrackingByIdAsync(int visitTrackingId);
    }
}
