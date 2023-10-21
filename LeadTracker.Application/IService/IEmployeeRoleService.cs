using LeadTracker.API;
using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IEmployeeRoleService
    {
        Task CreateEmployeeRole(EmployeeRoleDTO employeeRole);

        Task<EmployeeRoleDTO> GetEmployeeRoleByIdAsync(int id);

        Task<IEnumerable<EmployeeRoleDTO>> GetAllEmployeeRoleAsync();

        Task UpdateEmployeeRoleAsync(int id, EmployeeRoleDTO employee);

        Task DeleteEmployeeRoleAsync(int id);
    }
}
