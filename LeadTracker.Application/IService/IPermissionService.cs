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

        Task<Permission> GetPermissionByIdAsync(int id);

        Task<IEnumerable<Permission>> GetAllPermissionAsync();

        Task UpdatePermissionAsync(PermissionDTO permission);

        Task DeletePermissionAsync(int id);
    }
}
