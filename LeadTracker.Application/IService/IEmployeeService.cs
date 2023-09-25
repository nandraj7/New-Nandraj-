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

        Task<Employee> GetEmployeeByIdAsync(int id);

        Task<IEnumerable<Employee>> GetAllEmployeeAsync();

        Task UpdateEmployeeAsync(EmployeeDTO employee);

        Task DeleteEmployeeAsync(int id);
    }
}
