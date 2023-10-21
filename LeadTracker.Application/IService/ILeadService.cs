using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface ILeadService
    {
        Task CreateLead(LeadDTO lead);

        Task<LeadDTO> GetLeadByIdAsync(int id);

        Task<IEnumerable<LeadDTO>> GetAllLeadAsync();

        Task UpdateLeadAsync(int id, LeadDTO lead);

        Task DeleteLeadAsync(int id);

        //Task<IEnumerable<EnquiryDTO>> GetEnquiriesByCurrentStepAsync(int userId, int orgId, string currentStep);
        Task<IEnumerable<TrackerDTO>> GetEnquiriesByCurrentStepAsync(int userId, int orgId, string currentStep ,int take, int skip);
    }
}
