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
    public interface IProjectDetailService
    {
        Task CreateProjectDetail(ProjectDetailDTO projectDetail);

        Task<ProjectDetailDTO> GetProjectDetailByIdAsync(int id);

        Task<IEnumerable<ProjectDetailDTO>> GetAllProjectDetailAsync();

        Task UpdateProjectDetailAsync(int id, ProjectDetailDTO projectDetail);

        Task DeleteProjectDetailAsync(int id);
    }
}
