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
        Task CreateProject(ProjectDTO project, int userId);
        Task<Project> UpdateProjectAsync(int id, ProjectDTO project, int userId);
        //Task CreateProject(ProjectDTO project);

        Task<NewProjectDTO> GetProjectByIdAsync(int id);

        Task<IEnumerable<NewProjectDTO>> GetAllProjectAsync();

        //Task UpdateProjectAsync(int id, ProjectDTO project);

        Task DeleteProjectAsync(int id);
    }
}
