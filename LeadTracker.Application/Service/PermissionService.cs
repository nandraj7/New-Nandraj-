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

        public async Task<PermissionDTO> GetPermissionByIdAsync(int id)
        {
            var permission = await _permissionrepository.GetByIdAsync(id);

            var permissionDTO = _mappingProfile.Map<PermissionDTO>(permission);
            return permissionDTO;
        }

        public async Task<IEnumerable<PermissionDTO>> GetAllPermissionAsync()
        {
            var permissions = await _permissionrepository.GetAllAsync();

            var permissionsDTO = _mappingProfile.Map<List<PermissionDTO>>(permissions);
            return permissionsDTO.ToList();
        }

        public async Task UpdatePermissionAsync(int id, PermissionDTO permission)
        {
            var existingPermission = await _permissionrepository.GetByIdAsync(id);


            _mappingProfile.Map(permission, existingPermission);


            await _permissionrepository.UpdateAsync(existingPermission);

            //var permsn = _mappingProfile.Map<Permission>(permission);
            //await _permissionrepository.UpdateAsync(permsn);
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
