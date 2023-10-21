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
    public class ProjectDetailService : IProjectDetailService
    {
        private readonly IProjectDetailRepository _projectDetailrepository;
        private readonly IMapper _mappingProfile;

        public ProjectDetailService(IProjectDetailRepository projectDetailrepository, IMapper mappingProfile)
        {
            _projectDetailrepository = projectDetailrepository;
            _mappingProfile = mappingProfile;
        }

        public async Task CreateProjectDetail(ProjectDetailDTO projectDetail)
        {
            var pro = _mappingProfile.Map<ProjectDetail>(projectDetail);
            await _projectDetailrepository.CreateAsync(pro).ConfigureAwait(false);
        }

        public async Task<ProjectDetailDTO> GetProjectDetailByIdAsync(int id)
        {
            var projectDetail = await _projectDetailrepository.GetByIdAsync(id);

            var projectDetailDTO = _mappingProfile.Map<ProjectDetailDTO>(projectDetail);
            return projectDetailDTO;
        }

        public async Task<IEnumerable<ProjectDetailDTO>> GetAllProjectDetailAsync()
        {
            var projectDetails = await _projectDetailrepository.GetAllAsync();
            var projectDetailsDTO = _mappingProfile.Map<List<ProjectDetailDTO>>(projectDetails);
            return projectDetailsDTO.ToList();
        }

        public async Task UpdateProjectDetailAsync(int id, ProjectDetailDTO projectDetail)
        {
            var existingProjectDetail = await _projectDetailrepository.GetByIdAsync(id);
            _mappingProfile.Map(projectDetail, existingProjectDetail);
            await _projectDetailrepository.UpdateAsync(existingProjectDetail);

            //var pro = _mappingProfile.Map<ProjectDetail>(projectDetail);
            //await _projectDetailrepository.UpdateAsync(pro);
        }

        public async Task DeleteProjectDetailAsync(int id)
        {
            var projectDetail = await _projectDetailrepository.GetByIdAsync(id);
            if (projectDetail != null)
            {
                await _projectDetailrepository.DeleteAsync(id);
            }
        }
    }
}
