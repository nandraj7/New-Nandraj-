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
    public interface IRoleService
    {
        Task CreateRole(RoleDTO role);
        Task<RoleDTO> GetRoleByIdAsync(int id);
        Task<IEnumerable<RoleDTO>> GetAllRoleAsync();
        Task UpdateRoleAsync(int id, RoleDTO role);
        Task DeleteRoleAsync(int id);
    }
}
