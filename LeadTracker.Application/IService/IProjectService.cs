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
    public interface IProjectService
    {
        Task CreateProject(ProjectDTO project);

        Task<ProjectDTO> GetProjectByIdAsync(int id);

        Task<IEnumerable<ProjectDTO>> GetAllProjectAsync();

        Task UpdateProjectAsync(int id, ProjectDTO project);

        Task DeleteProjectAsync(int id);
    }
}
