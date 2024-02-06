using LeadTracker.API;
using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface ILeadSourceService
    {
        Task<UploadXMLFileResponse> UploadXMLFile(LeadSourceDTO leadSource, string path);
        Task<LeadSourceGetDTO> GetLeadSourceByIdAsync(int id);
        Task<IEnumerable<LeadSourceGetDTO>> GetLeadSourceByStepAsync(int take, int skip);
        Task<(List<Lead>, List<Tracker>)> TransferDataAsync(int assignedTo, List<int> leadSourceIds, int orgId, int userId);
        //Task<bool> UploadManualLeadAsync(LeadManualDTO manualLead);

        Task<List<Tracker>> CreateAndUpdateTrackersAsync(int assignedTo, List<int> trackerIds, int orgId, int userId);
        Task<int> CreateLeadAsync(LeadManualDTO manualLead, int userId);
    }
}
