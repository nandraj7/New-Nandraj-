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

        public async Task<RoleDTO> GetRoleByIdAsync(int id)
        {
            var role = await _rolerepository.GetByIdAsync(id);

            var roleDTO = _mappingProfile.Map<RoleDTO>(role);
            return roleDTO;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRoleAsync()
        {
            var roles = await _rolerepository.GetAllAsync();

            var rolesDTO = _mappingProfile.Map<List<RoleDTO>>(roles);
            return rolesDTO.ToList();
        }

        public async Task UpdateRoleAsync(int id, RoleDTO role)
        {
            var existingrole = await _rolerepository.GetByIdAsync(id);


            _mappingProfile.Map(role, existingrole);


            await _rolerepository.UpdateAsync(existingrole);

            //var roll = _mappingProfile.Map<Role>(role);
            //await _rolerepository.UpdateAsync(roll);
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
