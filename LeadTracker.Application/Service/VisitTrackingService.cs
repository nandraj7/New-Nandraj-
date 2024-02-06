using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class VisitTrackingService : IVisitTrackingService
    {
        private readonly IVisitTrackingRepository _visitTrackingRepository;
        private readonly IMapper _mappingProfile;


        public VisitTrackingService(IVisitTrackingRepository visitTrackingRepository, IMapper mappingProfile)
        {
            _visitTrackingRepository = visitTrackingRepository;
            _mappingProfile = mappingProfile;
        }

        public async Task<StartVisitTrackingDTO> StartVisitTracking(StartVisitTrackingDTO startVisitTracking, int userId)
        {
            //var todaysDate = DateTime.Today;


            //var existingStartVisitTracking = _visitTrackingRepository.GetLoginAttendance(userId, todaysDate);

            //if (existingStartVisitTracking != null && existingStartVisitTracking.StartDateTime.Value.Date == DateTime.Now.Date)
            //{
            //    return null;
            //}
            //else
            //{
                VisitTracking visitTracking = new VisitTracking
                {
                    UserId = userId,
                    StartLatitude = startVisitTracking.StartLatitude,
                    StartLongitude = startVisitTracking.StartLongitude,
                    ProjectId = startVisitTracking.ProjectId,
                    EnquiryId = startVisitTracking.EnquiryId,
                    VisitStatus = "VisitStart",
                    StartDateTime = DateTime.Now,
                    WorkFlowStepId = 3,
                    CreatedBy = userId,
                    ModifiedBy = userId
                };
                _visitTrackingRepository.CreateLoginAttendance(visitTracking);

            _visitTrackingRepository.UpdateVisitStatus(visitTracking.EnquiryId);


            return startVisitTracking;
            
        }

        public async Task<StopVisitTrackingDTO> StopVisitTracking(StopVisitTrackingDTO stopVisitTracking, int userId)
        {
            var existingStopVisitTracking = _visitTrackingRepository.GetStopVisitTracking(userId);

            if (existingStopVisitTracking != null && existingStopVisitTracking.StartDateTime != null)
            {
                existingStopVisitTracking.StopLatitude = stopVisitTracking.StopLatitude;
                existingStopVisitTracking.StopLongitude = stopVisitTracking.StopLongitude;
                existingStopVisitTracking.EnquiryId = stopVisitTracking.EnquiryId;
                existingStopVisitTracking.VisitStatus = "Completed";
                existingStopVisitTracking.StopDateTime = DateTime.Now;
                existingStopVisitTracking.ModifiedBy = userId;

                _visitTrackingRepository.UpdateStopVisitTracking(existingStopVisitTracking);
            }

            return stopVisitTracking;
        }

        public async Task<(DateTime? StartDateTime, DateTime? StopDateTime, bool? Status)> GetVisitTrackingStatus(int userId, int enquiryId)
        {
            var dateTime = DateTime.Today;
            var visitTracking = _visitTrackingRepository.GetVisitTrackingStatus(userId, enquiryId);

            if (visitTracking != null)
            {
                if (visitTracking.Status == false && visitTracking.StartDateTime?.Date == dateTime)
                {
                    return (visitTracking.StartDateTime, null, false);
                }
                else if (visitTracking.Status == true && visitTracking.StartDateTime?.Date == dateTime)
                {
                    return (visitTracking.StartDateTime, visitTracking.StopDateTime, true);
                }
            }

            if (visitTracking != null && visitTracking.Status == false)
            {
                return (null, null, false);
            }
            else if (visitTracking != null && visitTracking.Status == true)
            {
                return (null, null, true);
            }


            return (null, null, true);
        }

        public async Task<List<VisitStatusDTO>> GetVisitTrackingStatusAsync(VisitTrackingDetailsDTO visitStatus)
        {
            var visitTracking = _visitTrackingRepository.GetVisitTrackingStatusAsync(visitStatus);
            if (visitTracking == null)
            {
                return null;
            }
            var visitTrackingDTO = _mappingProfile.Map<List<VisitStatusDTO>>(visitTracking).ToList();
            return visitTrackingDTO;

        }

        public async Task<VisitTrackingDTO> GetVisitTrackingByIdAsync(int visitTrackingId)
        {
            var visit = await _visitTrackingRepository.GetByIdAsync(visitTrackingId);
            var visitTracking = _mappingProfile.Map<VisitTrackingDTO>(visit);
            return visitTracking;
        }

        //public async Task<string> GetVisitTrackingStatus(int userId, int enquiryId)
        //{
        //    var visitTracking = _visitTrackingRepository.GetVisitTrackingStatus(userId, enquiryId);

        //    if (visitTracking != null)
        //    {
        //        if (visitTracking.Status == false)
        //        {
        //            return "false";
        //        }
        //        else if (visitTracking.Status == true)
        //        {
        //            return "true";
        //        }
        //    }
        //    return null;
        //}
    }
}
