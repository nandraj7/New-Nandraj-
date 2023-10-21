using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class EmployeeRoleService : IEmployeeRoleService
    {
        private readonly IEmployeeRoleRepository _employeeRoleRepository;
        private readonly IMapper _mappingProfile;

        public EmployeeRoleService(IEmployeeRoleRepository employeeRoleRepository, IMapper mappingProfile)
        {
            _employeeRoleRepository = employeeRoleRepository;
            _mappingProfile = mappingProfile;
        }

        public async Task CreateEmployeeRole(EmployeeRoleDTO employeeRole)
        {
            var emplRole = _mappingProfile.Map<EmployeeRole>(employeeRole);
            await _employeeRoleRepository.CreateEmplRoleAsync(emplRole).ConfigureAwait(false);
        }


        public async Task<EmployeeRoleDTO> GetEmployeeRoleByIdAsync(int id)
        {
            var emplRole = await _employeeRoleRepository.GetEmplRoleByIdAsync(id);

            var emplRoleDTO = _mappingProfile.Map<EmployeeRoleDTO>(emplRole);
            return emplRoleDTO;

        }

        public async Task<IEnumerable<EmployeeRoleDTO>> GetAllEmployeeRoleAsync()
        {
            var status = await _employeeRoleRepository.GetAllEmplRoleAsync();

            var emplRolesDTO = _mappingProfile.Map<List<EmployeeRoleDTO>>(status);
            return emplRolesDTO.ToList();
        }

        public async Task UpdateEmployeeRoleAsync(int id, EmployeeRoleDTO employee)
        {
            var existingEmployeeRole = await _employeeRoleRepository.GetEmplRoleByIdAsync(id);


            _mappingProfile.Map(employee, existingEmployeeRole);


            await _employeeRoleRepository.UpdateEmplRoleAsync(existingEmployeeRole);

        }

        public async Task DeleteEmployeeRoleAsync(int id)
        {
            var emplRole = await _employeeRoleRepository.GetEmplRoleByIdAsync(id);
            if (emplRole != null)
            {
                await _employeeRoleRepository.DeleteEmplRoleAsync(id);
            }
        }

    }
}
