using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectrepository;
        private readonly IMapper _mappingProfile;

        public ProjectService(IMapper mappingProfile, IProjectRepository projectService)
        {
            _mappingProfile = mappingProfile;
            _projectrepository = projectService;

        }
        public async Task CreateProject(ProjectDTO project)
        {
            var proj = _mappingProfile.Map<Project>(project);
            await _projectrepository.CreateAsync(proj).ConfigureAwait(false);
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            var project = await _projectrepository.GetByIdAsync(id);

            var projectDTO = _mappingProfile.Map<ProjectDTO>(project);

            return projectDTO;
        }
        public async Task<IEnumerable<ProjectDTO>> GetAllProjectAsync()
        {
            var projects = await _projectrepository.GetAllAsync();
            var projectsDTO = _mappingProfile.Map<List<ProjectDTO>>(projects);
            return projectsDTO.ToList();
        }

        public async Task UpdateProjectAsync(int id, ProjectDTO project)
        {
            var existingProject = await _projectrepository.GetByIdAsync(id);
            _mappingProfile.Map(project, existingProject);
            await _projectrepository.UpdateAsync(existingProject);

            //var proj = _mappingProfile.Map<Project>(project);
            //await _projectrepository.UpdateAsync(proj);
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _projectrepository.GetByIdAsync(id);
            if (project != null)
            {
                await _projectrepository.DeleteAsync(id);
            }
        }
    }
}
