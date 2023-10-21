using LeadTracker.API;
using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IWorkFlowStepService
    {
        Task CreateWorkFlowStep(WorkFlowStepDTO workFlowStep);

        Task<WorkFlowStepDTO> GetWorkFlowStepByIdAsync(int id);

        Task<IEnumerable<WorkFlowStepDTO>> GetAllWorkFlowStepAsync();

        Task UpdateWorkFlowStepAsync(int id, WorkFlowStepDTO workFlowStep);

        Task DeleteWorkFlowStepAsync(int id);

        Task<OrgWorkFlowDTO> GetWorkFlowAsync(int orgId);

        Task<IEnumerable<NextStepDTO>> GetNextStepsAsync(string currentStep, int currentStepWFId, int orgId);
    }
}
