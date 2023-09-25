using AutoMapper;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<RolePermission> GetRolePermissionByIdAsync(int id)
        {
            return await _rolepermissionrepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RolePermission>> GetAllRolePermissionAsync()
        {
            var rolesPermission = await _rolepermissionrepository.GetAllAsync();
            return rolesPermission.ToList();
        }

        public async Task UpdateRolePermissionAsync(RolePermissionDTO rolePermission)
        {
            var empl = _mappingProfile.Map<RolePermission>(rolePermission);
            await _rolepermissionrepository.UpdateAsync(empl);
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
