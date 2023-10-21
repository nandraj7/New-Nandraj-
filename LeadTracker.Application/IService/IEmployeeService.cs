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
    public interface IEmployeeService
    {
        Task CreateEmployee(EmployeeDTO employee);

        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);

        Task<IEnumerable<EmployeeDTO>> GetAllEmployeeAsync();

        Task UpdateEmployeeAsync(int id, EmployeeDTO employee);

        Task DeleteEmployeeAsync(int id);
    }
}
