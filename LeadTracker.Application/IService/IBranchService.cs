using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IBranchService
    {
        Task CreateBranch(BranchDTO branch);

        Task<Branch> GetBranchByIdAsync(int id);

        Task<IEnumerable<Branch>> GetAllBranchAsync();

        Task UpdateBranchAsync(BranchDTO branch);

        Task DeleteBranchAsync(int id);
    }
}
