using LeadTracker.API;
using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IWorkFlowService
    {
        Task CreateWorkFlow(WorkFlowDTO workflow);

        Task<WorkFlowDTO> GetWorkFlowByIdAsync(int id);

        Task<IEnumerable<WorkFlowDTO>> GetAllWorkFlowAsync();

        Task UpdateWorkFlowAsync(int id, WorkFlowDTO workflow);

        Task DeleteWorkFlowAsync(int id);

        
    }
}
