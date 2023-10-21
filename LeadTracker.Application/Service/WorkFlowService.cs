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
    public class WorkFlowService : IWorkFlowService
    {
        private readonly IWorkFlowRepository _workFlowrepository;
        private readonly IMapper _mappingProfile;

        public WorkFlowService(IWorkFlowRepository workFlowrepository, IMapper mappingProfile)
        {
            _workFlowrepository = workFlowrepository;
            _mappingProfile = mappingProfile;
        }

        public async Task CreateWorkFlow(WorkFlowDTO workFlow)
        {
            var workflo = _mappingProfile.Map<WorkFlow>(workFlow);
            await _workFlowrepository.CreateAsync(workflo).ConfigureAwait(false);
        }

        public async Task<WorkFlowDTO> GetWorkFlowByIdAsync(int id)
        {
            var workFlow = await _workFlowrepository.GetByIdAsync(id);

            var workFlowDTO = _mappingProfile.Map<WorkFlowDTO>(workFlow);
            return workFlowDTO;
        }

        public async Task<IEnumerable<WorkFlowDTO>> GetAllWorkFlowAsync()
        {
            var workFlows = await _workFlowrepository.GetAllAsync();

            var workFlowsDTO = _mappingProfile.Map<List<WorkFlowDTO>>(workFlows);
            return workFlowsDTO.ToList();
        }

        public async Task UpdateWorkFlowAsync(int id, WorkFlowDTO workFlow)
        {
            var existingWorkFlow = await _workFlowrepository.GetByIdAsync(id);
            _mappingProfile.Map(workFlow, existingWorkFlow);
            await _workFlowrepository.UpdateAsync(existingWorkFlow);

            //var track = _mappingProfile.Map<Tracker>(tracker);
            //await _trackerrepository.UpdateAsync(track);
        }

        public async Task DeleteWorkFlowAsync(int id)
        {
            var WorkFlow = await _workFlowrepository.GetByIdAsync(id);
            if (WorkFlow != null)
            {
                await _workFlowrepository.DeleteAsync(id);
            }
        }

        
    }
}
