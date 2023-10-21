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
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionRepository _rolepermissionrepository;
        private readonly IMapper _mappingProfile;

        public RolePermissionService(IMapper mappingProfile, IRolePermissionRepository rolepermissionService)
        {
            _mappingProfile = mappingProfile;
            _rolepermissionrepository = rolepermissionService;

        }

        public async Task CreateRolePermission(RolePermissionDTO rolePermisson)
        {
            var rolePerm = _mappingProfile.Map<RolePermission>(rolePermisson);
            await _rolepermissionrepository.CreateAsync(rolePerm).ConfigureAwait(false);
        }

        public async Task<RolePermissionDTO> GetRolePermissionByIdAsync(int id)
        {
            var rolePermission = await _rolepermissionrepository.GetByIdAsync(id);

            var rolePermissionDTO = _mappingProfile.Map<RolePermissionDTO>(rolePermission);
            return rolePermissionDTO;
        }

        public async Task<IEnumerable<RolePermissionDTO>> GetAllRolePermissionAsync()
        {
            var rolesPermissions = await _rolepermissionrepository.GetAllAsync();

            var rolesPermissionsDTO = _mappingProfile.Map<List<RolePermissionDTO>>(rolesPermissions);
            return rolesPermissionsDTO.ToList();
        }

        public async Task UpdateRolePermissionAsync(int id, RolePermissionDTO rolePermission)
        {
            var existingRolePermission = await _rolepermissionrepository.GetByIdAsync(id);


            _mappingProfile.Map(rolePermission, existingRolePermission);


            await _rolepermissionrepository.UpdateAsync(existingRolePermission);

            //var empl = _mappingProfile.Map<RolePermission>(rolePermission);
            //await _rolepermissionrepository.UpdateAsync(empl);
        }

        public async Task DeleteRolePermissionAsync(int id)
        {
            var rolepermission = await _rolepermissionrepository.GetByIdAsync(id);
            if (rolepermission != null)
            {
                await _rolepermissionrepository.DeleteAsync(id);
            }
        }
    }
}
