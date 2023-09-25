using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IRoleService
    {
        Task CreateRole(RoleDTO role);
        Task<Role> GetRoleByIdAsync(int id);
        Task<IEnumerable<Role>> GetAllRoleAsync();
        Task UpdateRoleAsync(RoleDTO role);
        Task DeleteRoleAsync(int id);
    }
}
