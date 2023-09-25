using AutoMapper;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionrepository;
        private readonly IMapper _mappingProfile;

        public PermissionService(IMapper mappingProfile, IPermissionRepository permissionService)
        {
            _mappingProfile = mappingProfile;
            _permissionrepository = permissionService;

        }


        public async Task CreatePermission(PermissionDTO permission)
        {
            var permsn = _mappingProfile.Map<Permission>(permission);
            await _permissionrepository.CreateAsync(permsn).ConfigureAwait(false);
        }

        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _permissionrepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionAsync()
        {
            var permissions = await _permissionrepository.GetAllAsync();
            return permissions.ToList();
        }

        public async Task UpdatePermissionAsync(PermissionDTO permission)
        {
            var permsn = _mappingProfile.Map<Permission>(permission);
            await _permissionrepository.UpdateAsync(permsn);
        }

        public async Task DeletePermissionAsync(int id)
        {
            var permission = await _permissionrepository.GetByIdAsync(id);
            if (permission != null)
            {
                await _permissionrepository.DeleteAsync(id);
            }
        }
    }
}
