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
    public interface IPermissionService
    {
        Task CreatePermission(PermissionDTO permission);

        Task<PermissionDTO> GetPermissionByIdAsync(int id);

        Task<IEnumerable<PermissionDTO>> GetAllPermissionAsync();

        Task UpdatePermissionAsync(int id, PermissionDTO permission);

        Task DeletePermissionAsync(int id);
    }
}
