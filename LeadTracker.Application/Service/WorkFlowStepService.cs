using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class WorkFlowStepService : IWorkFlowStepService
    {
        private readonly IWorkFlowStepRepository _workFlowSteprepository;
        private readonly IMapper _mappingProfile;

        public WorkFlowStepService(IWorkFlowStepRepository workFlowSteprepository, IMapper mappingProfile)
        {
            _workFlowSteprepository = workFlowSteprepository;
            _mappingProfile = mappingProfile;
        }

        public async Task CreateWorkFlowStep(WorkFlowStepDTO workFlowStep)
        {
            var workflowSte = _mappingProfile.Map<WorkFlowStep>(workFlowStep);
            await _workFlowSteprepository.CreateAsync(workflowSte).ConfigureAwait(false);
        }

        public async Task<WorkFlowStepDTO> GetWorkFlowStepByIdAsync(int id)
        {
            var workFlowStep = await _workFlowSteprepository.GetByIdAsync(id);

            var workFlowStepDTO = _mappingProfile.Map<WorkFlowStepDTO>(workFlowStep);
            return workFlowStepDTO;
        }

        public async Task<IEnumerable<WorkFlowStepDTO>> GetAllWorkFlowStepAsync()
        {
            var workFlowSteps = await _workFlowSteprepository.GetAllAsync();

            var workflowstepsDTO = _mappingProfile.Map<List<WorkFlowStepDTO>>(workFlowSteps);
            return workflowstepsDTO.ToList();
        }
        public async Task UpdateWorkFlowStepAsync(int id, WorkFlowStepDTO workFlowStep)
        {
            var existingWorkFlowStep = await _workFlowSteprepository.GetByIdAsync(id);
            _mappingProfile.Map(workFlowStep, existingWorkFlowStep);
            await _workFlowSteprepository.UpdateAsync(existingWorkFlowStep);
        }

        public async Task DeleteWorkFlowStepAsync(int id)
        {
            var WorkFlowStep = await _workFlowSteprepository.GetByIdAsync(id);
            if (WorkFlowStep != null)
            {
                await _workFlowSteprepository.DeleteAsync(id);
            }
        }

        public async Task<OrgWorkFlowDTO> GetWorkFlowAsync(int orgId)
        {
            var workflow = await _workFlowSteprepository.GetWorkFlowByOrgIdAsync(orgId).ConfigureAwait(false);
            var workFlowStep = await _workFlowSteprepository.GetWorkFlowStepByOrgIdByIdAsync(orgId).ConfigureAwait(false);

            if (workflow == null || !workFlowStep.Any())
            {
                return null;
            }

            var workFlowDTO = new OrgWorkFlowDTO
            {
                WorkFlow = _mappingProfile.Map<WorkFlowDTO>(workflow),
                WorkFlowStepDTO = _mappingProfile.Map<List<WorkFlowStepDTO>>(workFlowStep).ToList()
            };

            return workFlowDTO;
        }

        public async Task<IEnumerable<NextStepDTO>> GetNextStepsAsync(string currentStep, int currentStepWFId, int orgId)
        {
            var nextSteps = await _workFlowSteprepository.GetNextStepsByCurrentStepAsync(currentStep, currentStepWFId,orgId).ConfigureAwait(false);

            if (nextSteps == null || !nextSteps.Any())
            {
                return null;
            }

            return nextSteps;
        }

    }
}
