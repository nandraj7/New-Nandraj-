using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchrepository;
        private readonly IMapper _mappingProfile;

        public BranchService(IMapper mappingProfile, IBranchRepository branchService)
        {
            _mappingProfile = mappingProfile;
            _branchrepository = branchService;

        }

        public async Task CreateBranch(BranchDTO branch)
        {
            var brnch = _mappingProfile.Map<Branch>(branch);
            await _branchrepository.CreateAsync(brnch).ConfigureAwait(false);
        }

        public async Task<BranchDTO> GetBranchByIdAsync(int id)
        {
            var branch =  await _branchrepository.GetByIdAsync(id);

            var branchDTO = _mappingProfile.Map<BranchDTO>(branch);

            return branchDTO;
        }

        public async Task<IEnumerable<BranchDTO>> GetAllBranchAsync()
        {
            var branches = await _branchrepository.GetAllAsync();
            var branchesDTO = _mappingProfile.Map<List<BranchDTO>>(branches);
            return branchesDTO.ToList();
        }

        public async Task UpdateBranchAsync(int id, BranchDTO branch)
        {
            var existingBranch = await _branchrepository.GetByIdAsync(id);


            _mappingProfile.Map(branch, existingBranch);


            await _branchrepository.UpdateAsync(existingBranch);

            //var brn = _mappingProfile.Map<Branch>(branch);
            //await _branchrepository.UpdateAsync(brn);
        }

        public async Task DeleteBranchAsync(int id)
        {
            var branch = await _branchrepository.GetByIdAsync(id);
            if (branch != null)
            {
                await _branchrepository.DeleteAsync(id);
            }
        }
    }
}
