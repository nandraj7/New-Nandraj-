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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _rolerepository;
        private readonly IMapper _mappingProfile;

        public RoleService(IRoleRepository rolerepository, IMapper mappingProfile)
        {
            _rolerepository= rolerepository;
            _mappingProfile= mappingProfile;
        }

        public async Task CreateRole(RoleDTO role)
        {
            var rol = _mappingProfile.Map<Role>(role);
            await _rolerepository.CreateAsync(rol).ConfigureAwait(false);
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _rolerepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllRoleAsync()
        {
            var roles = await _rolerepository.GetAllAsync();
            return roles.ToList();
        }

        public async Task UpdateRoleAsync(RoleDTO role)
        {
            var roll = _mappingProfile.Map<Role>(role);
            await _rolerepository.UpdateAsync(roll);
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _rolerepository.GetByIdAsync(id);
            if (role != null)
            {
                await _rolerepository.DeleteAsync(id);
            }
        }
    }
}
